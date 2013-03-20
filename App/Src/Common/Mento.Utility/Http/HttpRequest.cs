using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Collections.Specialized;

namespace Mento.Utility.Http
{
    public class HttpRequest
    {
        private static new RemoteCertificateValidationCallback IgnoreCertificateErrorHandler = new RemoteCertificateValidationCallback((o, c, x, e) => { return true; });

        public Uri RequestUri { get; set; }

        public NameValueCollection Headers { get; set; }

        private bool IsHttps { get; set; }

        public HttpRequest(string url, NameValueCollection headers)
        {
            RequestUri = new Uri(url);
            Headers = headers;
            IsHttps = RequestUri.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase);
        }

        public HttpResponse Get()
        {
            string requestContent = GetRequestContent(HttpMethod.GET);
            string responseContent = Send(requestContent);

            return new HttpResponse(responseContent);
        }

        public HttpResponse Post(string data)
        {
            string requestContent = GetRequestContent(HttpMethod.POST, data: data);
            string responseContent = Send(requestContent);

            return new HttpResponse(responseContent);
        }

        private string Send(string requestContent)
        {
            string response = String.Empty;

            using (TcpClient client = new TcpClient(RequestUri.Host, RequestUri.Port))
            {
                client.SendTimeout = 100000;
                client.ReceiveTimeout = 100000;
                using (NetworkStream networkStream = client.GetStream())
                {
                    StreamWriter sw = new StreamWriter(networkStream);
                    StreamReader sr = new StreamReader(networkStream);

                    if (IsHttps)
                    {
                        SslStream stream = new SslStream(networkStream, false, IgnoreCertificateErrorHandler, null);
                        stream.AuthenticateAsClient(RequestUri.Host, null, SslProtocols.Tls, false);

                        sw = new StreamWriter(stream);
                        sr = new StreamReader(stream);
                    }

                    sw.WriteLine(requestContent);
                    sw.Flush();

                    response = sr.ReadToEnd();
                }

                client.Close();
            }

            return response;
        }

        private string GetRequestContent(HttpMethod method, string data = null)
        {
            StringBuilder request = new StringBuilder();

            request.Append(method.ToString()).Append(HttpCommon.SPACE).Append(RequestUri.PathAndQuery).Append(HttpCommon.SPACE).Append("HTTP/1.0").Append(HttpCommon.LINEBREAK);
            request.Append("Host").Append(HttpCommon.COLON).Append(HttpCommon.SPACE).Append(RequestUri.DnsSafeHost).Append(HttpCommon.LINEBREAK);
            request.Append(HttpCommon.GetHeaders(this.Headers));
            if (method == HttpMethod.POST)
            {
                request.Append("Content-Type").Append(HttpCommon.COLON).Append("application/x-www-form-urlencoded").Append(HttpCommon.LINEBREAK);
                request.Append("Content-Length").Append(HttpCommon.COLON).Append(data.Length.ToString()).Append(HttpCommon.LINEBREAK);
                request.Append(HttpCommon.LINEBREAK);
                request.Append(data);
            }

            return request.ToString();
        }
    }

    public enum HttpMethod
    {
        GET = 1,
        POST = 2,
    }
}

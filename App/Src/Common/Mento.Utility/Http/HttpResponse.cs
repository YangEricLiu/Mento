using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace Mento.Utility.Http
{
    public class HttpResponse
    {
        public string Content { get; set; }

        public int Statuscode { get; set; }

        public string StatusName { get; set; }

        public string RedirectUrl { get; set; }

        public NameValueCollection Headers { get; set; }

        public string HeaderContent { get; set; }

        public string Body { get; set; }

        public HttpResponse(string response)
        {
            this.Content = response;

            string[] result = Regex.Split(response, @"^\r\n", RegexOptions.Multiline);

            this.HeaderContent = result.FirstOrDefault();
            this.Body = result.LastOrDefault();
            this.Headers = HttpCommon.GetHeaders(this.HeaderContent);

            ParseStatus();

            if (this.Headers["Location"] != null)
                this.RedirectUrl = this.Headers["Location"];


        }

        private void ParseStatus()
        {
            string[] result = Regex.Split(this.HeaderContent, @"\r\n", RegexOptions.Multiline);

            string statusLine = result[0];
            string[] statusValues = Regex.Split(statusLine, HttpCommon.SPACE);

            this.Statuscode = Convert.ToInt32(statusValues[1]);
            this.StatusName = statusValues[2];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DifferenceEngine;
using System.Collections;
using System.IO;

namespace Mento.Script.OpenAPI
{
    public class CompareResponseBody
    {
        public static CompareReport CompareEnergyUseResponseBody(string expectedResponseBodyStr, string actualResponseBodyStr, out bool outResult)
        {
            string expectedResponseBody = ConvertJson.String2Json(expectedResponseBodyStr);
            string actualResponseBody = ConvertJson.String2Json(actualResponseBodyStr);
            
            CompareReport report = new CompareReport();

            #region Confirm that if respons body is empty

            CompareStringResult resultEmpty = IsResponseBodyEqual(expectedResponseBodyStr, actualResponseBodyStr);

            switch (resultEmpty)
            { 
                case CompareStringResult.acEmpty:
                    outResult = false;
                    report.errorMessage = "Actual Response body is empty, but expected not\n";
                    return report;
                case CompareStringResult.exEmpty:
                    outResult = false;
                    report.errorMessage = "Expected Response body is empty, but actual not\n";
                    return report;
                case CompareStringResult.equal:
                    outResult = true;
                    return report;
                case CompareStringResult.bothEmpty:
                    outResult = true;
                    return report;
                default:
                    break;                 
            }

            #endregion

            #region confirm that if response body return error code message

            //format6--当期望值或实际值是errorcode
            CompareStringErrorResult resultError = IsResponseBodyErrorMsgEqual(expectedResponseBodyStr, actualResponseBodyStr);

            switch (resultError)
            {
                case CompareStringErrorResult.acError:
                    outResult = false;
                    report.errorMessage = "Actual Response body return error message, but expected not\n";
                    return report;
                case CompareStringErrorResult.exError:
                    outResult = false;
                    report.errorMessage = "Expected Response body return error message, but actual not\n";
                    return report;
                case CompareStringErrorResult.notEqual:
                    outResult = false;
                    report.errorMessage = "Expected and actual Response body return error message, but not equal\n";
                    return report;
                case CompareStringErrorResult.equal:
                    outResult = true;
                    return report;
                default:
                    break;
            }

            #endregion

            EnergyViewDataBody[] expectedData = EnergyViewDataDtoConvertor.GetEnergyViewDataDtoGroups(expectedResponseBody);
            EnergyViewDataBody[] actualData = EnergyViewDataDtoConvertor.GetEnergyViewDataDtoGroups(actualResponseBody);


            #region confirm if there is no data but structure only
            //format5-完全没有TargetEnergyData内容的情况，即response只是：TargetEnergyData[]
            if (expectedData == null && actualData == null)
            {
                outResult = true;
                return report;
            }
            else if (!(expectedData == null) && actualData == null)
            {
                outResult = false;
                report.errorMessage = "Expected response body have return value, but actual not, only have TargetEnergyData[]";
                return report;
            }
            else if (expectedData == null && !(actualData == null))
            {
                outResult = false;
                report.errorMessage = "Actual response body have return value, but expected not, only have TargetEnergyData[]";
                return report;
            }

            #endregion

            #region confirm if the body response target number not equal
            //format2--当helader即target信息在实际结果存在，但期望不存在，即多返回了block，此时不需要比较里面的energydata
            //format3--当helader即target信息在实际结果中没有时，即少返回了block，此时不需要进一步比较里面的energydata
            if (expectedData.Length < actualData.Length)
            {
                outResult = false;
                report.errorMessage = "actual response body block is more than Expected response body";
                report.detailedInfo = CompareBodyHelper.CompareResponseBodyByFiles(expectedResponseBody, actualResponseBody);
                return report;
            }
            else if (expectedData.Length > actualData.Length)
            {
                outResult = false;
                report.errorMessage = "actual response body block is less than Expected response body";
                report.detailedInfo = CompareBodyHelper.CompareResponseBodyByFiles(expectedResponseBody, actualResponseBody);
                return report;
            }

            #endregion

            #region confirm if the body num is same but not equal
            //format1--当helader即target信息和期望的target一致时，此时要去验证内部energydata数据
            //format7：pie chart
            if (string.Equals(expectedResponseBody, actualResponseBody))
            {
                outResult = true;
                return report;
            }
            else
            {
                outResult = false;
                report = CompareMatchedResponseBody(expectedData, actualData);
                return report;
            }
            #endregion         
        }

        private static CompareReport CompareMatchedResponseBody(EnergyViewDataBody[] expectedData, EnergyViewDataBody[] actualData)
        {
            CompareReport report = new CompareReport();
            StringBuilder st = new StringBuilder();

            for (int i = 0; i < expectedData.Length; i++)
            {
                if (!String.Equals(expectedData[i].TargetEnergyData, actualData[i].TargetEnergyData))
                {
                    st.Append("期望值：" + expectedData[i].TargetEnergyData + "\n");
                    st.Append("实际值：" + actualData[i].TargetEnergyData + "\n"); 
                }
            }

            report.errorMessage = "The actual response body not euqal to actual response body, and both the body have the same blocks";
            report.detailedInfo = st.ToString();

            return report;
        }

        private static CompareStringResult IsResponseBodyEqual(string ex, string ac)
        {
            if (String.IsNullOrEmpty(ex) && String.IsNullOrEmpty(ac))
                return CompareStringResult.bothEmpty;

            if (String.IsNullOrEmpty(ex) && !String.IsNullOrEmpty(ac))
                return CompareStringResult.exEmpty;

            if (!String.IsNullOrEmpty(ex) && String.IsNullOrEmpty(ac))
                return CompareStringResult.acEmpty;

            if (!String.IsNullOrEmpty(ex) && !String.IsNullOrEmpty(ac))
            {
                bool result = String.Equals(ex, ac);

                if (result)
                    return CompareStringResult.equal;
                else 
                    return CompareStringResult.notEqual;
            }

            return CompareStringResult.error;
        }

        private static CompareStringErrorResult IsResponseBodyErrorMsgEqual(string ex, string ac)
        {
            if (IsResponseBodyError(ex) && IsResponseBodyError(ac))
            {
                if (String.Equals(ex, ac))
                    return CompareStringErrorResult.equal;
                else
                    return CompareStringErrorResult.notEqual;              
            }
            if (!IsResponseBodyError(ex) && IsResponseBodyError(ac))
                return CompareStringErrorResult.acError;

            if (IsResponseBodyError(ex) && !IsResponseBodyError(ac))
                return CompareStringErrorResult.exError;

            if (!IsResponseBodyError(ex) && !IsResponseBodyError(ac))
            {
                return CompareStringErrorResult.bothNoError;
            }

            return CompareStringErrorResult.error;
        }

        private static bool IsResponseBodyError(string body)
        {
            if (body.Contains("error") && body.Contains("Code") && body.Contains("Messages"))
            {
                return true;
            }
            
            return false;
        }     
    }

    public struct CompareReport
    {
        public string errorMessage;
        public string detailedInfo;
    }

    public enum CompareStringResult
    {
        bothEmpty = 1,
        exEmpty = 2,
        acEmpty = 3,
        notEqual = 4,
        equal = 5,
        error = 6,
    }

    public enum CompareStringErrorResult
    {
        bothNoError = 1,
        exError = 2,
        acError = 3,
        notEqual = 4,
        equal = 5,
        error = 6,
    }
}

using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.Generic;

namespace BG.SharePoint.Test
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "ServiceCall({sampleValue})")]
        string ServiceCall(string sampleValue);



        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
             Method = "POST",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json)]
        string MultiplicationPOST(string number);

        

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        ResponseModel CreateDataListItemPOST(string title,
                                             string firstNumber,
                                             string lastNumber,
                                             string color);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
           Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json)]
        ResponseModel CreateColorListItemPOST(string color);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
          Method = "POST",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Color> GetColorsPOST();

    }



}

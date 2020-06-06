using System.ServiceModel.Activation;
using System.Collections.Generic;

namespace BG.SharePoint.Test
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class TestService : ITestService
    {
        public string ServiceCall(string sampleValue)
        {                          
            return "ok";
        }

        public string MultiplicationPOST(string inputNumber)
        {
            int resultNumber;

            bool result = int.TryParse(inputNumber, out resultNumber);
            if (result == true)
                return (resultNumber * resultNumber).ToString();
            else
                return "-";
        }

        public ResponseModel CreateDataListItemPOST(string title,string firstNumber,string lastNumber,string color)
        {
            ResponseModel result = new ResponseModel();
            ListUtil listUtil = new ListUtil();
            bool created = listUtil.CreateDataListItem(title, firstNumber, lastNumber, color, result);                
            result.IsCreated = created;
            return result;
        }

        public ResponseModel CreateColorListItemPOST(string color)
        {
            ResponseModel result = new ResponseModel();
            ListUtil listUtil = new ListUtil();
            bool created = listUtil.CreateColorListItem(color, result);
            result.IsCreated = created;
            return result;
        }

        public IEnumerable<Color> GetColorsPOST()
        {
            ResponseModel result = new ResponseModel();
            ListUtil listUtil = new ListUtil();
            return listUtil.GetColors();
        } 
    }
}
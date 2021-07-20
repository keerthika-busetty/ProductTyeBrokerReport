using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingReport.Data
{
     public class LoadFormData
    {
        //combobox data for the the form
         public static List<string> LoadComboBroker()
        {
            List<string> brokerList = new List<string>();

            brokerList.Add("A");
            brokerList.Add("B");

            return brokerList;

        }
    }
}

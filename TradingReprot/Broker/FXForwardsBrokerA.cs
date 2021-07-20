using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingReport.Data;
using TradingReport.Interface;
using TradingReprot.Model;

namespace TradingReport.Broker
{
   public class FXForwardsBrokerA : IReport
    {
        public IEnumerable<BaseReportData> listFXForwards;
        public string fileName;
        public ILoad fxobj;
        //Injecting the paramether ILoadFXForwards
        public FXForwardsBrokerA(ILoad _loadFXForwards)
        {
            fxobj = _loadFXForwards;
        }

        //Generating Report
        public void GenerateReport()
        {
            //setting FileName
            fileName = string.Format(@"FXForwards-BrokerA-{0}", listFXForwards?.First()?.TradeDate);
            string path = Path.Combine(fileName);
            using (var writer = new StreamWriter(path))
            {
                //Writing header to the Report
                writer.WriteLine("tradeRef,productId,productName,tradeDate,qty,buySell,price");
                //Writing Data to the Report
                foreach(FXForwards rec in listFXForwards)
                {
                    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6}", rec.TradeRef, rec.ProductId, rec.ProductName, rec.TradeDate, rec.Quantity, rec.Side, rec.Price);

                }
            }
        }


        public void GetData()
        {
            //Getting Data
            listFXForwards = fxobj.LoadData("A");
           
        }
    }
}

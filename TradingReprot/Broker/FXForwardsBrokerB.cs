using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingReport;
using TradingReport.Data;
using TradingReport.Interface;
using TradingReprot.Model;

namespace TradingReport.Broker
{
    public class FXForwardsBrokerB : IReport
    {
        public IEnumerable<BaseReportData> data;
        string fileName;
        ILoad fxobj;
        //Injecting the paramether ILoadFXForwards
        public FXForwardsBrokerB(ILoad _loadFXForwards)
        {
            fxobj = _loadFXForwards;
        }
        //Generating Report
        public void GenerateReport()
        {
            //setting FileName
            fileName = string.Format(@"FXForwards-BrokerB-{0}", data?.First()?.TradeDate);
            string path = Path.Combine(fileName);
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine("tradeRef,productId,productName,tradeDate,qty,buySell,price");
                foreach (FXForwards rec in data)
                {
                    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6}", rec.TradeRef, rec.ProductId, rec.ProductName, rec.TradeDate, rec.Quantity, rec.Side, rec.Price);

                }
            }
        }

        public void GetData()
        {
            //Getting Data
            data = fxobj.LoadData("B");
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingReport.Interface;
using TradingReprot.Model;

namespace TradingReport.Data
{
    //creating dummy data for FXForwards for both brokers A,B
    public class FXForwardsData  : ILoad
    { 
        public List<FXForwards> fxfwd = new List<FXForwards>();
        public IEnumerable<BaseReportData> LoadData(string Broker)
        {
            FXForwards fwd1;
            FXForwards fwd2;
            FXForwards fwd3;
            if (Broker == "A")
            {
                 fwd1 = new FXForwards();
                fwd1.TradeRef = "T-FWD-1";
                fwd1.ProductId = 1;
                fwd1.ProdType = producttype.FXForwards;
                fwd1.ProductName = "AUDNZD FRD Exp14Jul2021";
                fwd1.TradeDate = "20200408";
                fwd1.Quantity = 1000000;
                fwd1.Side = "B";
                fwd1.Price = 1.067591;
                fwd1.Broker = "A";

                 fwd2 = new FXForwards();
                fwd2.TradeRef = "T-FWD-2";
                fwd2.ProductId = 2;
                fwd2.ProdType = producttype.FXForwards;
                fwd2.ProductName = "AUDUSD FRD Exp15Jul2021";
                fwd2.TradeDate = "20200408";
                fwd2.Quantity = 8000000;
                fwd2.Side = "S";
                fwd2.Price = 0.7518301;
                fwd2.Broker = "A";

                 fwd3 = new FXForwards();
                fwd3.TradeRef = "T-FWD-3";
                fwd3.ProductId = 3;
                fwd3.ProdType = producttype.FXForwards;
                fwd3.ProductName = "EURUSD FRD Exp15Jul2021";
                fwd3.TradeDate = "20200408";
                fwd3.Quantity = 25000000;
                fwd3.Side = "B";
                fwd3.Price = 1.186073;
                fwd3.Broker = "A";

            }
            else {
                 fwd1 = new FXForwards();
                fwd1.TradeRef = "T-FWD-1";
                fwd1.ProductId = 1;
                fwd1.ProdType = producttype.FXForwards;
                fwd1.ProductName = "AUDNZD FRD Exp14Jul2021";
                fwd1.TradeDate = "20200408";
                fwd1.Quantity = 1000000;
                fwd1.Side = "B";
                fwd1.Price = 1.067591;
                fwd1.Broker = "B";

                fwd2 = new FXForwards();
                fwd2.TradeRef = "T-FWD-2";
                fwd2.ProductId = 2;
                fwd2.ProdType = producttype.FXForwards;
                fwd2.ProductName = "AUDUSD FRD Exp15Jul2021";
                fwd2.TradeDate = "20200408";
                fwd2.Quantity = 8000000;
                fwd2.Side = "S";
                fwd2.Price = 0.7518301;
                fwd2.Broker = "B";

                 fwd3 = new FXForwards();
                fwd3.TradeRef = "T-FWD-3";
                fwd3.ProductId = 3;
                fwd3.ProdType = producttype.FXForwards;
                fwd3.ProductName = "EURUSD FRD Exp15Jul2021";
                fwd3.TradeDate = "20200408";
                fwd3.Quantity = 25000000;
                fwd3.Side = "B";
                fwd3.Price = 1.186073;
                fwd3.Broker = "B";

                    }
            fxfwd.Add(fwd1);
            fxfwd.Add(fwd2);
            fxfwd.Add(fwd3);
           
            return  fxfwd.ToList<BaseReportData>();
        }

       
    }
}

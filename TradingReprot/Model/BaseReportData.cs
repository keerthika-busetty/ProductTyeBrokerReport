using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingReport;

namespace TradingReprot.Model
{
    public class BaseReportData
    {
        public producttype ProdType { get; set; }
        public string Broker { get; set; }
        public string TradeRef { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string TradeDate { get; set; }
        public int Quantity { get; set; }
        public string Side { get; set; }
        public Double Price { get; set; }
    }
}

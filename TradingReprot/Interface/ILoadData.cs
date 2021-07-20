using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingReport;
using TradingReprot.Model;

namespace TradingReport.Interface
{
    public interface ILoad
    {
        IEnumerable<BaseReportData>  LoadData(string Broker);
    }
}

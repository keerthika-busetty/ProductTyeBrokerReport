using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using TradingReport.Interface;
using TradingReport;

namespace TradingReprot.Interface
{
    
     public interface IReportView
    {
        bool GETReporObject(producttype type, string Broker);
        
    }
}

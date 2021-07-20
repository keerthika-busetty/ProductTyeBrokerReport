using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TradingReport;
using TradingReport.Data;
using TradingReport.Interface;
using Unity;

namespace TradingReport
{
    public class Helper
    {
        public static IReport GETReporObject(producttype type,string Broker)
        {
            IUnityContainer container = new UnityContainer();
            
            if (type == producttype.FXForwards)
            { 
              container.RegisterType<ILoad, FXForwardsData>();
              
            }

            // var myObj = Activator.CreateInstance(Type.GetType("TradingReport.Broker" + "." + type+"Broker"+Broker), new object[] { new FXForwardsData() });
            var myObj = Activator.CreateInstance(Type.GetType("TradingReport.Broker" + "." + type + "Broker" + Broker), new object[] { container.Resolve<ILoad>() });
            IReport reportObj = (IReport)myObj;

            return reportObj;
        }
    }
}

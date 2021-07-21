using System;
using TradingReport.Data;
using TradingReport.Interface;
using TradingReprot.Interface;
using System.Configuration;
using Unity;


namespace TradingReport
{
    public class ReportView  : IReportView
    {
        public IReport report;
        public  bool GETReporObject(producttype type,string Broker)
        {
            IUnityContainer container = new UnityContainer();
            
            if (type == producttype.FXForwards)
            { 
              container.RegisterType<ILoad, FXForwardsData>();
              
            }

            // var myObj = Activator.CreateInstance(Type.GetType("TradingReport.Broker" + "." + type+"Broker"+Broker), new object[] { new FXForwardsData() });
            //var myObj = Activator.CreateInstance(Type.GetType("TradingReport.Broker" + "." + type + "Broker" + Broker), new object[] { container.Resolve<ILoad>() });
            var myObj = Activator.CreateInstance(Type.GetType(string.Format(ConfigurationManager.AppSettings["TradingReportName"],type,Broker)), new object[] { container.Resolve<ILoad>() });
            IReport reportObj = (IReport)myObj;

            report = reportObj;
            report.GetData();
           return  report.GenerateReport();
        }
    }
}

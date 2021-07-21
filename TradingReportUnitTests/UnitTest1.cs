using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TradingReport;
using TradingReport.Broker;
using TradingReport.Interface;
using NUnit.Framework;
using TradingReprot.Interface;
using System.Linq;
using TradingReport.Data;

namespace TradingReportUnitTests
{
    [TestClass]
    public class UnitTest
    {
        //Unit test for ReportView.GETReporObject
        [TestMethod]
        public void Test_ReportView_GETReporObject()
        {
            //Arrange
            producttype type = producttype.FXForwards;
            string broker = "A";

            //Act
            ReportView reportview = new ReportView();
            bool result = reportview.GETReporObject(type, broker);

            //Assert
            NUnit.Framework.Assert.AreEqual(result, true);
        }

        //Unit Test for FXForwards_BrokerA getting Data
        [TestMethod]
        public void Test_FXForwards_BrokerA_GetData()
        {
            //Arrange
            string Broker = "A";
            var mockFXForwards = new List<FXForwards>()
             {
            new FXForwards{TradeDate="test1"},
            new FXForwards{TradeDate="test2"},
            new FXForwards{TradeDate="test2"},
             };

            //creating Mock Object for ILoadFXForwards
            var newMoq = new Mock<ILoad>();
            FXForwardsBrokerA testReport = new FXForwardsBrokerA(newMoq.Object);
            newMoq.Setup(x => x.LoadData(Broker)).Returns(mockFXForwards);

            //Act
            testReport.GetData();

            //Assert
            NUnit.Framework.Assert.That(testReport.listFXForwards.Count(), Is.GreaterThan(1));
        }
        //Unit Test for FXForwards_BrokerA GenerateReport
        [TestMethod]
        public void Test_FXForwards_BrokerA_GenerateReport()
        {
            //Arrange
            var mockFXForwards = new List<FXForwards>()
                {
            new FXForwards{TradeDate="test1"},
            new FXForwards{TradeDate="test2"},
            new FXForwards{TradeDate="test2"},
                };

            var newMoq = new Mock<ILoad>();
            FXForwardsBrokerA testReport = new FXForwardsBrokerA(newMoq.Object);
            testReport.listFXForwards = mockFXForwards;

            //Act

            bool result = testReport.GenerateReport();
            //Assert
            NUnit.Framework.Assert.AreEqual(result, true);
        }
        //Unit test for Form1 GenerateReport
        [TestMethod]
        public void Test_Form1_GenerateReport()
        {
            //Arrange
            Mock<IReportView> reportViewMock = new Mock<IReportView>();

            //Act
            UserView form = new UserView(reportViewMock.Object);


            //Assert
            NUnit.Framework.Assert.DoesNotThrow(() => form.GenerateReport());
        }

        //Unit Test for Form1 LoadCombo
        [TestMethod]
        public void Test_Form1_LoadCombo()
        {
            //Arrange
            Mock<IReportView> reportViewMock = new Mock<IReportView>();
            UserView form = new UserView(reportViewMock.Object);

            //Act



            //Assert
            NUnit.Framework.Assert.DoesNotThrow(() => form.loadCombo());
        }
        [TestMethod]
        public void Test_FXforwardsData()
        {
            //Arrange
            FXForwardsData fx = new FXForwardsData();

            //Act
            fx.LoadData("A");


            //Assert
            NUnit.Framework.Assert.That(fx.fxfwd.Count, Is.GreaterThan(1));
        }
        [TestMethod]
        public void Test_LoadComboBroker()
        {
            //Arrange


            //Act
            IList<string> result = LoadFormData.LoadComboBroker();


            //Assert
            NUnit.Framework.Assert.That(result.Count, Is.GreaterThan(1));
        }

    }
}

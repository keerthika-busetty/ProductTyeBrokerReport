using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TradingReport;
using TradingReport.Broker;
using TradingReport.Interface;
using NUnit.Framework;
using System.Windows.Forms;
using TradingReprot.Interface;
using System.Linq;

namespace TradingReportUnitTest
{
    [TestClass]
    public class UnitTest
    {
        //Unit test for Helper.GETReporObject
        [TestMethod]
        public void Test_Helper_GETReporObject()
        {
            //Arrange
            producttype type = producttype.FXForwards;
            string broker = "A";
            //creating mock object for  ILoadFXForwards 
            var newMoq = new Mock<ILoad>();
            IReport testReport = new FXForwardsBrokerA(newMoq.Object);

            //Act
            IReport report = Helper.GETReporObject(type, broker);

            //Assert
            NUnit.Framework.Assert.IsInstanceOf(report.GetType(), testReport);
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
            NUnit.Framework.Assert.AreEqual(testReport.listFXForwards.Count(), 3);
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


            //Assert
            NUnit.Framework.Assert.DoesNotThrow(() => testReport.GenerateReport());
        }
        //Unit test for Form1 GenerateReport
        [TestMethod]
        public void Test_Form1_GenerateReport()
        {
            //Arrange
            Mock<IMessageBox> messageBoxMock = new Mock<IMessageBox>();
            messageBoxMock.Setup(m => m.Show(It.IsAny<string>()))
                .Returns(DialogResult.OK); //can be whatever depends on test case
            Form1 form = new Form1(messageBoxMock.Object);
            
            //Assert
            NUnit.Framework.Assert.DoesNotThrow(() => form.GenerateReport());
        }

        //Unit Test for Form1 LoadCombo
        [TestMethod]
        public void Test_Form1_LoadCombo()
        {
            //Arrange
            Mock<IMessageBox> messageBoxMock = new Mock<IMessageBox>();
            messageBoxMock.Setup(m => m.Show(It.IsAny<string>()))
                .Returns(DialogResult.OK); //can be whatever depends on test case
            Form1 form = new Form1(messageBoxMock.Object);

            //Assert
            NUnit.Framework.Assert.DoesNotThrow(() => form.loadCombo());
        }


    }
}

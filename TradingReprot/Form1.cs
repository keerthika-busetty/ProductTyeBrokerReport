using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingReport;
using TradingReport.Interface;
using TradingReport.Data;
using TradingReprot.Interface;

namespace TradingReport
{
    public partial class Form1 : Form
    {
        //Injecing the to the constructor
        private readonly IMessageBox messageBox;
        public Form1(IMessageBox _messageBox)
        {
            messageBox = _messageBox;
            InitializeComponent();
            //loading combobox data
            loadCombo();
        }

        public void loadCombo()
        {
            //assing datasoruce for the comboboxes
            comboBox1.DataSource = Enum.GetValues(typeof(producttype));
            comboBox1.SelectedIndex = 0;
            comboBox2.DataSource = LoadFormData.LoadComboBroker();
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
             GenerateReport();
        }

       public void GenerateReport()
        {
            //calling heler method for dynamically creating reprot object
            IReport report =  Helper.GETReporObject((producttype)comboBox1.SelectedItem, Convert.ToString(comboBox2.SelectedItem));
            //Getting Report Data
            report.GetData();
            //Generating Report and storing in bin folder
            report.GenerateReport();
            messageBox.Show("Report is done:Projectfolder/bin/debug");
        }
    }
}

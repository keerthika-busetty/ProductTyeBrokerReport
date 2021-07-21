using System;
using System.Windows.Forms;
using TradingReport.Data;
using TradingReprot.Interface;
using System.Configuration;

namespace TradingReport
{
    public partial class UserView : Form
    {
        public IReportView reportView;

        //Injecing the to the constructor

        public UserView(IReportView _reportView)
        {
            InitializeComponent();
            reportView = _reportView;

            //loading combobox data
            loadCombo();
        }

        public void loadCombo()
        {
            //assing datasoruce for the comboboxes
            comboBox1.DataSource = Enum.GetValues(typeof(producttype));
               if(comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
               comboBox2.DataSource = LoadFormData.LoadComboBroker();
                if (comboBox2.Items.Count > 0)
                   comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
             GenerateReport();
        }

       public void GenerateReport()
        {
            //calling heler method for dynamically creating reprot object
            bool result = reportView.GETReporObject((producttype)comboBox1.SelectedItem, Convert.ToString(comboBox2.SelectedItem));
            LblResult.Visible = true;
            if (result)
            {
                string res = Convert.ToString(ConfigurationManager.AppSettings["MessageTrue"]) != null ? Convert.ToString(ConfigurationManager.AppSettings["MessageTrue"]) : "{0} Report is done:Projectfolder/bin/debug";

                LblResult.Text = string.Format(res, Convert.ToString(comboBox2.SelectedItem));
            }
            else
            {
                string res = Convert.ToString(ConfigurationManager.AppSettings["MessageFalse"]) != null ? Convert.ToString(ConfigurationManager.AppSettings["MessageTrue"]) : "{0} There is some problem in generating Report";
                LblResult.Text = string.Format(res, Convert.ToString(comboBox2.SelectedItem));
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblResult.Text = string.Empty;
        }
    }
}

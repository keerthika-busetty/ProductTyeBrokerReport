using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingReprot.Interface;

namespace TradingReprot
{
    public class MessageBoxWrapper : IMessageBox
    {
        public DialogResult Show(string message)
        {
            return MessageBox.Show(message);
        }
    }

}

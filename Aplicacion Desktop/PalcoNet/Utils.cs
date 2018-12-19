using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    class Utils
    {
        public static void añadirVistaAPanel(Form form, Panel panel) {
            form.TopLevel = false;
            form.AutoScroll = true;
            panel.Controls.Add(form);
            form.Show();
        }
    }
}

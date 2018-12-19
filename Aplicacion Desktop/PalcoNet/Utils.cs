using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static Button crearBoton(string text) {
            Button button = new Button();
            button.Text = text;
            button.BackColor = Color.LightGray;
            button.Size = new Size(120, 30);
            button.ForeColor = Color.White;
            button.Font = new Font(FontFamily.GenericSansSerif, 10.0f, FontStyle.Bold);

            return button;
        }
    }
}

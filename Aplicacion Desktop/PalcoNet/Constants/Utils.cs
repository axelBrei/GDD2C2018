using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PalcoNet.Constants
{
    class Utils
    {
        public static DateTime getFecha() {
            DateTime fecha = new DateTime();
            string f = ConfigurationManager.AppSettings.Get("fecha");
            if (!string.IsNullOrEmpty(f)) {
                fecha = DateTime.ParseExact(f, "yyyy-dd-MM", null);
            }
            return fecha;
        }

        public static DateTime getFechaMinima() {
            DateTime fecha = new DateTime();
            string f = ConfigurationManager.AppSettings.Get("fecha_min");
            if (!string.IsNullOrEmpty(f)) {
                fecha = DateTime.ParseExact(f, "yyyy-dd-MM", null);
            }
            return fecha;
        }
    }
}

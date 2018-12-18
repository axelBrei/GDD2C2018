using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PalcoNet.Validators
{
    class Validator
    {

        public static bool esEmailValido(string texto)
        {

            return new Regex(@"^[a-z0-9!#$%&'*+\/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+\/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", RegexOptions.IgnoreCase).IsMatch(texto);

        }



        public static bool esTelefonoValido(string texto)
        {

            return new Regex(@"^[0-9\-\+\s]{4,}$").IsMatch(texto);

        }



        public static bool esNumerico(string texto)
        {

            return new Regex(@"^[0-9]+$").IsMatch(texto);

        }
    }
}

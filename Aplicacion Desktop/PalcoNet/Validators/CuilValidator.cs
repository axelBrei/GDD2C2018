using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PalcoNet.Validators
{
    public class CuilValidator
    {

        private static Regex digitsOnly = new Regex(@"[^\d]");  

        public static bool validarCuit(String cuit)
        {
            //Eliminamos todos los caracteres que no son números
            cuit = digitsOnly.Replace(cuit, "");
            //Controlamos si son 11 números los que quedaron, si no es el caso, ya devuelve falso
            if (cuit.Length != 11)
            {
                return false;
            }
            //Convertimos la cadena que quedó en una matriz de caracteres
            char[] cuitArray = cuit.ToCharArray();
            //Inicializamos una matriz por la cual se multiplicarán cada uno de los dígitos
            int[] serie = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            //Creamos una variable auxiliar donde guardaremos los resultados del cálculo del número validador
            int aux = 0;
            //Recorremos las matrices de forma simultanea, sumando los productos de la serie por el número en la misma posición
            for (int i = 0; i < 10; i++)
            {
                aux += Int32.Parse(cuitArray[i].ToString()) * serie[i];
            }
            //Hacemos como se especifica: 11 menos el resto de de la división de la suma de productos anterior por 11
            aux = 11 - (aux % 11);
            //Si el resultado anterior es 11 el código es 0
            if (aux == 11)
            {
                aux = 0;
            }
            //Si el resultado anterior es 10 el código no tiene que validar, cosa que de todas formas pasa
            //en la siguiente comparación.
            //Devuelve verdadero si son iguales, falso si no lo son
            return Int32.Parse(cuitArray[10].ToString()).Equals(aux);
        }
    }
}

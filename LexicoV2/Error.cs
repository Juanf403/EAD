using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicoV2
{
    public static class Error
    {
        public static string DeterminarError(string cadenaError)
        {
            if (cadenaError == "CADECAE$CNEN") //Cadena con Entero
            {
               return "ERROR DE TIPO DE DATO, NO SE PUEDE ASIGNAR UN NUMERO ENTERO A UNA CADENA";
            }
            else if (cadenaError == "CNENCAE$CADE") //Entero con Cadena
            {
                return"ERROR DE TIPO DE DATO, NO SE PUEDE ASIGNAR UNA CADENA A UNA NUMERO ENTERO";
            }
            else if (cadenaError == "CADECAE$CNRE") //Cadena con Real
            {
                return"ERROR DE TIPO DE DATO, NO SE PUEDE ASIGNAR UN NUMERO REAL A UNA CADENA";
            }
            else if (cadenaError == "CNRECAE$CADE") //Real con Cadena
            {
                return "ERROR DE TIPO DE DATO, NO SE PUEDE ASIGNAR UNA CADENA A UN NUMERO REAL";
            }
            else if (cadenaError == "CADECAE$OPAR") //Suma Cadena 
            {
                return "ERROR DE TIPO DE DATO, NO SE PUEDE ASIGNAR UNA CADENA A UN NUMERO ENTERO";
            }
            else if (cadenaError == "CADECAE$OPA1") //Suma Cadena 
            {
                return "ERROR DE TIPO DE DATO, NO SE PUEDE ASIGNAR UNA CADENA A UN NUMERO ENTERO";
            }
            else
            {
                return "";
            }
        }



    }
}

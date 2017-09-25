using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicoV2
{
    class Cuadruplo
    {
        private string datoObjeto, datoFuete, operador,datoFuente2;
        public List<Cuadruplo> lista;
        public Cuadruplo(string datoObjeto, string datoFuete, string datoFuente2, string operador, List<Cuadruplo> lista)
        {
            this.datoFuete = datoFuete;
            this.datoFuente2 = datoFuente2;
            this.datoObjeto = datoObjeto;
            this.operador = operador;
            this.lista = lista;
        }
        public string DatoObjeto { get { return datoObjeto; } set { datoObjeto = value; } }
        public string DatoFuente { get { return datoFuete; } set { datoFuete = value; } }
        public string DatoFuente2 { get { return datoFuente2; } set { datoFuente2 = value; } }
        public string Operador { get { return operador; } set { operador = value; } }
    }
}

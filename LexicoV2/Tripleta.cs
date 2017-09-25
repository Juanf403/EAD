using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicoV2
{
    public class Tripleta
    {
        private string datoObjeto,datoFuete,operador;
        public List<Tripleta> lista;
        public Tripleta(string datoObjeto,string datoFuete,string operador, List<Tripleta> lista)
        {
            this.datoFuete = datoFuete;
            this.datoObjeto = datoObjeto;
            this.operador = operador;
            this.lista = lista;
        }
        public string DatoObjeto { get { return datoObjeto; } set { datoObjeto = value; } }
        public string DatoFuente { get { return datoFuete; } set { datoFuete = value; } }
        public string Operador { get { return operador; } set { operador = value; } }

    }
}

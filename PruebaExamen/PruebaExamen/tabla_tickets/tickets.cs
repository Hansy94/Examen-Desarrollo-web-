using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaExamen.tabla_tickets
{
    internal class tickets
    {
        public int id_tickets { get; set; }
        public string fila { get; set; }

        public string Precio { get; set; }
        public string idevento { get; set; }

        public string toJson()
        {
            return "{\"fila\":\"" + fila + " \",\"Precio\": \"" + Precio + "\" , \"idevento\":\"" + idevento + "\" }";

        }
    }
}
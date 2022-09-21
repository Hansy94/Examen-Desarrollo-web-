using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaExamen.tabla_evento
{
    internal class evento
    {
        public int id_evento { get; set; }
        public string nombre_evento { get; set; }

        public string fecha { get; set; }
        public string idtipoevento { get; set; }

        public string toJson()
        {
            return "{\"nombre_evento\":\"" + nombre_evento + " \",\"fecha\": \"" + fecha + "\" , \"idtipoevento\":\"" + idtipoevento + "\" }";

        }
    }
}

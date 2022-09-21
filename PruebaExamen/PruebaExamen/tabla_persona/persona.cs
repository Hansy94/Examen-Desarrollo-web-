using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaExamen.tabla_persona
{
    internal class persona
    {
        internal string descripcion;

        public int id_membresia { get; set; }
        public string nombre_persona { get; set; }

        public string correo_electronico { get; set; }
        public string idmembresia { get; set; }

        public string toJson()
        {
            return "{\"nombre_persona\":\"" + nombre_persona + " \",\"correo_electronico\": \"" + correo_electronico + "\" , \"idmembresia\":\"" + idmembresia + "\" }";

        }
    }
}

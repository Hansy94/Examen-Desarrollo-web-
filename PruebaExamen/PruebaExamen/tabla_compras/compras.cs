using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaExamen.tabla_compras
{
    internal class compras
    {
        public int id_compras { get; set; }
        public string fecha_compra { get; set; }

        public string idmembresia { get; set; }
        public string idtickets { get; set; }

        public string toJson()
        {
            return "{\"fecha_compra\":\"" + fecha_compra + "\",\"idmembresia\": \"" + idmembresia + "\",\"idtickets\":\"" + idtickets + "\" }";

        }
    }
}

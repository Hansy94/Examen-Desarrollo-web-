namespace PruebaExamen.tabla_tipo_membresia
{
    internal class tipomembresia
    {
        public int id_tipo_membresia { get; set; }
        public string descripcion { get; set; }

        public string toJson()
        {
            return "{\"descripcion\":\"" + descripcion+ "\" }";
        }
    }
}

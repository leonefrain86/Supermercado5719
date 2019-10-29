namespace Supermercado5719.Models
{
    public class Articulo
    {
        public int id { get; set; }
        public int codigoBarra { get; set; }
        public int codigoInterno { get; set; }
        public string descripcion { get; set; }
        public string descripcionAbreviada { get; set; }
        public double precio { get; set; }
    }
}

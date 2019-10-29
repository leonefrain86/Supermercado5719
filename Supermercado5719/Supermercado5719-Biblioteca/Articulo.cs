using System;

namespace Supermercado5719_Biblioteca
{
    public class Articulo
    {
        public int idArticulo { get; set; }
        public int codigoBarra { get; set; }
        public int codigoInterno { get; set; }
        public string descripcion { get; set; }
        public string descripcionAbreviada { get; set; }
        public double precio { get; set; }

        public Articulo(int idArticulo, string codigoBarra, string codigoInertno, string descripcion, string descripcionAbreviada, double precio)
        {
            
        }

    }
}

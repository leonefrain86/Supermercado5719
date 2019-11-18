using System.Collections.Generic;

namespace Supermercado5719_Biblioteca
{
    public class Articulo
    { 
        public int id { get; set; }
        public string codigoBarra { get; set; }
        public int codigoInterno { get; set; }
        public string descripcion { get; set; }
        public string descripcionAbreviada { get; set; }
        public double precio { get; set; }

        // public Articulo(string codigoBarra, int codigoInterno, string descripcion, string descripcionAbreviada, double  precio)
        // {
        //     this.codigoBarra = codigoBarra;
        //     this.codigoInterno = codigoInterno;
        //     this.descripcion = descripcion;
        //     this.descripcionAbreviada = descripcionAbreviada;
        //     this.precio = precio;
        // }
    }
}

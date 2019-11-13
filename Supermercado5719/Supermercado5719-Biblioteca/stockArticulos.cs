using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado5719_Biblioteca
{
    public class stockArticulos
    {
        public int id { get; set; }
        public Articulo articulo { get; set; }
        public int stock { get; set; }

        public stockArticulos()
        {
            stock = 0;
            articulo = new Articulo();
        }
    }
}

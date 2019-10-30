using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado5719_Biblioteca
{
    public class Item
    {
        public int idItem { get; set; }
        public stockArticulos cantArticulos { get; set; }
        public int cantidad { get; set; }
        public double precioSubtotal { get; set; }

        public Item(string codigoBarra, int cantidad)
        {
            this.cantidad = cantidad;
        }

    }
}

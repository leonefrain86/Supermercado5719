﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado5719_Biblioteca
{
    public class Item
    {
        public int id { get; set; }
        public Articulo articulo { get; set; }
        public int unidades { get; set; }
        public double precioSubtotal { get; set; }

        public Item()
        {
            unidades = 0;
            precioSubtotal = 0;
            articulo = new Articulo();
        }

    }
}

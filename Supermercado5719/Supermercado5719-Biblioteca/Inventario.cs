﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado5719_Biblioteca
{
    public class Inventario
    {
        public int id { get; set; }
        public List<stockArticulos> stockArticulos { get; set; }

        public Inventario()
        {
            stockArticulos = new List<stockArticulos>();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado5719_Biblioteca
{
    public class Inventario
    {
        public int idInventario { get; set; }
        public List<CantArticulo> cantArticulos { get; set; }
        public int stock { get; set; }
    }
}

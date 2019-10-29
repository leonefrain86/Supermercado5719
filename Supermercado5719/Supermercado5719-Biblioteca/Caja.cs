using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado5719_Biblioteca
{
    public class Caja
    {
        public int numCaja { get; set; }
        public List<Venta> ventas { get; set; }

        public Caja()
        {

        }
        public void Vender(string codigoBarra, int cantUnidades)
        {
            ventas.Add(new Venta(this, codigoBarra, cantUnidades));
        }

    }
}

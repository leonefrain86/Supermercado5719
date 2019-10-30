using System.Collections.Generic;

namespace Supermercado5719_Biblioteca
{
    public class Caja
    {
        public int numCaja { get; set; }
        public List<Venta> ventas { get; set; }

        public Caja (int numCaja, string codigoBarra, int cantidad)
        {
            this.numCaja = numCaja;
            ventas.Add(new Venta(this, codigoBarra, cantidad));
        }
    }
}

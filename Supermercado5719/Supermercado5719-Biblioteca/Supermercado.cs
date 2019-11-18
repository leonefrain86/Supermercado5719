using System.Collections.Generic;

namespace Supermercado5719_Biblioteca
{
    public class Supermercado
    {
        public int id { get; set; }
        public Inventario inventario { get; set; }
        public List<Caja> cajas { get; set; }

        public Supermercado()
        {
            inventario = new Inventario();
            cajas = new List<Caja>(){ new Caja { numCaja = 1, ventas = new List<Venta>() },
                                      new Caja { numCaja = 2, ventas = new List<Venta>() },
                                      new Caja { numCaja = 3, ventas = new List<Venta>() },
                                      new Caja { numCaja = 4, ventas = new List<Venta>() },
                                      new Caja { numCaja = 5, ventas = new List<Venta>() }};
        }
    }
}

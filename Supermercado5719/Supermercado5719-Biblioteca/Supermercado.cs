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
            cajas = new List<Caja>(){ new Caja { numCaja = 1, tickets = new List<Ticket>() },
                                      new Caja { numCaja = 2, tickets = new List<Ticket>() },
                                      new Caja { numCaja = 3, tickets = new List<Ticket>() },
                                      new Caja { numCaja = 4, tickets = new List<Ticket>() },
                                      new Caja { numCaja = 5, tickets = new List<Ticket>() }};
        }
    }
}

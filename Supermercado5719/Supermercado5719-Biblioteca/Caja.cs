using System.Collections.Generic;

namespace Supermercado5719_Biblioteca
{
    public class Caja
    {
        public int id { get; set; }
        public int numCaja { get; set; }
        public List<Ticket> tickets { get; set; }

        //public Caja()
        //{
        //    this.numCaja = 0;
        //    ventas = new List<Venta>();
        //}
    }
}

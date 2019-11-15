using System.Collections.Generic;

namespace Supermercado5719_Biblioteca
{
    public class Ticket
    {
        public int id { get; set; }
        public double precioTotal { get; set; }
        public List<Item> items { get; set; }
        public int numTicket { get; set; }

        public Ticket()
        {
            precioTotal = 0;
            items = new List<Item>();
            numTicket = 0;
        }

    }
}

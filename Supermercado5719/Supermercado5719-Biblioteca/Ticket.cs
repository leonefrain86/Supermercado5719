using System.Collections.Generic;

namespace Supermercado5719_Biblioteca
{
    public class Ticket
    {
        public int idTicket { get; set; }
        public int descripcionAbreviada { get; set; }
        public double preciTotal {get; set;}
        public List<Item> items { get; set; }

        public Ticket(string codigoBarra, int cantidad)
        {
            items.Add(new Item(codigoBarra, cantidad));
        }

    }
}

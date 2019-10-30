using System.Collections.Generic;

namespace Supermercado5719_Biblioteca
{
    public class Ticket
    {
        public int idTicket { get; set; }
        public List<Item> items { get; set; }

        public Ticket(string codigoBarra, int cantidad)
        {
            items.Add(new Item(codigoBarra, cantidad));
        }

    }
}

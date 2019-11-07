using System.Collections.Generic;

namespace Supermercado5719_Biblioteca
{
    public class Ticket
    {
        public int id { get; set; }
        public double preciTotal {get; set;}
        public List<Item> items { get; set; }

    }
}

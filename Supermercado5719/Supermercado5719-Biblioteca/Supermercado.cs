using System.Collections.Generic;

namespace Supermercado5719_Biblioteca
{
    public class Supermercado
    {
        public int id { get; set; }
        public Inventario inventario { get; set; }
        public List<Caja> cajas { get; set; }

    }
}

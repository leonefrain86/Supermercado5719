using System.Collections.Generic;

namespace Supermercado5719_Biblioteca
{
    public class Supermercado
    {
        public int idSupermercado { get; set; }
        public List<Caja> cajas { get; set; }

        public Supermercado( string codigoBarra, int cantidad)
        {
            this.idSupermercado = 1;
            this.cajas.Add(new Caja(1, codigoBarra, cantidad));
        }
    }
}

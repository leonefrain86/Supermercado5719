namespace Supermercado5719_Biblioteca
{
    public class Venta
    {
        public int numVenta { get; set; }
        public Caja caja { get; set; }
        public Ticket ticket { get; set; }

        public Venta(Caja caja,  string codigoBarra, int cantidad)
        {
            numVenta = 1;
            this.caja = caja;
            ticket = new Ticket(codigoBarra, cantidad);
        }
    }
}

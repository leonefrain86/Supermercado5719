namespace Supermercado5719_Biblioteca
{
    public class Venta
    {
        public int id { get; set; }
        public int numTicket { get; set; }
        public int numCaja { get; set; }
        public Ticket ticket { get; set; }

        public Venta()
        {
            numTicket = 0;
            numCaja = 0;
            ticket = new Ticket();
        }
    }
}

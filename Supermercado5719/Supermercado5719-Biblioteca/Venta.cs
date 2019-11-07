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
             
        }
    }
}

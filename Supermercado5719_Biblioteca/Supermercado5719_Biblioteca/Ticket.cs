using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace Supermercado5719_Biblioteca
{
    public class Ticket
    {
        public int idTicket { get; set; }
        public int codigoBarra { get; set; }
        public int cantidad { get; set; }

        public Ticket()
        {

        }

    }
}

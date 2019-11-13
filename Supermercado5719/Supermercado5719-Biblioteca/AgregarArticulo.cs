using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado5719_Biblioteca
{
    public class AgregarArticulo
    {
        public string codigoBarra { get; set; }
        public int unidades { get; set; }
        public int numTicket { get; set; }
        public int numCaja { get; set; }

        public AgregarArticulo(string codigoBarra, int unidades, int numTicket, int numCaja)
        {
            this.codigoBarra = codigoBarra;
            this.unidades = unidades;
            this.numTicket = numTicket;
            this.numCaja = numCaja;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermercado5719_Web.Models;
using Supermercado5719_Biblioteca;

namespace Supermercado5719_Web.Controllers
{
    public class VentaController : Controller
    {
        private readonly LiteDbContext db;
        public VentaController(LiteDbContext db)
        {
            this.db = db;
        }

        // Index
        [HttpGet]
        public IActionResult Index()
        {
            //LLamando a la base de datos principal
            var master = db.Context.GetCollection<Supermercado>("supermercado");
            var supermercado = master.FindAll().FirstOrDefault();

            //Elimino los ticket con lista de item vacios
            foreach (var caja in supermercado.cajas)
            {
                caja.tickets.RemoveAll(x => x.items.Count() == 0);
            }

            //Actualizo el db
            master.Update(supermercado);
            return View("Index", supermercado.cajas);
        }

        //Realizar Ventas
        [HttpGet]
        public IActionResult RealizarVenta()
        {
            return View("RealizarVenta");
        }

        [HttpPost]
        public IActionResult RealizarVenta(Ticket unTicket)
        {
            //LLamando a la base de datos principal
            var master = db.Context.GetCollection<Supermercado>("supermercado");
            var supermercado = master.FindAll().FirstOrDefault();

            //Incremento el numTicket automaticamente
            int numAuxTicket = supermercado.cajas.FirstOrDefault(x => x.numCaja == unTicket.numCaja).tickets.Count + 1;


            Ticket auxTicket = new Ticket() { numTicket = numAuxTicket, numCaja = unTicket.numCaja, items = new List<Item>(), precioTotal = 0 };
            //Instancio una nueva lista de ticket
            supermercado.cajas.FirstOrDefault(x => x.numCaja == unTicket.numCaja).tickets.Add(auxTicket);

                //new List<Ticket>{new Ticket{numTicket = numAuxTicket, numCaja = unTicket.numCaja, items = new List<Item>(), precioTotal = 0}};

            

            //Guardo el ticket
            ViewBag.ticket = supermercado.cajas.FirstOrDefault(x => x.numCaja == unTicket.numCaja).tickets.FirstOrDefault(y => y.numTicket == numAuxTicket);
            
            //Actualizo la db
            master.Update(supermercado);

            return View("AgregarArticulo");
        }

        //Agregar Articulo
        [HttpGet]
        public IActionResult AgregarArticulo()
        {
            return View("AgregarArticulo");
        }

        [HttpPost]
        public IActionResult AgregarArticulo(AgregarArticulo itemVendido)
        {
            //LLamando a la base de datos principal
            var master = db.Context.GetCollection<Supermercado>("supermercado");
            var supermercado = master.FindAll().FirstOrDefault();

            //Compruebo si existe el Articulo
            bool ExisteArticulo = supermercado.inventario.stockArticulos.
                Exists(x => x.articulo.codigoBarra == itemVendido.codigoBarra);
            if (ExisteArticulo == false)
                throw new Exception("No existe el articulo");

            //Obtengo el articulo
            var ArticuloVendido = supermercado.inventario.stockArticulos.
                FirstOrDefault(x => x.articulo.codigoBarra == itemVendido.codigoBarra);
            
            //Compruebo si hay sufiente stock
            if ((ArticuloVendido.stock - itemVendido.unidades) < 0)
                throw new Exception("Error, las unidades a vender son mayores al stock");

            //Resto las unidades vendidas al stock del articulo
            supermercado.inventario.stockArticulos.FirstOrDefault(x => x.articulo.codigoBarra == itemVendido.codigoBarra).
                stock = ArticuloVendido.stock - itemVendido.unidades;

            //LLeno de datos al nuevo item instanciado
            Item unItem = new Item();
            unItem.unidades = itemVendido.unidades;
            unItem.articulo = ArticuloVendido.articulo;
            unItem.precioSubtotal = itemVendido.unidades * ArticuloVendido.articulo.precio;

            //Agrego el item instanciado, a la lista de items
            supermercado.cajas.FirstOrDefault(x => x.numCaja == itemVendido.numCaja).tickets.
                FirstOrDefault(x => x.numTicket == itemVendido.numTicket).items.Add(unItem);
            
            // supermercado.cajas.FirstOrDefault(x => x.numCaja == itemVendido.numCaja).ventas.
            //     FirstOrDefault(x => x.numCaja == itemVendido.numCaja).ticket.items.Add(unItem);

            /*Obtengo el precio total del ticket*/
            var auxTicket = supermercado.cajas.FirstOrDefault(x => x.numCaja == itemVendido.numCaja).tickets.
                FirstOrDefault(x => x.numTicket == itemVendido.numTicket);

            supermercado.cajas.FirstOrDefault(x => x.numCaja == itemVendido.numCaja).tickets.
                FirstOrDefault(x => x.numTicket == itemVendido.numTicket).precioTotal =
                auxTicket.items.Sum(x => x.precioSubtotal);

            ViewBag.ticket = supermercado.cajas.FirstOrDefault(x => x.numCaja == itemVendido.numCaja).tickets.
                FirstOrDefault(x => x.numTicket == itemVendido.numTicket);

            master.Update(supermercado);

            //return RedirectToAction("AgregarArticulo");

            return View();
            
        }
    }
}
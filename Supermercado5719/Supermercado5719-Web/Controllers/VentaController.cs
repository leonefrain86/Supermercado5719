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

       [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //Realizar Ventas
        [HttpGet]
        public IActionResult RealizarVenta()
        {
            return View("RealizarVenta");
        }

        [HttpPost]
        public IActionResult RealizarVenta(Venta unaVenta)
        {
            var ventas = db.Context.GetCollection<Venta>("supermercado");

            ventas.Insert(unaVenta);
            
            return RedirectToAction("Index");
        }

        //Agregar Articulo
        [HttpGet]
        public IActionResult AgregarArticulo(int NumCaja, int NumTicket)
        {
            var ventas = db.Context.GetCollection<Venta>("supermercado").FindAll();
            var venta = ventas.FirstOrDefault(x => x.numCaja == NumCaja && x.numTicket == NumTicket);
            ViewBag.NumCaja = NumCaja;
            ViewBag.NumTicket = NumTicket;
            return RedirectToAction("AgregarArticulo", venta);
        }

        [HttpPost]
        public IActionResult AgregarArticulo(int NumCaja, int NumTicket, string codigoBarra, int unidades)
        {
            var ventas = db.Context.GetCollection<Venta>("supermercado").FindAll();

            var venta = ventas.FirstOrDefault(x => x.numCaja == NumCaja && x.numTicket == NumTicket);

            var articulos = db.Context.GetCollection<Articulo>("articulos").FindAll();

            var nuevoArt = articulos.FirstOrDefault(x => x.codigoBarra == codigoBarra);
            
            venta.ticket.items.Add(new Item { articulo = nuevoArt, cantidad = unidades, precioSubtotal = unidades*nuevoArt.precio});
            
            return RedirectToAction("RealizarVenta");
        }
    }
}
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
        public IActionResult RealizarVenta(Venta venta)
        {
            var ventas = db.Context.GetCollection<Venta>("supermercado");
            ventas.Insert(venta);
            return RedirectToAction("Index", ventas.FindAll());
        }
    }
}
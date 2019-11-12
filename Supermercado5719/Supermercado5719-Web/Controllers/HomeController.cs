using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermercado5719_Web.Models;
using Supermercado5719_Biblioteca;

namespace Supermercado5719_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly LiteDbContext db;
        public HomeController(LiteDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var master = db.Context.GetCollection<Supermercado>("supermercado");

            var supermercado = new Supermercado()
            {
                cajas = new List<Caja>() { new Caja { numCaja = 1, ventas = new List<Venta>() },
                                           new Caja { numCaja = 2, ventas = new List<Venta>() },
                                           new Caja { numCaja = 3, ventas = new List<Venta>() },
                                           new Caja { numCaja = 4, ventas = new List<Venta>() },
                                           new Caja { numCaja = 5, ventas = new List<Venta>() } },
                inventario = new Inventario()
            };

            master.Insert(supermercado);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

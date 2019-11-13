using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Supermercado5719_Biblioteca;
using Supermercado5719_Web.Models;

namespace Supermercado5719_Web.Controllers
{
    public class CajaController : Controller
    {
        private readonly LiteDbContext db;
        public CajaController(LiteDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //LLamando a la base de datos principal
            var master = db.Context.GetCollection<Supermercado>("supermercado");
            var supermercado = master.FindAll().FirstOrDefault();
            //

            return View("Index", supermercado.cajas);
        }
    }
}
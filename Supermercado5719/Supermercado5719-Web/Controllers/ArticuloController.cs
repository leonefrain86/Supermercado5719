using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermercado5719_Biblioteca;

namespace Supermercado5719_Web.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly object LiteDbContext db;

        public ArticuloController(LiteDBContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var articulos = db.CollecGetCollections<Articulo>();
        }
    }
}
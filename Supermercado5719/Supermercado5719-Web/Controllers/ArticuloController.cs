using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermercado5719_Web.Models;

namespace Supermercado5719_Web.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly LiteDbContext db;
        public ArticuloController(LiteDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
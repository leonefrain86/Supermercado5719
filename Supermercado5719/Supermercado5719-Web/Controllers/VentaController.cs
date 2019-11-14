﻿using System;
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
            //

            foreach (var caja in supermercado.cajas)
            {
                caja.ventas.RemoveAll(x => x.ticket.items.Count() == 0);
            }

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
        public IActionResult RealizarVenta(Venta unaVenta)
        {
            //LLamando a la base de datos principal
            var master = db.Context.GetCollection<Supermercado>("supermercado");
            var supermercado = master.FindAll().FirstOrDefault();
            //

            supermercado.cajas.FirstOrDefault(x => x.numCaja == unaVenta.numCaja).ventas.Add(unaVenta);

            master.Update(supermercado);

            ViewBag.venta = unaVenta;

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
            //

            //Compruevo si existe el Articulo
            bool ExisteArticulo = supermercado.inventario.stockArticulos.Exists(x => x.articulo.codigoBarra == itemVendido.codigoBarra);
            if (ExisteArticulo == false)
                throw new Exception("No existe el articulo");
            var ArticuloVendido = supermercado.inventario.stockArticulos.FirstOrDefault(x => x.articulo.codigoBarra == itemVendido.codigoBarra);
            

            //Resto las unidades vendidas
            if ((ArticuloVendido.stock - itemVendido.unidades) < 0)
                throw new Exception("Error, las unidades a vender son mayores al stock");
            supermercado.inventario.stockArticulos.FirstOrDefault(x => x.articulo.codigoBarra == itemVendido.codigoBarra).
                stock = ArticuloVendido.stock - itemVendido.unidades;

            //LLeno de datos el nuevo item instanciado
            Item unItem = new Item();
            unItem.unidades = itemVendido.unidades;
            unItem.articulo = ArticuloVendido.articulo;
            unItem.precioSubtotal = itemVendido.unidades * ArticuloVendido.articulo.precio;

            //Agrego el item instanciado, a la lista de items
            supermercado.cajas.FirstOrDefault(x => x.numCaja == itemVendido.numCaja).ventas.
                FirstOrDefault(x => x.numCaja == itemVendido.numCaja).ticket.items.Add(unItem);

            //Obtengo el precio total del tiket
            var itemsVendidos = supermercado.cajas.FirstOrDefault(x => x.numCaja == itemVendido.numCaja).ventas.
                FirstOrDefault(x => x.numCaja == itemVendido.numCaja).ticket;
            supermercado.cajas.FirstOrDefault(x => x.numCaja == itemVendido.numCaja).ventas.
                FirstOrDefault(x => x.numCaja == itemVendido.numCaja).ticket.precioTotal = itemsVendidos.items.Sum(x => x.precioSubtotal);

            

            master.Update(supermercado);
        
            return RedirectToAction("AgregarArticulo");
        }
    }
}
# Supermercado5719

## Correcciones 

### Controllers

Articulo: Ok

Caja: Ok

Venta: 

- Mejorar las querys, son demasiado complejas. Se pueden simplificar ya sea utilizando las querys nativas de LiteDb o con LinQ
- Para probar integralmente todo, se debe borrar el archivo **supermercado.db** y crear **articulos** y **ventas** nuevos
- Al crear una nueva venta, hay un error porque no se crea un objeto **Ticket** y no se carga apropiadamente el objecto **unaVenta**

```C#
[HttpPost]
public IActionResult RealizarVenta(Venta unaVenta)
{
    //LLamando a la base de datos principal
    var master = db.Context.GetCollection<Supermercado>("supermercado");
    var supermercado = master.FindAll().FirstOrDefault();

    bool ExisteVenta = supermercado.cajas.Any(x => x.numCaja == unaVenta.numCaja);
    if (ExisteVenta == true) // Si la caja existe, agrego una venta a la misma
    {
        var cajaVenta = supermercado.cajas.FirstOrDefault(x => x.numCaja == unaVenta.numCaja);
        var ticket = new Ticket();
        ticket.numTicket = cajaVenta.ventas.Count + 1;
        var nuevaVenta = new Venta();
        nuevaVenta.numCaja = unaVenta.numCaja;
        nuevaVenta.numTicket = unaVenta.numTicket;
        nuevaVenta.ticket = ticket;
        cajaVenta.ventas.Add(nuevaVenta);
    }
    else // si la caja no existe lanzo una excepcion
    {
        throw new Exception("La caja ingresada no existe");
    }
    master.Update(supermercado);

    ViewBag.venta = supermercado.cajas.FirstOrDefault(x => x.numCaja == unaVenta.numCaja).ventas.FirstOrDefault(x => x.numCaja == unaVenta.numCaja);

    return View("AgregarArticulo");
}

```

using PracticasJavascriptyAjax.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticasJavascriptyAjax.Controllers
{
    public class APIProductoController : Controller
    {
        // GET: APIProducto
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Producto

        public ActionResult getJsonList()
        {

            var productos = db.producto.ToList();
            return Json(productos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult createProducto(Producto producto)
        {
            var respuesta = new { funciono = true };
            try
            {
                db.producto.Add(producto);
                int registrosModificados = db.SaveChanges();
                //se logro ejecutar el query, pero, se hicieron cambios?
                if (registrosModificados > 0)
                {
                    respuesta = new { funciono = true };

                }
            }
            catch { }
            return Json(respuesta);
        }
        [HttpPost]
        public JsonResult borrarProducto(int id)
        {
            var respuesta = new { funciono = false };
            try
            {
                Producto producto = db.producto.Find(id);
                db.producto.Remove(producto);
                int registrosModificados = db.SaveChanges();
                if (registrosModificados > 0)
                {
                    respuesta = new { funciono = true };

                }
            }
            catch
            {
            }
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }
        public JsonResult editarProducto(int id)
        {
            var productoaEditar = db.producto.Find(id);

            var respuesta = new { id = productoaEditar.productoID, nombre = productoaEditar.nombre, precio = productoaEditar.precio };
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult editar(Producto producto)

        {

            var resultado = db.Entry(producto).State = EntityState.Modified;
            db.SaveChanges();

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }
    }
}
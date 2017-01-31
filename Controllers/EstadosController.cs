using PracticasJavascriptyAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticasJavascriptyAjax.Controllers
{
    public class EstadosController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Estados
        public JsonResult Index()
        {
            var estados = from est in db.estado
                          select new { estadoID = est.estadoID, nombreEstado = est.nombreEstado };
            var estado = estados.ToList();
            return Json(estado, JsonRequestBehavior.AllowGet);
        }

       
        public JsonResult Municipios(int id)
        {
            var listaMunicipio = db.municipio.Where(a => a.estadoID == id);
            var Municipios = from este in listaMunicipio
                             select new { municipioID = este.municipioID, nombreMunicipio = este.nombreMunicipio };
            var municipio = Municipios.ToList();

            return Json(municipio, JsonRequestBehavior.AllowGet);
        }
    }
}
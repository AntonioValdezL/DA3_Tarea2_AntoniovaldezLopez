using PracticasJavascriptyAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticasJavascriptyAjax.Controllers
{
    public class EspCompuController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: EspCompu
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult EspecificacionesCompu(int? id)
        {
            if (id == null)
            {
                var especificaciones = db.partesdeCompu.ToList();
                return Json(especificaciones, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var especificaciones = db.partesdeCompu.Find(id);
                return Json(especificaciones, JsonRequestBehavior.AllowGet);
            }


        }
    }
}
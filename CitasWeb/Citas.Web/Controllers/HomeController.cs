using Admon.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Citas.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var pacientesBL = new PacientesBL();
            var listaPacientes = pacientesBL.ObtenerPacienteActivos();


            ViewBag.adminWebsiteUrl = 
                ConfigurationManager.AppSettings["adminWebsiteUrl"];

            return View(listaPacientes);
        }
    }
}
using Admon.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionarCitas.WebAdmin.Controllers
{
    public class PacientesController : Controller
    {
        PacientesBL _pacientesBL;
        CategoriasBL _categoriasBL;
        CitasBL _citasBL;

        public PacientesController()
        {
            _pacientesBL = new PacientesBL();
            _categoriasBL = new CategoriasBL();
            _citasBL = new CitasBL();
        }
        // GET: Pacientes
        public ActionResult Index()
        {
            var listadePacientes = _pacientesBL.ObtenerPaciente();
            
            return View(listadePacientes);
        }
        
        public ActionResult Crear()
        {
            var nuevoPaciente = new Paciente();
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.ListaCategorias = 
                new SelectList(categorias, "Id", "Descripcion");

            return View(nuevoPaciente);
        }

        [HttpPost]
        public ActionResult Crear (Paciente paciente, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (paciente.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una Categoria");
                    return View(paciente);
                }

                if (imagen != null)
                {
                    paciente.UrlImagen = GuardarImagen(imagen);
                }
                _pacientesBL.GuardarPaciente(paciente);

                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new 
                SelectList(categorias, "Id", "Descripcion");

            return View(paciente);
        }

        public ActionResult Editar(int id)
        {
            var paciente = _pacientesBL.ObtenerPaciente(id);
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", paciente.CategoriaId);

            return View(paciente);
        }

        [HttpPost]
        public ActionResult Editar(Paciente paciente, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (paciente.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una Categoria");
                    return View(paciente);
                }

                if (imagen != null)
                {
                    paciente.UrlImagen = GuardarImagen(imagen);
                }

                _pacientesBL.GuardarPaciente(paciente);

                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new
                SelectList(categorias, "Id", "Descripcion");

            return View(paciente);
        }

        public ActionResult Detalle(int id)
        {
            var paciente = _pacientesBL.ObtenerPaciente(id);

            return View(paciente);
        }

        public ActionResult Eliminar(int id)
        {
            var paciente = _pacientesBL.ObtenerPaciente(id);

            return View(paciente);
        }

        [HttpPost]
        public ActionResult Eliminar(Paciente paciente)
        {
            _pacientesBL.EliminarPaciente(paciente.Id);

            return RedirectToAction("Index");
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;
        }
    }
}
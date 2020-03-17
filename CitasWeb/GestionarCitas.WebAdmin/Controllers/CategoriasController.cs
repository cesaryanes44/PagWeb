using Admon.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionarCitas.WebAdmin.Controllers
{
    public class CategoriasController : Controller
    {
        CategoriasBL _categoriasBL;

        public CategoriasController()
        {
            _categoriasBL = new CategoriasBL();
        }
        // GET: Categorias
        public ActionResult Index()
        {
            var listadeCategorias = _categoriasBL.ObtenerCategorias();

            return View(listadeCategorias);
        }

        public ActionResult Crear()
        {
            var nuevaCategoria = new Categoria();

            return View(nuevaCategoria);
        }

        [HttpPost]
            public ActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim()) //Trim quita espacio adelante y atras.
                {
                    ModelState.AddModelError("Descripcion", "La descripcion no debe contener espacio al principio y final");
                    return View(categoria);
                }
                _categoriasBL.GuardarCategoria(categoria);

                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public ActionResult Editar(int id)
        {
            var paciente = _categoriasBL.ObtenerCategorias(id);

            return View(paciente);
        }

        [HttpPost]
        public ActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim()) //trim quita espacio adelante y atras.
                {
                    ModelState.AddModelError("Descripcion", "La descripcion no debe contener espacio al principio y final");
                    return View(categoria);
                }
                _categoriasBL.GuardarCategoria(categoria);

                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public ActionResult Detalle(int id)
        {
            var paciente = _categoriasBL.ObtenerCategorias(id);

            return View(paciente);
        }

        public ActionResult Eliminar(int id)
        {
            var paciente = _categoriasBL.ObtenerCategorias(id);

            return View(paciente);
        }

        [HttpPost]
        public ActionResult Eliminar(Categoria paciente)
        {
            _categoriasBL.EliminarCategorias(paciente.Id);

            return RedirectToAction("Index");
        }
    }
}
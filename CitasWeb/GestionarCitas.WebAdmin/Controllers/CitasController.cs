using Admon.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionarCitas.WebAdmin.Controllers
{
    public class CitasController : Controller
    {
        CitasBL _citasBL;
        PacientesBL _pacientesBL;

        public CitasController()
        {
            _citasBL = new CitasBL();
            _pacientesBL = new PacientesBL();
        }

        // GET: Citas
        public ActionResult Index()
        {
            var listadeCitas = _citasBL.ObtenerCitas();

            return View(listadeCitas);
        }

        public ActionResult Crear()
        {
            var nuevaCita = new Cita();
            var pacientes = _pacientesBL.ObtenerPaciente();

            ViewBag.PacienteId = new SelectList(pacientes, "Id", "Nombre");

            return View(nuevaCita);
        }

        [HttpPost]
        public ActionResult Crear(Cita cita)
        {
            if (ModelState.IsValid)
            {
                if (cita.PacienteId == 0)
                {
                    ModelState.AddModelError("PacienteId", "Selecione un Paciente");
                    return View(cita);
                }

                _citasBL.GuardarCita(cita);

                return RedirectToAction("Index");
            }
            var pacientes = _pacientesBL.ObtenerPaciente();

            ViewBag.PacienteId = new SelectList(pacientes, "Id", "Nombre");

            return View(cita);
        }

        public ActionResult Editar(int id)
        {
            var cita = _citasBL.ObtenerCita(id);
            var pacientes = _pacientesBL.ObtenerPaciente();

            ViewBag.PacienteId = new SelectList(pacientes, "Id", "Nombre", cita.PacienteId);

                return View(cita);
        }

        [HttpPost]
        public ActionResult Editar(Cita cita)
        {
            if (ModelState.IsValid)
            {
                if (cita.PacienteId == 0)
                {
                    ModelState.AddModelError("PacienteId", "Sellecione un Pacinete");
                    return View(cita);
                }

                _citasBL.GuardarCita(cita);

                return RedirectToAction("Index");
            }

            var pacientes = _pacientesBL.ObtenerPaciente();

            ViewBag.PacienteId = new SelectList(pacientes, "Id", "Nombre", cita.PacienteId);

            return View(cita);
        }

        public ActionResult Detalle(int id)
        {
            var cita = _citasBL.ObtenerCita(id);

            return View(cita);
        }

        public ActionResult Eliminar(int id)
        {
            var cita = _citasBL.ObtenerCita(id);

            return View(cita);
        }

        [HttpPost]
        public ActionResult Eliminar(Cita cita)
        {
            _citasBL.EliminarCita(cita.Id);

            return RedirectToAction("Index", new { id = cita.Id });
        }
    }
}
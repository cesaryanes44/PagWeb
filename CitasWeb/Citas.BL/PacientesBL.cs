using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admon.BL
{
    public class PacientesBL
    {
        Contexto _contexto;
        public List<Paciente> ListadePacientes { get; set; }

        public PacientesBL()
        {
            _contexto = new Contexto();
            ListadePacientes = new List<Paciente>();
        }

        public List<Paciente> ObtenerPaciente()
        {
            ListadePacientes = _contexto.Pacientes
                .Include("Categoria")
                .OrderBy(r => r.Nombre)
                .ThenBy(r => r.Categoria)
                .ToList();

            return ListadePacientes;
        }

        public List<Paciente> ObtenerPacienteActivos()
        {
            ListadePacientes = _contexto.Pacientes
                .Include("Categoria")
                .Where(paciente => paciente.Activo == true)
                .OrderBy(r => r.Nombre) 
                .ToList();

            return ListadePacientes;
        }

        public void GuardarPaciente(Paciente paciente)
        {
            if(paciente.Id == 0)
            {
                _contexto.Pacientes.Add(paciente);
            }
            else
            {
                var pacienteExistente = _contexto.Pacientes.Find(paciente.Id);
                pacienteExistente.Nombre = paciente.Nombre;
                pacienteExistente.Direccion = paciente.Direccion;
                pacienteExistente.Telefono = paciente.Telefono;
                pacienteExistente.FechaNacimiento = paciente.FechaNacimiento;
                pacienteExistente.UrlImagen = paciente.UrlImagen;
            }
             _contexto.SaveChanges();
        }

        public Paciente ObtenerPaciente(int id)
        {
            var paciente = _contexto.Pacientes
                .Include("Categoria").FirstOrDefault(p => p.Id == id);
            
            return paciente;
        }

        public void EliminarPaciente(int id)
        {
            var paciente = _contexto.Pacientes.Find(id);

            _contexto.Pacientes.Remove(paciente);
            _contexto.SaveChanges();
        }
    }
}

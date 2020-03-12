using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admon.BL
{
    public class CitasBL
    {
        Contexto _contexto;
        public List<Cita> ListadeCitas { get; set; }

        public CitasBL()
        {
            _contexto = new Contexto();
            ListadeCitas = new List<Cita>();
        }

        public List<Cita> ObtenerCitas()
        {
            ListadeCitas = _contexto.Citas
                .Include("Paciente")
                .ToList();

            return ListadeCitas;
        }

        public Cita ObtenerCita(int id)
        {
            return _contexto.Citas.Include("Paciente").FirstOrDefault(r => r.Id == id);
        }

        public void GuardarCita(Cita cita)
        {
            if (cita.Id == 0)
            {
                _contexto.Citas.Add(cita);
            }
            else
            {
                var citaExistente = _contexto.Citas.Find(cita.Id);
                citaExistente.PacienteId = cita.PacienteId;
                citaExistente.Activo = cita.Activo;
            }

            _contexto.SaveChanges();
        }

        public void EliminarCita(int id)
        {
            var cita = _contexto.Citas.Find(id);
            _contexto.Citas.Remove(cita);

            _contexto.SaveChanges();
        }
    }

}

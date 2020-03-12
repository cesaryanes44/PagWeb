using Admon.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admon.BL
{
    public class Cita
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }

        public Cita()
        {
            Activo = true;
            Fecha = DateTime.Now;

        }
    }
}

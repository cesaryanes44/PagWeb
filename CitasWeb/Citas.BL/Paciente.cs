using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admon.BL
{
    public class Paciente
    {
        public Paciente()
        {
            Activo = true;
        }

        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Ingrese el Nombre del paciente")]
        [MinLength (4, ErrorMessage = "Ingrese minimo 4 caracteres")]
        [MaxLength (30, ErrorMessage = "Maximo 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese un Numero de Telefono")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "Ingrese una Direccion")]
        public string Direccion { get; set; }

        internal int Sum(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        [Required(ErrorMessage = "Ingrese una Fecha de Nacimiento")]
        public string FechaNacimiento { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }

        public bool Activo { get; set; }
        public object Pacientes { get; internal set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admon.BL
{
   public  class DatosInicio: CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var nuevoUsuario = new Usuario1();
            nuevoUsuario.Nombre = "Cesar";
            nuevoUsuario.Contrasena = Encriptar.codificarContrasena("yanes");

            var nuevoUsuario2 = new Usuario1();
            nuevoUsuario2.Nombre = "Evelin";
            nuevoUsuario2.Contrasena = Encriptar.codificarContrasena("mejia");


            contexto.Usuarios.Add(nuevoUsuario);
            contexto.Usuarios.Add(nuevoUsuario2);

            base.Seed(contexto);
        }
    }
}

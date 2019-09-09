using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos.Entidades;
namespace Negocio.Clases
{
    public class UsuarioCollection
    {
        public DataTable IniciarSesion(string correo, string pass)
        {
            return new Usuario().IniciarSesion(correo,pass);
        }
    }
}

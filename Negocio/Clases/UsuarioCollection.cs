using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos.Entidades;
namespace Negocio.Clases
{
    public class UsuarioCollection
    {
        //Metodo para iniciar sesion de usuario.
        public DataTable IniciarSesion(string correo, string pass)
        {
            return new Usuario().IniciarSesion(correo,pass);
        }

        //Metodo que muestra Funcionarios guardados en la base de datos.
        public DataTable ListaFuncionarios()
        {
            return new Persona().ListaFuncionarios();
        }

        //Metodo que valida que exista usuario en la base de datos. 
        public DataTable ValidaExistencia(string correo)
        {
            return new Usuario().ValidaExistencia(correo);
        }

        //Metodo que inserta datos de un nuevo Usuario hacia la base de datos.
        public bool InsertaUsuario(string correo, string pass, int perfil)
        {
            Usuario us = new Usuario();
            us.Correo = correo;
            us.Contrasena = pass;
            us.Perfil = perfil;
            return us.Crear(us);

        }

        //Metodo que inserta datos de una nueva Persona hacia la base de datos.
        public bool InsertaDatos(string rut, string nombre, string apepa, string apema,string contacto, DateTime fecha, string direccion,int id_usuario)
        {
            Persona per = new Persona();
            per.Rut = rut;
            per.Nombre = nombre;
            per.ApellidoPa = apepa;
            per.Apellido_Ma = apema;
            per.Contacto = contacto;
            per.FechaNac = fecha;
            per.Direccion = direccion;
            per.IdUsuario = id_usuario;

            return per.Crear(per);
        }

        //Metodo que actualiza los datos de un Usuario existente en la base de datos.
        public bool ActualizaUsuario(int id_usuario, string correo, string pass)
        {
            Usuario us = new Usuario();
            us.Id = id_usuario;
            us.Correo = correo;
            us.Contrasena = pass;
            return us.Actualizar(us);
        }

        //Metodo que actualiza los datos de una Persona existente en la base de datos.
        public bool ActualizaDatos(int id_usuario, string contacto, string direccion)
        {
            Persona per = new Persona();
            per.IdUsuario = id_usuario;
            per.Contacto = contacto;
            per.Direccion = direccion;
            return per.Actualizar(per);
        }

        //Metodo que elimina un Usuario almacenado en la base de datos.
        public bool EliminaUsuario(int id_usuario)
        {
            Usuario us = new Usuario();
            us.Id = id_usuario;
            return us.Eliminar(us);
        }

        //Metodo que elimina una Persona almacenada en la base de datos.
        public bool EliminaDatos(int id_usuario)
        {
            Persona per = new Persona();
            per.IdUsuario = id_usuario;
            return per.Eliminar(per);
        }
    }
}

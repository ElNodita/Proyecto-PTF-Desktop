using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Datos.Entidades
{
    public class Persona
    {
        //Atributos de la clase.
        private int _idDatos;
        private string _rut;
        private string _nombre;
        private string _apellidoPa;
        private string _apellido_Ma;
        private string _contacto;
        private DateTime _fechaNac;
        private string _direccion;
        private int _idUsuario;

        //Getters y Setters de los atributos.
        public int IdDatos { get => _idDatos; set => _idDatos = value; }
        public string Rut { get => _rut; set => _rut = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string ApellidoPa { get => _apellidoPa; set => _apellidoPa = value; }
        public string Apellido_Ma { get => _apellido_Ma; set => _apellido_Ma = value; }
        public string Contacto { get => _contacto; set => _contacto = value; }
        public DateTime FechaNac { get => _fechaNac; set => _fechaNac = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }

        //Constructor de la clase.
        public Persona()
        {
            Init();
        }

        //Metodo para generar inicialmente los atributos en estado "vacio".
        public void Init()
        {
            this.IdDatos = 0;
            this.Rut = string.Empty;
            this.Nombre = string.Empty;
            this.ApellidoPa = string.Empty;
            this.Apellido_Ma = string.Empty;
            this.Contacto = string.Empty ;
            this.FechaNac = DateTime.Now;
            this.Direccion = string.Empty;
            this.IdUsuario = 0;
        }

        #region CRUD

        //Metodo para listar los Funcionarios guardados.
        public DataTable ListaFuncionarios()
        {
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_funcionario.sp_lstFuncionarios";
                _sql.Parameters.Add("o_data",OracleDbType.RefCursor).Direction=ParameterDirection.Output;

                return Enlace.RegresaDatos(_sql);

            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }

        //Metodo para agregar una nueva Persona.
        public bool Crear (Persona persona)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_comun.sp_insertaDatosPersona";

                OracleParameter rut = _sql.CreateParameter();
                rut.ParameterName = "rut";
                rut.Value = persona.Rut;
                rut.OracleDbType = OracleDbType.Varchar2;
                rut.Size = 10;
                _sql.Parameters.Add(rut);

                OracleParameter nombre = _sql.CreateParameter();
                nombre.ParameterName = "nombre";
                nombre.Value = persona.Nombre;
                nombre.OracleDbType = OracleDbType.Varchar2;
                nombre.Size = 100;
                _sql.Parameters.Add(nombre);

                OracleParameter apellidopa = _sql.CreateParameter();
                apellidopa.ParameterName = "apePa";
                apellidopa.Value = persona.ApellidoPa;
                apellidopa.OracleDbType = OracleDbType.Varchar2;
                apellidopa.Size = 100;
                _sql.Parameters.Add(apellidopa);

                OracleParameter apellidoma = _sql.CreateParameter();
                apellidoma.ParameterName = "apeMa";
                apellidoma.Value = persona.Apellido_Ma;
                apellidoma.OracleDbType = OracleDbType.Varchar2;
                apellidoma.Size = 100;
                _sql.Parameters.Add(apellidoma);

                OracleParameter fono = _sql.CreateParameter();
                fono.ParameterName = "contacto";
                fono.Value = persona.Contacto;
                fono.OracleDbType = OracleDbType.Varchar2;
                fono.Size = 15;
                _sql.Parameters.Add(fono);

                OracleParameter fecha = _sql.CreateParameter();
                fecha.ParameterName = "fecha";
                fecha.Value = persona.FechaNac;
                fecha.OracleDbType = OracleDbType.Date;
                _sql.Parameters.Add(fecha);

                OracleParameter direccion = _sql.CreateParameter();
                direccion.ParameterName = "direccion";
                direccion.Value = persona.Direccion;
                direccion.OracleDbType = OracleDbType.Varchar2;
                direccion.Size = 100;
                _sql.Parameters.Add(direccion);

                OracleParameter id_usuario = _sql.CreateParameter();
                id_usuario.ParameterName = "idUsuario";
                id_usuario.Value = persona.IdUsuario;
                id_usuario.OracleDbType = OracleDbType.Int64;
                id_usuario.Size = 6;
                _sql.Parameters.Add(id_usuario);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;

            }
            catch(OracleException ex)
            {
                throw ex;
            }

            return resultado;

        }

        //Metodo para actualizar datos de una Persona agregada anteriormente.
        public bool Actualizar(Persona persona)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_funcionario.sp_actualizaDatosPersona";

                OracleParameter id_usuario = _sql.CreateParameter();
                id_usuario.ParameterName = "idUs";
                id_usuario.Value = persona.IdUsuario;
                id_usuario.OracleDbType = OracleDbType.Int64;
                id_usuario.Size = 6;
                _sql.Parameters.Add(id_usuario);

                OracleParameter direccion = _sql.CreateParameter();
                direccion.ParameterName = "direccion";
                direccion.Value = persona.Direccion;
                direccion.OracleDbType = OracleDbType.Varchar2;
                direccion.Size = 100;
                _sql.Parameters.Add(direccion);

                OracleParameter contacto = _sql.CreateParameter();
                contacto.ParameterName = "contacto";
                contacto.Value = persona.Contacto;
                contacto.OracleDbType = OracleDbType.Varchar2;
                contacto.Size = 100;
                _sql.Parameters.Add(contacto);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            return resultado;
        }

        //Metodo para eliminar Persona existente.
        public bool Eliminar(Persona persona)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_funcionario.sp_eliminaDatosPersona";

                OracleParameter id = _sql.CreateParameter();
                id.ParameterName = "idUs";
                id.Value = persona.IdUsuario;
                id.OracleDbType = OracleDbType.Int64;
                _sql.Parameters.Add(id);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            return resultado;
        }

        #endregion CRUD

    }
}

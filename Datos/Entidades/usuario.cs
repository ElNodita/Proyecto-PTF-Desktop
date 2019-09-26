using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace Datos.Entidades
{
    public class Usuario
    {
        int _id;
        string _correo;
        string _contrasena;
        string _estado;
        int _perfil;

        public int Id { get => _id; set => _id = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public int Perfil { get => _perfil; set => _perfil = value; }

        public Usuario()
        {
            Init();
        }

        public void Init()
        {
            this.Id = 0;
            this.Correo = string.Empty;
            this.Contrasena= string.Empty;
            this.Estado= string.Empty;
            this.Perfil = 0;
        }


        #region CRUD

        //Método para iniciar sesión al sistema.
        public DataTable IniciarSesion(string correo, string contrasena)
        {
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_administrador.sp_loginAdministrador";

                _sql.Parameters.Add("o_data",OracleDbType.RefCursor).Direction=ParameterDirection.Output;

                OracleParameter mail = _sql.CreateParameter();
                mail.ParameterName = "correo";
                mail.Value = correo;
                mail.OracleDbType = OracleDbType.Varchar2;
                _sql.Parameters.Add(mail);

                OracleParameter pass = _sql.CreateParameter();
                pass.ParameterName = "pass";
                pass.Value = contrasena;
                pass.OracleDbType = OracleDbType.Varchar2;
                _sql.Parameters.Add(pass);

                return Enlace.RegresaDatos(_sql);
            }
            catch (OracleException ex)
            {
                throw ex;
            }

        }

        public DataTable ValidaExistencia(string correo)
        {
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_comun.sp_validaExistencia";
                _sql.Parameters.Add("o_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleParameter mail = _sql.CreateParameter();
                mail.ParameterName = "correo";
                mail.Value = correo;
                mail.OracleDbType = OracleDbType.Varchar2;
                _sql.Parameters.Add(mail);

                return Enlace.RegresaDatos(_sql);
            }
            catch(OracleException ex)
            {
                throw ex;
            }
        }

        public bool Crear(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_comun.sp_insertaUsuario";

                OracleParameter param = _sql.CreateParameter();
                param.ParameterName = "correo";
                param.Value = usuario.Correo;
                param.OracleDbType = OracleDbType.Varchar2;
                param.Size = 100;
                _sql.Parameters.Add(param);

                OracleParameter password = _sql.CreateParameter();
                password.ParameterName = "pass";
                password.Value = usuario.Contrasena;
                password.OracleDbType = OracleDbType.Varchar2;
                password.Size = 100;
                _sql.Parameters.Add(password);

                OracleParameter perf = _sql.CreateParameter();
                perf.ParameterName = "perfil";
                perf.Value = usuario.Perfil;
                perf.OracleDbType = OracleDbType.Int64;
                perf.Size = 6;
                _sql.Parameters.Add(perf);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;
            }
            catch (OracleException ex)
            {
                throw ex;
            }

            return resultado;
        }

        public bool Actualizar(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_funcionario.sp_actualizaUsuario";

                OracleParameter id_usuario = _sql.CreateParameter();
                id_usuario.ParameterName = "idUs";
                id_usuario.Value = usuario.Id;
                id_usuario.OracleDbType = OracleDbType.Int64;
                id_usuario.Size = 6;
                _sql.Parameters.Add(id_usuario);

                OracleParameter correo = _sql.CreateParameter();
                correo.ParameterName = "correo";
                correo.Value = usuario.Correo;
                correo.OracleDbType = OracleDbType.Varchar2;
                correo.Size = 100;
                _sql.Parameters.Add(correo);

                OracleParameter password = _sql.CreateParameter();
                password.ParameterName = "pass";
                password.Value = usuario.Contrasena;
                password.OracleDbType = OracleDbType.Varchar2;
                password.Size = 100;
                _sql.Parameters.Add(password);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;


            }catch(OracleException ex)
            {
                throw ex;
            }
            return resultado;
        }

        public bool Eliminar(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_funcionario.sp_eliminaUsuario";

                OracleParameter id = _sql.CreateParameter();
                id.ParameterName = "idUs";
                id.Value = usuario.Id;
                id.OracleDbType = OracleDbType.Int64;
                _sql.Parameters.Add(id);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;
            }catch(OracleException ex)
            {
                throw ex;
            }
            return resultado;
        }

        
        #endregion CRUD
    }
}

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
                _sql.CommandText = "sp_loginAdministrador";

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

        //public DataTable Read()
        //{
        //    try
        //    {
        //        OracleCommand _sql = new OracleCommand();
        //        _sql.CommandText = "";
        //        return Enlace.RegresaDatos(_sql);
        //    }
        //    catch( Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion CRUD
    }
}

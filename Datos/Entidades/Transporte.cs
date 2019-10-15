using System;
using System.Collections.Generic;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Datos.Entidades
{
    public class Transporte
    {
        private int _idTransporte;
        private string _nombreConductor;
        private string _patente;
        private int _idServicio;

        public int IdTransporte { get => _idTransporte; set => _idTransporte = value; }
        public string NombreConductor { get => _nombreConductor; set => _nombreConductor = value; }
        public string Patente { get => _patente; set => _patente = value; }
        public int IdServicio { get => _idServicio; set => _idServicio = value; }

        public Transporte()
        {
            Init();
        }

        public void Init()
        {
            this.IdTransporte = 0;
            this.NombreConductor = string.Empty;
            this.Patente = string.Empty;
            this.IdServicio = 0;
        }

        #region CRUD

        public DataTable ListaTransporte()
        {
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_servicios.sp_lstTransporte";
                _sql.Parameters.Add("o_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                return Enlace.RegresaDatos(_sql);

            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }

        public bool Crear (Transporte transporte)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_servicios.sp_insertaTransporte";

                OracleParameter conductor = _sql.CreateParameter();
                conductor.ParameterName = "nombreConductor";
                conductor.Value = transporte.NombreConductor;
                conductor.OracleDbType = OracleDbType.Varchar2;
                conductor.Size = 100;
                _sql.Parameters.Add(conductor);

                OracleParameter patente = _sql.CreateParameter();
                patente.ParameterName = "patente";
                patente.Value = transporte.Patente;
                patente.OracleDbType = OracleDbType.Varchar2;
                patente.Size = 8;
                _sql.Parameters.Add(patente);

                OracleParameter idservicio = _sql.CreateParameter();
                idservicio.ParameterName = "idServicio";
                idservicio.Value = transporte.IdServicio;
                idservicio.OracleDbType = OracleDbType.Int64;
                idservicio.Size = 3;
                _sql.Parameters.Add(idservicio);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;
            }
            catch(OracleException ex)
            {
                throw ex;
            }
            return resultado;
        }

        public bool Actualizar (Transporte transporte)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_servicios.sp_actualizaTransporte";

                OracleParameter id = _sql.CreateParameter();
                id.ParameterName = "idTrans";
                id.Value = transporte.IdTransporte;
                id.OracleDbType = OracleDbType.Int64;
                id.Size = 2;
                _sql.Parameters.Add(id);

                OracleParameter conductor = _sql.CreateParameter();
                conductor.ParameterName = "nombreConductor";
                conductor.Value = transporte.NombreConductor;
                conductor.OracleDbType = OracleDbType.Varchar2;
                conductor.Size = 100;
                _sql.Parameters.Add(conductor);

                OracleParameter patente = _sql.CreateParameter();
                patente.ParameterName = "patente";
                patente.Value = transporte.Patente;
                patente.OracleDbType = OracleDbType.Varchar2;
                patente.Size = 8;
                _sql.Parameters.Add(patente);

                //OracleParameter idservicio = _sql.CreateParameter();
                //idservicio.ParameterName = "idServicio";
                //idservicio.Value = transporte.IdServicio;
                //idservicio.OracleDbType = OracleDbType.Int64;
                //idservicio.Size = 3;
                //_sql.Parameters.Add(idservicio);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            return resultado;
        }

        public bool Eliminar(Transporte transporte)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_servicios.sp_eliminaTransporte";

                OracleParameter id = _sql.CreateParameter();
                id.ParameterName = "idTrans";
                id.Value = transporte.IdTransporte;
                id.OracleDbType = OracleDbType.Int64;
                id.Size = 2;
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

using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Datos.Entidades
{
    public class Servicio_extra
    {
        //Atributos de la clase.
        private int _idServicio;
        private string _descripcionServicio;
        private int _costoServicio;

        //Getters y Setters de los atributos.
        public int IdServicio { get => _idServicio; set => _idServicio = value; }
        public string DescripcionServicio { get => _descripcionServicio; set => _descripcionServicio = value; }
        public int CostoServicio { get => _costoServicio; set => _costoServicio = value; }

        //Constructor de la clase.
        public Servicio_extra()
        {
            Init();
        }

        //Metodo para generar inicialmente los atributos en estado "vacio".
        public void Init()
        {
            this.IdServicio = 0;
            this.DescripcionServicio = string.Empty;
            this.CostoServicio = 0;
        }

        #region CRUD

        //Metodo que muestra todos los Servicios extras guardados.
        public DataTable ListaServicioExtra()
        {
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_servicios.sp_lstServicioExtra";
                _sql.Parameters.Add("o_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                return Enlace.RegresaDatos(_sql);

            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }

        //Metodo que crea un nuevo Servicio extra.
        public bool Crear (Servicio_extra servicio)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_servicios.sp_insertaServicioExtra";

                OracleParameter descripcion = _sql.CreateParameter();
                descripcion.ParameterName = "descripcion";
                descripcion.Value = servicio._descripcionServicio;
                descripcion.OracleDbType = OracleDbType.Varchar2;
                descripcion.Size = 200;
                _sql.Parameters.Add(descripcion);


                OracleParameter costo = _sql.CreateParameter();
                costo.ParameterName = "costo";
                costo.Value = servicio._costoServicio;
                costo.OracleDbType = OracleDbType.Int64;
                costo.Size = 6;
                _sql.Parameters.Add(costo);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;
            }
            catch(OracleException ex)
            {
                throw ex;
            }
            return resultado;

        }

        //Metodo que actualiza datos del Servicio extra ya existente.
        public bool Actualizar (Servicio_extra servicio)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_servicios.sp_actualizaServicioExtra";

                OracleParameter id = _sql.CreateParameter();
                id.ParameterName = "idServEx";
                id.Value = servicio.IdServicio;
                id.OracleDbType = OracleDbType.Int64;
                id.Size = 3;
                _sql.Parameters.Add(id);

                OracleParameter descripcion = _sql.CreateParameter();
                descripcion.ParameterName = "descripcion";
                descripcion.Value = servicio.DescripcionServicio;
                descripcion.OracleDbType = OracleDbType.Varchar2;
                descripcion.Size = 200;
                _sql.Parameters.Add(descripcion);

                OracleParameter costo = _sql.CreateParameter();
                costo.ParameterName = "costo";
                costo.Value = servicio.CostoServicio;
                costo.OracleDbType = OracleDbType.Int64;
                costo.Size = 6;
                _sql.Parameters.Add(costo);


                Enlace.EjecutarSentencia(_sql);
                resultado = true;
            }
            catch(OracleException ex)
            {
                throw ex;
            }
            return resultado;
        }

        //Metodo que elimina Servicio extra ya existente.
        public bool Eliminar(Servicio_extra servicio)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_servicios.sp_eliminaServicioExtra";

                OracleParameter id = _sql.CreateParameter();
                id.ParameterName = "idServEx";
                id.Value = servicio.IdServicio;
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

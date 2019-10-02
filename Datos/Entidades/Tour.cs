using System;
using System.Collections.Generic;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Datos.Entidades
{
    public class Tour
    {
        private int _idTour;
        private int _idServicio;
        private string _descripcion;

        public int IdTour { get => _idTour; set => _idTour = value; }
        public int IdServicio { get => _idServicio; set => _idServicio = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        public Tour()
        {
            Init();
        }


        public void Init()
        {
            this.IdTour = 0;
            this.IdServicio = 0;
            this.Descripcion = string.Empty;
        }

        #region CRUD

        public DataTable ListaTour()
        {
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_servicios.sp_lstTour";
                _sql.Parameters.Add("o_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                return Enlace.RegresaDatos(_sql);

            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }

        public bool Crear(Tour tour)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_servicios.sp_insertaTour";

                OracleParameter id = _sql.CreateParameter();
                id.ParameterName = "idServicio";
                id.Value = tour.IdServicio;
                id.OracleDbType = OracleDbType.Int64;
                id.Size = 3;
                _sql.Parameters.Add(id);


                OracleParameter descripcion = _sql.CreateParameter();
                descripcion.ParameterName = "descripcion";
                descripcion.Value = tour.Descripcion;
                descripcion.OracleDbType = OracleDbType.Varchar2;
                descripcion.Size = 200;
                _sql.Parameters.Add(descripcion);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            return resultado;

        }

        public bool Actualizar(Tour tour)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_servicios.sp_actualizaTour";


                OracleParameter id = _sql.CreateParameter();
                id.ParameterName = "idTours";
                id.Value = tour.IdTour;
                id.OracleDbType = OracleDbType.Int64;
                id.Size = 3;
                _sql.Parameters.Add(id);

                OracleParameter idServ = _sql.CreateParameter();
                idServ.ParameterName = "idServicio";
                idServ.Value = tour.IdServicio;
                idServ.OracleDbType = OracleDbType.Int64;
                idServ.Size = 3;
                _sql.Parameters.Add(idServ);


                OracleParameter descripcion = _sql.CreateParameter();
                descripcion.ParameterName = "descripcion";
                descripcion.Value = tour.Descripcion;
                descripcion.OracleDbType = OracleDbType.Varchar2;
                descripcion.Size = 200;
                _sql.Parameters.Add(descripcion);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            return resultado;

        }

        public bool Eliminar(Tour tour)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_servicios.sp_eliminaTour";

                OracleParameter id = _sql.CreateParameter();
                id.ParameterName = "idTours";
                id.Value = tour.IdTour;
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

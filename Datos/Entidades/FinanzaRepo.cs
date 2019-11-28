using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Datos.Entidades
{
    public class FinanzaRepo
    {
        public List<Finanza> IngresoMensual()
        {
            List<Finanza> lista = new List<Finanza>();

            OracleCommand _sql = Enlace.ComandoSP();
            try
            {
                Enlace.ConnOpen(_sql);
                _sql.CommandText = "pkg_finanzas.sp_TotalPorMes";
                _sql.Parameters.Add("o_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter(_sql);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Finanza finanza = new Finanza();
                    finanza.Fecha = dr[0].ToString();
                    finanza.Ingreso = int.Parse(dr[1].ToString());

                    lista.Add(finanza);
                }
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            return lista;
        }

        public List<Finanza> MontoPorRegion()
        {
            List<Finanza> lista = new List<Finanza>();

            OracleCommand _sql = Enlace.ComandoSP();
            try
            {
                Enlace.ConnOpen(_sql);
                _sql.CommandText = "pkg_finanzas.sp_TotalPorRegion";
                _sql.Parameters.Add("o_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter(_sql);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Finanza finanza = new Finanza();
                    finanza.Region = dr[0].ToString();
                    finanza.Monto = int.Parse(dr[1].ToString());

                    lista.Add(finanza);
                }
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            return lista;
        }


        //Metodo para listar los departamentos de cada comuna.
        public DataTable ListaDepartamentoPorComuna(int id_comuna)
        {
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_finanzas.sp_DepartamentoPorComuna";

                _sql.Parameters.Add("o_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleParameter comuna = _sql.CreateParameter();
                comuna.ParameterName = "comuna";
                comuna.Value = id_comuna;
                comuna.OracleDbType = OracleDbType.Int64;
                _sql.Parameters.Add(comuna);

                return Enlace.RegresaDatos(_sql);
            }
            catch (OracleException ex)
            {
                throw ex;
            }

        }
        //Metodo para obtener datos para finanzas
        public DataTable FinanzaDepartamento(int id_departamento,int mes, int anio)
        {
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_finanzas.sp_FinanzaDepartamento";

                _sql.Parameters.Add("o_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleParameter departamento = _sql.CreateParameter();
                departamento.ParameterName = "departamento";
                departamento.Value = id_departamento;
                departamento.OracleDbType = OracleDbType.Int64;
                _sql.Parameters.Add(departamento);

                OracleParameter month = _sql.CreateParameter();
                month.ParameterName = "mes";
                month.Value = mes;
                month.OracleDbType = OracleDbType.Int64;
                _sql.Parameters.Add(month);

                OracleParameter year = _sql.CreateParameter();
                year.ParameterName = "anio";
                year.Value = anio;
                year.OracleDbType = OracleDbType.Int64;
                _sql.Parameters.Add(year);

                return Enlace.RegresaDatos(_sql);
            }
            catch (OracleException ex)
            {
                throw ex;
            }

        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;
namespace Datos
{
    public class Enlace
    {
        //static private string cadena = "User Id=admin;Password=Termicl1;Data Source=ptforacle18.cgduitd6w4ko.us-east-1.rds.amazonaws.com:1521/ORCL;";
        static private string cadena = "User Id=ptf2019;Password=bf2142;Data Source=192.168.1.191:1521/XE;";

        public static OracleCommand ComandoSP()
        {
            OracleConnection _conexion = new OracleConnection();
            _conexion.ConnectionString = cadena;
            OracleCommand _comando = new OracleCommand();
            _comando = _conexion.CreateCommand();
            _comando.CommandType = CommandType.StoredProcedure;
            return _comando;
        }

        public static DataTable RegresaDatos(OracleCommand comando)
        {
            DataTable _tabla = new DataTable();
            try
            {
                comando.Connection.Open();
                OracleDataAdapter _adaptador = new OracleDataAdapter();
                _adaptador.SelectCommand = comando;
                _adaptador.Fill(_tabla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                comando.Connection.Close();
            }
            return _tabla;
        }

        public static void EjecutarSentencia(OracleCommand comando)
        {
            try
            {
                comando.Connection.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                comando.Connection.Close();
            }
        }
    }
}

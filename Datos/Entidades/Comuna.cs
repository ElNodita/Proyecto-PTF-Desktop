using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Datos.Entidades
{
    public class Comuna
    {
        //Atributos de la clase
        int _id;
        string _nombre;
        int _idRegion;

        //Getters y Setters de los atributos
        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int IdRegion { get => _idRegion; set => _idRegion = value; }

        //Constructor de la clase.
        public Comuna()
        {
            Init();
        }

        //Metodo para generar inicialmente los atributos en estado "vacio".
        public void Init()
        {
            Id = 0;
            Nombre = string.Empty;
            IdRegion = 0;
        }

        //Metodo para listar las comunas de cada Region.
        public DataTable ListaComunaPorRegion(int id_region)
        {
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_comun.sp_lstComunaPorRegion";

                _sql.Parameters.Add("o_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleParameter region = _sql.CreateParameter();
                region.ParameterName = "idRegion";
                region.Value = id_region;
                region.OracleDbType = OracleDbType.Int64;
                _sql.Parameters.Add(region);

                return Enlace.RegresaDatos(_sql);
            }
            catch (OracleException ex)
            {
                throw ex;
            }

        }
    }
}

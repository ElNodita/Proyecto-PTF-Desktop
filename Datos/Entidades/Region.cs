using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Datos.Entidades
{
    public class Region
    {
        //Atributos de la clase.
        int _id;
        string _nombre;

        //Getters y Setters de los atributos.
        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }

        //Constructor de la clase.
        public Region()
        {
            Init();
        }

        //Metodo para generar inicialmente los atributos en estado "vacio".
        public void Init()
        {
            Id = 0;
            Nombre = string.Empty;
        }

        //Metodo que muestra todas las Regiones guardadas.
        public DataTable ListaRegion()
        {
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_comun.sp_lstRegion";

                _sql.Parameters.Add("o_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                return Enlace.RegresaDatos(_sql);
            }
            catch (OracleException ex)
            {
                throw ex;
            }

        }
    }
}

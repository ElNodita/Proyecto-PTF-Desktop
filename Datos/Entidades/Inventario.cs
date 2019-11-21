using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Datos.Entidades
{
    public class Inventario
    {
        //Atributos de la clase.
        int _id;
        int _idDepa;
        Char _internet;
        int _baño;
        int _dormitorio;
        int _tv;
        int _mesa;
        int _asiento;
        int _mueble;

        //Getters y Setters de los atributos.
        public int Id { get => _id; set => _id = value; }
        public int IdDepa { get => _idDepa; set => _idDepa = value; }
        public char Internet { get => _internet; set => _internet = value; }
        public int Baño { get => _baño; set => _baño = value; }
        public int Dormitorio { get => _dormitorio; set => _dormitorio = value; }
        public int Tv { get => _tv; set => _tv = value; }
        public int Mesa { get => _mesa; set => _mesa = value; }
        public int Asiento { get => _asiento; set => _asiento = value; }
        public int Mueble { get => _mueble; set => _mueble = value; }

        //Constructor de la clase.
        public Inventario()
        {
            Init();
        }

        //Metodo para generar inicialmente los atributos en estado "vacio".
        public void Init()
        {
            Id = 0;
            IdDepa = 0;
            Internet = '\0';
            Baño = 0;
            Dormitorio = 0;
            Tv = 0;
            Mesa = 0;
            Asiento = 0;
            Mueble = 0;
        }

        #region CRUD
        //Metodo para listar los datos de Inventarios realizados anteriormente.
        public DataTable ListaInventario(int inventario)
        {
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_departamento.sp_listaInventario";

                _sql.Parameters.Add("o_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleParameter inv = _sql.CreateParameter();
                inv.ParameterName = "idInventario";
                inv.Value = inventario;
                inv.OracleDbType = OracleDbType.Int64;
                _sql.Parameters.Add(inv);

                return Enlace.RegresaDatos(_sql);
            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }

        //Metodo para crear un nuevo Inventario.
        public bool Crear(Inventario inventario)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_departamento.sp_registraInventario";

                OracleParameter depa = _sql.CreateParameter();
                depa.ParameterName = "idDepartamento";
                depa.Value = inventario.IdDepa;
                depa.OracleDbType = OracleDbType.Int64;
                depa.Size = 4;
                _sql.Parameters.Add(depa);

                OracleParameter internet = _sql.CreateParameter();
                internet.ParameterName = "internet";
                internet.Value = inventario.Internet;
                internet.OracleDbType = OracleDbType.Char;
                internet.Size = 1;
                _sql.Parameters.Add(internet);

                OracleParameter baño = _sql.CreateParameter();
                baño.ParameterName = "banio";
                baño.Value = inventario.Baño;
                baño.OracleDbType = OracleDbType.Int64;
                baño.Size = 1;
                _sql.Parameters.Add(baño);

                OracleParameter dormitorio = _sql.CreateParameter();
                dormitorio.ParameterName = "dormitorio";
                dormitorio.Value = inventario.Dormitorio;
                dormitorio.OracleDbType = OracleDbType.Int64;
                dormitorio.Size = 1;
                _sql.Parameters.Add(dormitorio);

                OracleParameter tv = _sql.CreateParameter();
                tv.ParameterName = "tv";
                tv.Value = inventario.Tv;
                tv.OracleDbType = OracleDbType.Int64;
                tv.Size = 1;
                _sql.Parameters.Add(tv);

                OracleParameter mesa = _sql.CreateParameter();
                mesa.ParameterName = "mesa";
                mesa.Value = inventario.Mesa;
                mesa.OracleDbType = OracleDbType.Int64;
                mesa.Size = 1;
                _sql.Parameters.Add(mesa);

                OracleParameter asiento = _sql.CreateParameter();
                asiento.ParameterName = "asiento";
                asiento.Value = inventario.Asiento;
                asiento.OracleDbType = OracleDbType.Int64;
                asiento.Size = 2;
                _sql.Parameters.Add(asiento);

                OracleParameter mueble = _sql.CreateParameter();
                mueble.ParameterName = "mueble";
                mueble.Value = inventario.Mueble;
                mueble.OracleDbType = OracleDbType.Int64;
                mueble.Size = 2;
                _sql.Parameters.Add(mueble);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            return resultado;
        }

        //Metodo para Actualizar datos de un Inventario existente.
        public bool Actualizar(Inventario inventario)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_departamento.sp_actualizaInventario";

                OracleParameter inv = _sql.CreateParameter();
                inv.ParameterName = "idInventario";
                inv.Value = inventario.Id;
                inv.OracleDbType = OracleDbType.Int64;
                inv.Size = 4;
                _sql.Parameters.Add(inv);

                OracleParameter internet = _sql.CreateParameter();
                internet.ParameterName = "internet";
                internet.Value = inventario.Internet;
                internet.OracleDbType = OracleDbType.Char;
                internet.Size = 1;
                _sql.Parameters.Add(internet);

                OracleParameter baño = _sql.CreateParameter();
                baño.ParameterName = "banio";
                baño.Value = inventario.Baño;
                baño.OracleDbType = OracleDbType.Int64;
                baño.Size = 1;
                _sql.Parameters.Add(baño);

                OracleParameter dormitorio = _sql.CreateParameter();
                dormitorio.ParameterName = "dormitorio";
                dormitorio.Value = inventario.Dormitorio;
                dormitorio.OracleDbType = OracleDbType.Int64;
                dormitorio.Size = 1;
                _sql.Parameters.Add(dormitorio);

                OracleParameter tv = _sql.CreateParameter();
                tv.ParameterName = "tv";
                tv.Value = inventario.Tv;
                tv.OracleDbType = OracleDbType.Int64;
                tv.Size = 1;
                _sql.Parameters.Add(tv);

                OracleParameter mesa = _sql.CreateParameter();
                mesa.ParameterName = "mesa";
                mesa.Value = inventario.Mesa;
                mesa.OracleDbType = OracleDbType.Int64;
                mesa.Size = 1;
                _sql.Parameters.Add(mesa);

                OracleParameter asiento = _sql.CreateParameter();
                asiento.ParameterName = "asiento";
                asiento.Value = inventario.Asiento;
                asiento.OracleDbType = OracleDbType.Int64;
                asiento.Size = 2;
                _sql.Parameters.Add(asiento);

                OracleParameter mueble = _sql.CreateParameter();
                mueble.ParameterName = "mueble";
                mueble.Value = inventario.Mueble;
                mueble.OracleDbType = OracleDbType.Int64;
                mueble.Size = 2;
                _sql.Parameters.Add(mueble);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            return resultado;
        }

        //Metodo para Eliminar un Inventario existente.
        public bool Eliminar(Inventario inventario)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_departamento.sp_eliminaInventario";

                OracleParameter inv = _sql.CreateParameter();
                inv.ParameterName = "idInventario";
                inv.Value = inventario.Id;
                inv.OracleDbType = OracleDbType.Int64;
                inv.Size = 4;
                _sql.Parameters.Add(inv);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            return resultado;
        }

        #endregion

    }
}

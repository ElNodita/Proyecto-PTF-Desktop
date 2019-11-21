using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Datos.Entidades
{
    public class Departamento
    {
        //Atributos de la clase.
        int _id;
        int _costo;
        Char _estado;
        string _tipo;
        int _idComuna;
        string _direccion;

        //Getters y Setters de los atributos.
        public int Id { get => _id; set => _id = value; }
        public int Costo { get => _costo; set => _costo = value; }
        public char Estado { get => _estado; set => _estado = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public int IdComuna { get => _idComuna; set => _idComuna = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }

        //Constructor de la clase.
        public Departamento()
        {
            Init();
        }

        //Metodo para generar inicialmente los atributos en estado "vacio".
        public void Init()
        {
            Id = 0;
            Costo = 0;
            Estado = '\0';
            Tipo = string.Empty;
            IdComuna = 0;
            Direccion = string.Empty;
        }

        //Metodo para cambiar el estado del Departamento en donde se identifica si esta disponible o no.
        public bool CambiaEstado(int departamento, char estado)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_departamento.sp_cambiaEstado";

                OracleParameter id_departamento = _sql.CreateParameter();
                id_departamento.ParameterName = "idDepartamento";
                id_departamento.Value = departamento;
                id_departamento.OracleDbType = OracleDbType.Int64;
                id_departamento.Size = 4;
                _sql.Parameters.Add(id_departamento);

                OracleParameter estado_departamento = _sql.CreateParameter();
                estado_departamento.ParameterName = "estado";
                estado_departamento.Value =estado;
                estado_departamento.OracleDbType = OracleDbType.Char;
                estado_departamento.Size = 1;
                _sql.Parameters.Add(estado_departamento);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            return resultado;
        }

        #region CRUD
        //Metodo para crear un nuevo Departamento.
        public bool Crear(Departamento departamento)
        {
            bool resultado = true;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_departamento.sp_insertaDepartamento";

                OracleParameter costoD = _sql.CreateParameter();
                costoD.ParameterName = "costo";
                costoD.Value = departamento.Costo;
                costoD.OracleDbType = OracleDbType.Int64;
                costoD.Size = 7;
                _sql.Parameters.Add(costoD);

                OracleParameter tipoD = _sql.CreateParameter();
                tipoD.ParameterName = "tipo";
                tipoD.Value = departamento.Tipo;
                tipoD.OracleDbType = OracleDbType.Varchar2;
                tipoD.Size = 20;
                _sql.Parameters.Add(tipoD);

                OracleParameter comuna = _sql.CreateParameter();
                comuna.ParameterName = "idComuna";
                comuna.Value = departamento.IdComuna;
                comuna.OracleDbType = OracleDbType.Int64;
                comuna.Size = 3;
                _sql.Parameters.Add(comuna);

                OracleParameter direcc = _sql.CreateParameter();
                direcc.ParameterName = "direccion";
                direcc.Value = departamento.Direccion;
                direcc.OracleDbType = OracleDbType.Varchar2;
                direcc.Size = 200;
                _sql.Parameters.Add(direcc);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;

            }
            catch (OracleException ex)
            {
                throw ex;
            }
            return resultado;
        }

        //Metodo para listar los Departamentos agregados anteriormente.
        public DataTable ListaDepartamento()
        {
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_departamento.sp_listaDepartamento";
                _sql.Parameters.Add("o_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                return Enlace.RegresaDatos(_sql);
            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }

        //Metodo para Actualizar datos de un Departamento existente. 
        public bool Actualizar(Departamento departamento)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_departamento.sp_actualizaDepartamento";

                OracleParameter id_departamento = _sql.CreateParameter();
                id_departamento.ParameterName = "idDepartamento";
                id_departamento.Value = departamento.Id;
                id_departamento.OracleDbType = OracleDbType.Int64;
                id_departamento.Size = 4;
                _sql.Parameters.Add(id_departamento);

                OracleParameter valor = _sql.CreateParameter();
                valor.ParameterName = "costo";
                valor.Value = departamento.Costo;
                valor.OracleDbType = OracleDbType.Int64;
                valor.Size = 7;
                _sql.Parameters.Add(valor);

                OracleParameter estado_departamento = _sql.CreateParameter();
                estado_departamento.ParameterName = "estado";
                estado_departamento.Value = departamento.Estado;
                estado_departamento.OracleDbType = OracleDbType.Char;
                estado_departamento.Size = 1;
                _sql.Parameters.Add(estado_departamento);

                OracleParameter tipo_departamento = _sql.CreateParameter();
                tipo_departamento.ParameterName = "tipo";
                tipo_departamento.Value = departamento.Tipo;
                tipo_departamento.OracleDbType = OracleDbType.Varchar2;
                tipo_departamento.Size = 20;
                _sql.Parameters.Add(tipo_departamento);

                OracleParameter direccion_departamento = _sql.CreateParameter();
                direccion_departamento.ParameterName = "direccion";
                direccion_departamento.Value = departamento.Direccion;
                direccion_departamento.OracleDbType = OracleDbType.Varchar2;
                direccion_departamento.Size = 200;
                _sql.Parameters.Add(direccion_departamento);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;

            }catch(OracleException ex)
            {
                throw ex;
            }

            return resultado;
        }

        //Metodo para Eliminar un Departamento existente.
        public bool Eliminar(Departamento departamento)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_departamento.sp_eliminaDepartamento";

                OracleParameter id_departamento = _sql.CreateParameter();
                id_departamento.ParameterName = "idDepartamento";
                id_departamento.Value = departamento.Id;
                id_departamento.OracleDbType = OracleDbType.Int64;
                id_departamento.Size = 4;
                _sql.Parameters.Add(id_departamento);

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

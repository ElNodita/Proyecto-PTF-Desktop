using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Datos.Entidades
{
    public class Galeria
    {
        //Atributos de la clase.
        int _id;
        string _ubicacion;
        int _idDepartamento;
        string _nombre;

        //Getters y Setters de los atributos.
        public int Id { get => _id; set => _id = value; }
        public string Ubicacion { get => _ubicacion; set => _ubicacion = value; }
        public int IdDepartamento { get => _idDepartamento; set => _idDepartamento = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }

        //Constructor de la clase.
        public Galeria()
        {
            Init();
        }

        //Metodo para generar inicialmente los atributos en estado "vacio".
        public void Init()
        {
            Id = 0;
            Ubicacion = string.Empty;
            IdDepartamento = 0;
            Nombre = string.Empty;
        }

        //Metodo para Listar todas las fotos del Departamento asociado con la Id del mismo.
        public DataTable ListaGaleria(int departamento)
        {
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_departamento.sp_listaGaleria";
                _sql.Parameters.Add("o_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleParameter idDepartamento = _sql.CreateParameter();
                idDepartamento.ParameterName = "departamento";
                idDepartamento.Value = departamento;
                idDepartamento.OracleDbType = OracleDbType.Int64;
                idDepartamento.Size = 6;
                _sql.Parameters.Add(idDepartamento);

                return Enlace.RegresaDatos(_sql);
            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }

        //Metodo para subir una nueva galeria de imagen para un Departamento.
        public bool Crear(Galeria galeria)
        {
            bool resultado = false;
            try
            {
                OracleCommand _sql = Enlace.ComandoSP();
                _sql.CommandText = "pkg_departamento.sp_insertaGaleria";

                OracleParameter ubicacion = _sql.CreateParameter();
                ubicacion.ParameterName = "ubicacion";
                ubicacion.Value = galeria.Ubicacion;
                ubicacion.OracleDbType = OracleDbType.Varchar2;
                ubicacion.Size = 200;
                _sql.Parameters.Add(ubicacion);

                OracleParameter departamento = _sql.CreateParameter();
                departamento.ParameterName = "departamento";
                departamento.Value = galeria.IdDepartamento;
                departamento.OracleDbType = OracleDbType.Int64;
                departamento.Size = 6;
                _sql.Parameters.Add(departamento);

                OracleParameter archivo = _sql.CreateParameter();
                archivo.ParameterName = "nombre";
                archivo.Value = galeria.Nombre;
                archivo.OracleDbType = OracleDbType.Varchar2;
                archivo.Size = 100;
                _sql.Parameters.Add(archivo);

                Enlace.EjecutarSentencia(_sql);
                resultado = true;

            }
            catch(OracleException ex)
            {
                throw ex;
            }
            return resultado;
        }
    }
}

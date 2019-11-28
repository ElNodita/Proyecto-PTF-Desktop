using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos.Entidades;

namespace Negocio.Clases
{
    public class TransporteCollection
    {
        //Atributos de colección
        Transporte transporte;
        //Metodo que muestra Transportes guardados en la base de datos.
        public DataTable ListaTransporteC()
        {
            return new Transporte().ListaTransporte();
        }

        //Metodo que inserta datos de un nuevo Transporte hacia la base de datos.
        public bool InsertaTransporteC(string nombreConductor, string patente, int id_servicio)
        {
            transporte = new Transporte();
            transporte.NombreConductor = nombreConductor;
            transporte.Patente = patente;
            transporte.IdServicio = id_servicio;


            return transporte.Crear(transporte);
        }

        //Metodo que actualiza los datos de un Transporte existente en la base de datos.
        public bool ActualizaTransporteC(int id_transporte, string nombreConductor, string patente)
        {
            transporte = new Transporte();
            transporte.IdTransporte = id_transporte;
            transporte.NombreConductor = nombreConductor;
            transporte.Patente = patente;

            return transporte.Actualizar(transporte);
        }

        //Metodo que elimina un Transporte almacenado en la base de datos.
        public bool EliminaTransporteC(int id_transporte)
        {
            transporte = new Transporte();
            transporte.IdTransporte = id_transporte;
            return transporte.Eliminar(transporte);

        }

    }
}

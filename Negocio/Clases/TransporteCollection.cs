using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos.Entidades;

namespace Negocio.Clases
{
    public class TransporteCollection
    {
        public DataTable ListaTransporteC()
        {
            return new Transporte().ListaTransporte();
        }


        public bool InsertaTransporteC(string nombreConductor, string patente, int id_servicio)
        {
            Transporte transporte = new Transporte();
            transporte.NombreConductor = nombreConductor;
            transporte.Patente = patente;
            transporte.IdServicio = id_servicio;


            return transporte.Crear(transporte);
        }

        public bool ActualizaTransporteC(int id_transporte, string nombreConductor, string patente, int id_servicio)
        {
            Transporte transporte = new Transporte();
            transporte.IdTransporte = id_transporte;
            transporte.NombreConductor = nombreConductor;
            transporte.Patente = patente;
            transporte.IdServicio = id_servicio;


            return transporte.Actualizar(transporte);
        }

        public bool EliminaTransporteC(int id_transporte)
        {
            Transporte transporte = new Transporte();
            transporte.IdTransporte = id_transporte;
            return transporte.Eliminar(transporte);

        }

    }
}

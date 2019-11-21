using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos.Entidades;

namespace Negocio.Clases
{
    public class ServicioExtraCollection
    {
        //Metodo que muestra los Servicios extras guardados en la base de datos.
        public DataTable ListaServicioExtraC()
        {
            return new Servicio_extra().ListaServicioExtra();
        }

        //Metodo que inserta datos de un nuevo Servicio extra hacia la base de datos.
        public bool InsertaServicioExtraC(string descripcion, int costo)
        {
            Servicio_extra servicio = new Servicio_extra();
            servicio.DescripcionServicio = descripcion;
            servicio.CostoServicio = costo;


            return servicio.Crear(servicio);
        }

        //Metodo que actualiza los datos de un Servicio extra existente en la base de datos.
        public bool ActualizaServicioExtraC(int id_servicio, string descripcion, int costo)
        {
            Servicio_extra servicio = new Servicio_extra();
            servicio.IdServicio = id_servicio;
            servicio.DescripcionServicio = descripcion;
            servicio.CostoServicio = costo;
            return servicio.Actualizar(servicio);
        }

        //Metodo que elimina un Servicio extra almacenado en la base de datos.
        public bool EliminaServicioExtraC(int id_servicio)
        {
            Servicio_extra servicio = new Servicio_extra();
            servicio.IdServicio = id_servicio;
            return servicio.Eliminar(servicio);

        }
    }
}
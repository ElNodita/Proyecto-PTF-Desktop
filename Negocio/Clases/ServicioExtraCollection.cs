using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos.Entidades;

namespace Negocio.Clases
{
    public class ServicioExtraCollection
    {
        public DataTable ListaServicioExtraC()
        {
            return new Servicio_extra().ListaServicioExtra();
        }


        public bool InsertaServicioExtraC(string descripcion, int costo)
        {
            Servicio_extra servicio = new Servicio_extra();
            servicio.DescripcionServicio = descripcion;
            servicio.CostoServicio = costo;


            return servicio.Crear(servicio);
        }

        public bool ActualizaServicioExtraC(int id_servicio, string descripcion, int costo)
        {
            Servicio_extra servicio = new Servicio_extra();
            servicio.IdServicio = id_servicio;
            servicio.DescripcionServicio = descripcion;
            servicio.CostoServicio = costo;
            return servicio.Actualizar(servicio);
        }

        public bool EliminaServicioExtraC(int id_servicio)
        {
            Servicio_extra servicio = new Servicio_extra();
            servicio.IdServicio = id_servicio;
            return servicio.Eliminar(servicio);

        }
    }
}
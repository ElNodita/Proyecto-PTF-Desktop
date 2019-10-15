using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos.Entidades;

namespace Negocio.Clases
{
   public class TourCollection
    {
        public DataTable ListaTourC()
        {
            return new Tour().ListaTour();
        }


        public bool InsertaTourC(int id_servicio, string descripcion)
        {
            Tour tour = new Tour();
            tour.IdServicio = id_servicio;
            tour.Descripcion = descripcion;
          


            return tour.Crear(tour);
        }

        public bool ActualizaTourC(int id_tour, string descripcion)
        {
            Tour tour = new Tour();
            tour.IdTour = id_tour;
            
            tour.Descripcion = descripcion;



            return tour.Actualizar(tour);
        }

        public bool EliminaTourC(int id_tour)
        {
            Tour tour = new Tour();
            tour.IdTour = id_tour;
            return tour.Eliminar(tour);

        }
    }
}

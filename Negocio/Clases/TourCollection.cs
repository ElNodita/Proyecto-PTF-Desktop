using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos.Entidades;

namespace Negocio.Clases
{
   public class TourCollection
    {
        //Metodo que muestra Tours guardados en la base de datos.
        public DataTable ListaTourC()
        {
            return new Tour().ListaTour();
        }

        //Metodo que inserta datos de un nuevo Tour hacia la base de datos.
        public bool InsertaTourC(int id_servicio, string descripcion)
        {
            Tour tour = new Tour();
            tour.IdServicio = id_servicio;
            tour.Descripcion = descripcion;
          


            return tour.Crear(tour);
        }

        //Metodo que actualiza los datos de un Tour existente en la base de datos.
        public bool ActualizaTourC(int id_tour, string descripcion)
        {
            Tour tour = new Tour();
            tour.IdTour = id_tour;
            
            tour.Descripcion = descripcion;



            return tour.Actualizar(tour);
        }

        //Metodo que elimina un Tour almacenado en la base de datos.
        public bool EliminaTourC(int id_tour)
        {
            Tour tour = new Tour();
            tour.IdTour = id_tour;
            return tour.Eliminar(tour);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos.Entidades;
namespace Negocio.Clases
{
    public class DepartamentoCollection
    {
        
        public DataTable ListaDepartamento()
        {
            return new Departamento().ListaDepartamento();
        }

        public DataTable ListaRegion()
        {
            return new Region().ListaRegion();
        }

        public DataTable ListaComunaPorRegion(int region)
        {
            return new Comuna().ListaComunaPorRegion(region);
        }
        public bool InsertaDepartamento(int costo, string tipo, int comuna, string direccion)
        {
            Departamento depa = new Departamento();
            depa.Costo = costo;
            depa.Tipo = tipo;
            depa.IdComuna = comuna;
            depa.Direccion = direccion;

            return depa.Crear(depa);
        }

        public bool ActualizaDepartamento(int id, int costo, char estado, string tipo, string direccion)
        {
            Departamento depa = new Departamento();
            depa.Id = id;
            depa.Costo = costo;
            depa.Estado = estado;
            depa.Tipo = tipo;
            depa.Direccion = direccion;

            return depa.Actualizar(depa);
        }

        public bool EliminarDepartamento(int id)
        {
            Departamento depa = new Departamento();
            depa.Id = id;

            return depa.Eliminar(depa);
        }
    }
}

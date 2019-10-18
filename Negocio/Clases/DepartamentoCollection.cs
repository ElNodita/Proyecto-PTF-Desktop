using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos.Entidades;
namespace Negocio.Clases
{
    public class DepartamentoCollection
    {
        public DataTable ListaRegion()
        {
            return new Region().ListaRegion();
        }

        public DataTable ListaComunaPorRegion(int region)
        {
            return new Comuna().ListaComunaPorRegion(region);
        }

        public DataTable ListaDepartamento()
        {
            return new Departamento().ListaDepartamento();
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

        public bool CambiaEstado(int departamento, char estado)
        {
            Departamento depa = new Departamento();
            return depa.CambiaEstado(departamento,estado);
        }

        public DataTable ListaInventario(int inventario)
        {
            return new Inventario().ListaInventario(inventario);
        }

        public bool InsertaInventario(int idDepartamento,char internet,int banio,int dormitorio,int tv,int mesa,int asiento,int mueble)
        {
            Inventario inv = new Inventario();
            inv.IdDepa = idDepartamento;
            inv.Internet = internet;
            inv.Baño = banio;
            inv.Dormitorio = dormitorio;
            inv.Tv = tv;
            inv.Mesa = mesa;
            inv.Asiento = asiento;
            inv.Mueble = mueble;

            return inv.Crear(inv);
        }

        public bool ActualizaInventario(int inventario, char internet, int banio, int dormitorio, int tv, int mesa, int asiento, int mueble)
        {
            Inventario inv = new Inventario();
            inv.Id = inventario;
            inv.Internet = internet;
            inv.Baño = banio;
            inv.Dormitorio = dormitorio;
            inv.Tv = tv;
            inv.Mesa = mesa;
            inv.Asiento = asiento;
            inv.Mueble = mueble;

            return inv.Actualizar(inv);
        }

        public bool EliminaInventario(int inventario)
        {
            Inventario inv = new Inventario();
            inv.Id = inventario;

            return inv.Eliminar(inv);
        }

        public void CargaImagen(string archivo)
        {
            Datos.Enlace.CargaImagenFTP(archivo);
        }
    }
}

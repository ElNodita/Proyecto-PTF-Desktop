using System.Data;
using Datos.Entidades;
namespace Negocio.Clases
{
    public class DepartamentoCollection
    {
        //Metodo que muestra Region guardadas en la base de datos.
        public DataTable ListaRegion()
        {
            return new Region().ListaRegion();
        }

        //Metodo que muestra Comunas que se encuentras en una Region especifica almacenada en la base de datos.
        public DataTable ListaComunaPorRegion(int region)
        {
            return new Comuna().ListaComunaPorRegion(region);
        }

        //Metodo que muestra todos los Departamentos que se encuentran almacenados en la base de datos.
        public DataTable ListaDepartamento()
        {
            return new Departamento().ListaDepartamento();
        }

        //Metodo que inserta datos de un nuevo Departamento hacia la base de datos.
        public bool InsertaDepartamento(int costo, string tipo, int comuna, string direccion)
        {
            Departamento depa = new Departamento();
            depa.Costo = costo;
            depa.Tipo = tipo;
            depa.IdComuna = comuna;
            depa.Direccion = direccion;

            return depa.Crear(depa);
        }

        //Metodo que actualiza los datos de un Departamento existente en la base de datos.
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

        //Metodo que elimina un Departamento almacenado en la base de datos.
        public bool EliminarDepartamento(int id)
        {
            Departamento depa = new Departamento();
            depa.Id = id;

            return depa.Eliminar(depa);
        }

        //Metodo que cambio el estado del Departamento en la base de datos.
        public bool CambiaEstado(int departamento, char estado)
        {
            Departamento depa = new Departamento();
            return depa.CambiaEstado(departamento,estado);
        }

        //Metodo que muestra todos los Inventarios que se encuentran almacenados en la base de datos.
        public DataTable ListaInventario(int inventario)
        {
            return new Inventario().ListaInventario(inventario);
        }

        //Metodo que inserta datos de un nuevo Inventario hacia la base de datos.
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

        //Metodo que actualiza los datos de un Inventario existente en la base de datos.
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

        //Metodo que elimina un Inventario almacenado en la base de datos.
        public bool EliminaInventario(int inventario)
        {
            Inventario inv = new Inventario();
            inv.Id = inventario;

            return inv.Eliminar(inv);
        }

        //Metodo que muestra todas las Galerias de fotos de un Departamento almacenado en la base de datos.
        public DataTable ListaGaleria(int departamento)
        {
            Galeria gal = new Galeria();
            return gal.ListaGaleria(departamento);
        }

        //Metodo que agrega una nueva imagen de un Departamento a la base de datos.
        public bool InsertaImagen(int departamento, string archivo, string ruta)
        {
            Galeria galeria = new Galeria();
            galeria.IdDepartamento = departamento;
            galeria.Nombre = archivo;
            galeria.Ubicacion = ruta;
            return galeria.Crear(galeria);
        }

        //Metodo que carga una nueva imagen a la base de datos.
        public void CargaImagen(string archivo)
        {
            Datos.Enlace.CargaImagenFTP(archivo);
        }
    }
}

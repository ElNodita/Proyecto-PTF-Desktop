using NUnit.Framework;
using Datos.Entidades;
using System.Transactions;
using Datos;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Pruebas
{
    [TestFixture]
    public class Tests
    {
        private Persona Per;
        private TransactionScope scope;


        [SetUp]
        public void SetUp()
        {
            scope = new TransactionScope();
        }

        [TearDown]
        public void TearDown()
        {
            scope.Dispose();
        }

        [Test]
        public void FuncionariosTest()
        {
            Per = new Persona();
            var lista = Per.ListaFuncionarios();
            var hasRow = lista.Rows.GetEnumerator().MoveNext();

            if (hasRow == true)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void FuncionariosTest2()
        {
            
            Assert.Pass();
        }
        /*
        [Test]
        public void RegistroDePersona()
        {
            Uc = new UsuarioCollection();
            string rut = "11111111-1";
            string nombre = "Manuel";
            string apepa = "Rojas";
            string apema = "Rojas";
            string contacto = "9638932";
            DateTime fecha = new DateTime(1996,6,1);
            string direccion = "Antonio Varas 669";
            int id_usuario = 6;

            var registro = Uc.InsertaDatos(rut,nombre,apepa,apema,contacto,fecha,direccion,id_usuario);

            if (registro==true)
            {
                Assert.Pass();
            }
        }*/
    }
}
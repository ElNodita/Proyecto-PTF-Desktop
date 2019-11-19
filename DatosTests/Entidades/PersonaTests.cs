using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Entidades.Tests
{
    [TestClass()]
    public class PersonaTests
    {
        Persona Per;
        [TestMethod()]
        public void PersonaTest()
        {
            bool resultado = true;
            Assert.IsTrue(resultado);
        }

        [TestMethod()]
        public void InitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        [Timeout(TestTimeout.Infinite)]
        public void ListaFuncionariosTest()
        {
            bool resultado = true;

                Per = new Persona();
                
                var lista = Per.ListaFuncionarios();
                bool hasRows = lista.Rows.GetEnumerator().MoveNext();
                if (hasRows == true)
                {
                    resultado = true;
                }


            Assert.IsTrue(resultado);
        }

        [TestMethod()]
        public void CrearTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ActualizarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }
    }
}
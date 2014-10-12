using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUD.FluentNhibernate.Model.Repositorios;

namespace CRUD.FluentNhibernate.Model.Test
{
    [TestClass]
    public class AgendaTest
    {

        PessoaFisicaRep Repositorio;

        [TestInitialize]
        public void Executar_ao_iniciar_um_teste()
        {
            Repositorio = new PessoaFisicaRep();
        }

        [TestCleanup]
        public void Executar_ao_terminar_um_teste()
        {
            Repositorio = null;
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUD.FluentNhibernate.Model.Repositorios;
using CRUD.FluentNhibernate.Model.Entidades;
using CRUD.FluentNhibernate.Model.Test.Helper;
using System.Linq;

namespace CRUD.FluentNhibernate.Model.Test
{
    [TestClass]
    public class PessoaFisicaTest
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
        public void Inserir_um_novo_registro()
        {
            PessoaFisica pessoa = new PessoaFisica();

            pessoa.Nome = "Renato Pacheco";
            pessoa.Login = "renatopacheco";
            pessoa.Senha = "7dui0xCx";
            pessoa.CPF = "000.111.222-33";
            pessoa.Status = Status.Ativo;
            pessoa.DataCriacao = DateTime.Now;
            pessoa.DataAlteracao = DateTime.Now;

            Repositorio.Add(pessoa);

            Assert.AreNotEqual(0, pessoa.Id, "Deveria informar o id do novo registro no banco");

            TestDebug.MostraDados(pessoa);
        }

        [TestMethod]
        public void Buscando_por_um_registro_qualquer()
        {
            PessoaFisica pessoa = Repositorio.Query().FirstOrDefault();

            Assert.IsNotNull(pessoa);

            TestDebug.MostraDados(pessoa);
        }

        [TestMethod]
        public void Editar_um_registro_qualquer()
        {
            PessoaFisica pessoa = Repositorio.Query().FirstOrDefault();
            DateTime agora = DateTime.Now;

            pessoa.Nome = "Renato Bevilacqua Pacheco";
            pessoa.Status = Status.Inativo;
            pessoa.DataAlteracao = agora;

            Repositorio.Edit(pessoa);
            pessoa = Repositorio.Find(pessoa.Id);

            Assert.AreEqual(agora, pessoa.DataAlteracao);

            TestDebug.MostraDados(pessoa);
        }

        [TestMethod]
        public void Remover_um_registro_qualquer()
        {
            PessoaFisica pessoa = Repositorio.Query().FirstOrDefault();

            Repositorio.Remove(pessoa);
            pessoa = Repositorio.Find(pessoa.Id);

            Assert.IsNull(pessoa);
        }
    }
}

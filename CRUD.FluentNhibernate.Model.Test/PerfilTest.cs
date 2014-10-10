using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUD.FluentNhibernate.Model.Repositorios;
using CRUD.FluentNhibernate.Model.Entidades;
using CRUD.FluentNhibernate.Model.Test.Helper;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace CRUD.FluentNhibernate.Model.Test
{
    [TestClass]
    public class PerfilTest
    {
        PerfilRep Repositorio;
        PessoaFisicaRep RepositorioPessoa;

        [TestInitialize]
        public void Executar_ao_iniciar_um_teste()
        {
            Repositorio = new PerfilRep();
            RepositorioPessoa = new PessoaFisicaRep();
        }

        [TestCleanup]
        public void Executar_ao_terminar_um_teste()
        {
            Repositorio = null;
            RepositorioPessoa = null;
        }

        [TestMethod]
        public void Inserir_uma_lista_registros()
        {
            IList<Perfil> perfil = new List<Perfil>();

            perfil.Add(new Perfil()
            {
                Nome = "Operador",
                Descricao = "Qualquer coisa",
                DataCriacao = DateTime.Now,
                DataAlteracao = DateTime.Now,
                Status = Status.Ativo
            });
            perfil.Add(new Perfil()
            {
                Nome = "Administrador",
                Descricao = "Qualquer coisa",
                DataCriacao = DateTime.Now,
                DataAlteracao = DateTime.Now,
                Status = Status.Ativo
            });
            perfil.Add(new Perfil()
            {
                Nome = "Moderador",
                Descricao = "Qualquer coisa",
                DataCriacao = DateTime.Now,
                DataAlteracao = DateTime.Now,
                Status = Status.Ativo
            });


            Repositorio.Add(perfil);

            Debug.WriteLine("Perfis -------- ");
            foreach(Perfil item in perfil)
            {
                TestDebug.MostraDados(item);
                Debug.WriteLine("///////////////////");
            }            
        }

        [TestMethod]
        public void Buscando_por_um_registro_qualquer()
        {
            Perfil perfil = Repositorio.Query().FirstOrDefault();

            Assert.IsNotNull(perfil);

            TestDebug.MostraDados(perfil);
        }

        [TestMethod]
        public void Editar_um_registro_qualquer()
        {
            Perfil perfil = Repositorio.Query().FirstOrDefault();
            DateTime agora = DateTime.Now;

            perfil.Nome = "Outro perfil";
            perfil.Status = Status.Inativo;
            perfil.DataAlteracao = agora;

            Repositorio.Edit(perfil);
            perfil = Repositorio.Find(perfil.Id);

            Assert.AreEqual(agora, perfil.DataAlteracao);

            TestDebug.MostraDados(perfil);
        }

        [TestMethod]
        public void Remover_um_registro_qualquer()
        {
            Perfil perfil = Repositorio.Query().FirstOrDefault();

            Repositorio.Remove(perfil);
            perfil = Repositorio.Find(perfil.Id);

            Assert.IsNull(perfil);
        }

        [TestMethod]
        public void Aplicar_um_perfil_a_uma_pessoa()
        {
            Perfil perfil = Repositorio.Query().FirstOrDefault();

            perfil.Pessoas.Add(RepositorioPessoa.Query().FirstOrDefault());

            Repositorio.Edit(perfil);
        }
    }
}

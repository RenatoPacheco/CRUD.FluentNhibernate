using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUD.FluentNhibernate.Model.Repositorios;
using CRUD.FluentNhibernate.Model.Entidades;
using System.Linq;
using System.Diagnostics;
using CRUD.FluentNhibernate.Model.ValueObject;
using System.Text;
using NHibernate;
using System.Collections;
using System.Collections.Generic;

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
        public void Registrar_uma_agenda()
        {
            PessoaFisica pessoa = Repositorio.Query().First();

            pessoa.Agendas.Add(new Agenda() { 
                Titulo = "Um título qualquer...",
                Local = "Não definido...",
                Descricao = "Este evento ocorre en janeiro todos os anos.",
                Inicio = "1/1/{0}",
                Termino = "31/1/{0}",
                DataCriacao = DateTime.Now,
                DataAlteracao = DateTime.Now,
                Status = Status.Ativo
            });


            Repositorio.Edit(pessoa);

            DateTime referencia;

            referencia = DateTime.Parse("25/1/2014");
            Debug.WriteLine(string.Format("Início: {0} - Fim {1}",
                pessoa.Agendas[0].Inicio.ToDateTime(referencia),
                pessoa.Agendas[0].Termino.ToDateTime(referencia)));


            referencia = DateTime.Parse("25/1/2015");
            Debug.WriteLine(string.Format("Início: {0} - Fim {1}",
                pessoa.Agendas[0].Inicio.ToDateTime(referencia),
                pessoa.Agendas[0].Termino.ToDateTime(referencia)));


            referencia = DateTime.Parse("25/1/2016");
            Debug.WriteLine(string.Format("Início: {0} - Fim {1}",
                pessoa.Agendas[0].Inicio.ToDateTime(referencia),
                pessoa.Agendas[0].Termino.ToDateTime(referencia)));
        }
    }
}

using CRUD.FluentNhibernate.CSharp.Model.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.FluentNhibernate.CSharp.Model.Maps
{
    public class PessoaFisicaMap : SubclassMap<PessoaFisica>
    {
        public PessoaFisicaMap()
        {
            Table("tbl_PessoaFisica");

            // Posso usar KeyColumn para escolher o nome no campo que vai relacionar com a tabela tbl_Pessoa
            // KeyColumn("Nome do campo aqui...");

            Map(x => x.CPF)
                .Nullable()
                .Length(14);
        }
    }
}

using CRUD.FluentNhibernate.CSharp.Model.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.FluentNhibernate.CSharp.Model.Maps
{
    public class PessoaJuridicaMap : SubclassMap<PessoaJuridica>
    {
        public PessoaJuridicaMap()
        {
            Table("tbl_PessoaJuridica");

            // Posso usar KeyColumn para escolher o nome no campo que vai relacionar com a tabela tbl_Pessoa
            // KeyColumn("Nome do campo aqui...");

            Map(x => x.CNPJ)
                .Nullable()
                .Length(14);
        }
    }
}

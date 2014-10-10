using CRUD.FluentNhibernate.Model.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.FluentNhibernate.Model.Maps
{
    public class PessoaMap : ClassMap<Pessoa>
    {
        public PessoaMap()
        {
            Table("tbl_Pessoa");

            Id(x => x.Id)
                .GeneratedBy
                .Identity();

            Map(x => x.Nome)
               .Not.Nullable()
               .Length(255);

            Map(x => x.Login)
               .Not.Nullable()
               .Length(255);

            Map(x => x.Senha)
               .Not.Nullable()
               .Length(255);
            
            Map(x => x.DataCriacao)
               .Not.Nullable();

            Map(x => x.DataAlteracao)
               .Not.Nullable();

            Map(x => x.Status)
               .Not.Nullable()
               .CustomType<int>();
        }
    }
}

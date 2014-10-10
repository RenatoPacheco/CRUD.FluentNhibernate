using CRUD.FluentNhibernate.Model.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.FluentNhibernate.Model.Maps
{
    public class TelefoneMap : ClassMap<Telefone>
    {
        public TelefoneMap()
        {
            Table("tbl_Telefone");

            Id(x => x.Id)
                .GeneratedBy
                .Identity();

            Map(x => x.Descricao)
               .Not.Nullable()
               .Length(255);

            Map(x => x.Numero)
               .Not.Nullable()
               .Length(50);

            Map(x => x.Ramal)
               .Not.Nullable()
               .Length(50);
            
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

using CRUD.FluentNhibernate.Model.Entidades;
using CRUD.FluentNhibernate.Model.UserTypes;
using CRUD.FluentNhibernate.Model.ValueObject;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.FluentNhibernate.Model.Maps
{
    public class AgendaMap : ClassMap<Agenda>
    {
        public AgendaMap()
        {
            Table("tbl_Agenda");

            Id(x => x.Id)
                .GeneratedBy
                .Identity();

            Map(x => x.Titulo)
               .Not.Nullable()
               .Length(255);

            Map(x => x.Local)
               .Not.Nullable()
               .Length(255);

            Map(x => x.Descricao)
               .Not.Nullable()
               .Length(3000);
            
            Map(x => x.Inicio)
               .Not.Nullable()
               .CustomType<StringAsDateDynamic>();

            Map(x => x.Termino)
               .Not.Nullable()
               .CustomType<StringAsDateDynamic>();
            
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

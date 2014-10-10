using CRUD.FluentNhibernate.Model.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.FluentNhibernate.Model.Maps
{
    public class PerfilMap : ClassMap<Perfil>
    {
        public PerfilMap()
        {
            Table("tbl_Perfil");

            Id(x => x.Id)
                .GeneratedBy
                .Identity();

            Map(x => x.Nome)
               .Not.Nullable()
               .Length(255);

            Map(x => x.Descricao)
               .Not.Nullable()
               .Length(255);
            
            Map(x => x.DataCriacao)
               .Not.Nullable();

            Map(x => x.DataAlteracao)
               .Not.Nullable();

            Map(x => x.Status)
               .Not.Nullable()
               .CustomType<int>();
            
            // Posso o nome das colunas mas neste caso tem de informar nos dois sentidos.
            // ParentKeyColumn("Nome para esta tabela ex: Id_Perfil")
            // ChildKeyColumn("Nome para a outra tabela ex: Id_Pessoa")

            HasManyToMany(x => x.Pessoas)
                .Table("tbl_PerfilPessoa");
        }
    }
}

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

            // Posso usar o KeyColumn para indicar o nome da colun que relaiciona as tabelas
            // KeyColumn ("Nome da coluna aqui")

            HasMany(x => x.Emails)
                .Cascade.All();

            HasMany(x => x.Telefones)
                .Cascade.All();

            // Posso o nome das colunas mas neste caso tem de informar nos dois sentidos.
            // ParentKeyColumn("Nome para esta tabela ex: Id_Pessoa")
            // ChildKeyColumn("Nome para a outra tabela ex: Id_Perfil")

            HasManyToMany(x => x.Perfis)
                .Table("tbl_PerfilPessoa");
        }
    }
}

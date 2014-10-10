using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.FluentNhibernate.Model.Entidades
{
    public class Perfil
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Descricao { get; set; }

        public virtual DateTime DataCriacao { get; set; }

        public virtual DateTime DataAlteracao { get; set; }

        public virtual Status Status { get; set; }

        public virtual IList<Pessoa> Pessoas { get; set; }

        public Perfil()
        {
            this.Pessoas = new List<Pessoa>();
        }
    }
}

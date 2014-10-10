using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.FluentNhibernate.Model.Entidades
{
    public abstract class Pessoa
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Login { get; set; }

        public virtual string Senha { get; set; }

        public virtual DateTime DataCriacao { get; set; }

        public virtual DateTime DataAlteracao { get; set; }

        public virtual Status Status { get; set; }
    }
}

using CRUD.FluentNhibernate.Model.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.FluentNhibernate.Model.Entidades
{
    public class Agenda
    {
        public virtual int Id { get; set; }

        public virtual string Titulo { get; set; }

        public virtual string Local { get; set; }

        public virtual string Descricao { get; set; }

        public virtual DateDynamic Inicio { get; set; }

        public virtual DateDynamic Termino { get; set; }

        public virtual DateTime DataCriacao { get; set; }

        public virtual DateTime DataAlteracao { get; set; }

        public virtual Status Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.FluentNhibernate.Model.Entidades
{
    public class PessoaFisica : Pessoa
    {
        public virtual string CPF { get; set; }
    }
}

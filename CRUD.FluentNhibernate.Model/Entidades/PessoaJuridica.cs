using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.FluentNhibernate.CSharp.Model.Entidades
{
    public class PessoaJuridica : Pessoa
    {
        public virtual string CNPJ { get; set; }
    }
}

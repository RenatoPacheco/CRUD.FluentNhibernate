using NHibernate;
using NHibernate.Dialect;
using NHibernate.Dialect.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.FluentNhibernate.Model.CustomSqlDialect.MsSql2008
{
    class CollateLatinGeneral : MsSql2008Dialect
    {
        public CollateLatinGeneral()
        {
            RegisterFunction("CollateLatinGeneral",
              new SQLFunctionTemplate(NHibernateUtil.String,
                  "?1 collate Latin1_general_CI_AI"));
        }
    }
}

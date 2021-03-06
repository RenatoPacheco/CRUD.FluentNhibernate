﻿using FluentNHibernate.Cfg;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.FluentNhibernate.Model.Interfaces
{
    public interface IConnection : IDisposable
    {
        void Close();
        ISession Open();
        FluentConfiguration Configuration { get; }
        ISessionFactory SessioFactory { get; }
        ISession Session { get; }
    }
}

using CRUD.FluentNhibernate.Model.CustomSqlDialect.MsSql2008;
using CRUD.FluentNhibernate.Model.Interfaces;
using CRUD.FluentNhibernate.Model.Maps;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.FluentNhibernate.Model.Infras
{
    public class Connection : IConnection
    {
        private FluentConfiguration _Configuration;
        private ISessionFactory _Sessiofactory;
        private ISession _Session;

        public FluentConfiguration Configuration
        {
            get { return _Configuration; }
            private set { _Configuration = value; }
        }
        public ISessionFactory SessioFactory
        {
            get { return _Sessiofactory; }
            private set { _Sessiofactory = value; }
        }

        public ISession Session
        {
            get { return _Session; }
            private set { _Session = value; }
        }

        public static void CreatTable()
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(
                            x => x.FromConnectionStringWithKey("CrudBasico")).ShowSql())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<PessoaMap>());

            configuration.BuildSessionFactory();
        }

        public static void UpdateTable()
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(
                            x => x.FromConnectionStringWithKey("CrudBasico")).ShowSql())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<PessoaMap>());

            configuration.BuildSessionFactory();
        }

        public Connection()
        {
            Init();
        }

        private void Init()
        {
            _Configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                .Dialect<CollateLatinGeneral>()
                .ConnectionString(
                            x => x.FromConnectionStringWithKey("CrudBasico")).ShowSql())
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<PessoaMap>());

            _Sessiofactory = _Configuration.BuildSessionFactory();
            _Session = _Sessiofactory.OpenSession();
        }

        public ISession Open()
        {
            if (_Session.IsOpen == false)
            {
                _Session = _Sessiofactory.OpenSession();
            }
            return _Session;
        }

        public void Close()
        {
            if (_Session.IsOpen) _Session.Close();

            _Configuration = null;

            if (_Sessiofactory.IsClosed == false) _Sessiofactory.Close();

            _Sessiofactory.Dispose();
            _Sessiofactory = null;
            _Session.Dispose();
            _Session = null;
        }
        public void Dispose()
        {
            Close();
            GC.SuppressFinalize(this);
        }
    }
}

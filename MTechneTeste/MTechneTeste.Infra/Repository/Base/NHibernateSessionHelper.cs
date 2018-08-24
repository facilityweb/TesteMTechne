using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using System;
using System.Collections.Generic;

namespace MTechneTeste.Infra.Repository.Base
{
    public class NHibernateSessionHelper
    {
        private static object syncObject = new object();
        public static Dictionary<string, ISessionFactory> factories;

        static NHibernateSessionHelper()
        {
            factories = new Dictionary<string, ISessionFactory>();
        }
        public static ISessionFactory GetFactory(Type classMapping, string dbKey, string connectionString)
        {
            if (!factories.ContainsKey(dbKey))
            {
                lock (syncObject)
                {
                    try
                    {
                        // incluido o exemplo com SQL server e MYsql
                        if (!factories.ContainsKey(dbKey))
                        {
                            ISessionFactory factory;
                            switch (dbKey)
                            {
                                case DatabaseKeys.MYSQL:
                                    factory = Fluently.Configure()
                                   .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
                                   .Mappings(x => x.FluentMappings.AddFromAssembly(classMapping.Assembly).Conventions.Add(DefaultCascade.None()))
                                   .BuildSessionFactory();
                                    factories.Add(dbKey, factory);
                                    break;
                                case DatabaseKeys.SQLSERVER:
                                    factory = Fluently.Configure()
                                    .Database(MsSqlConfiguration.MsSql2008.FormatSql().ShowSql().AdoNetBatchSize(50).ConnectionString(connectionString))
                                    .Mappings(x => x.FluentMappings.AddFromAssembly(classMapping.Assembly).Conventions.Add(DefaultCascade.None()))
                                    .BuildSessionFactory();
                                    factories.Add(dbKey, factory);
                                    break;
                                case DatabaseKeys.ORACLE:
                                    throw new NotImplementedException();
                                default:
                                    break;
                            }
                        }
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                }
            }
            return factories[dbKey];
        }
    }
}

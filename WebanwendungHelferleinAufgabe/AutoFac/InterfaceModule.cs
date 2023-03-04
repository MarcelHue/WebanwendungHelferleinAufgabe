using System.Data;
using System.IO.Abstractions;
using System.Reflection;
using Autofac;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Converters;
using WHA.Configuration;
using WHA.Repository;

namespace WHA.AutoFac
{
    public class InterfaceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(executingAssembly)
                .Where(y => !y.Name.EndsWith("Exception"))
                .Where(y => !y.Name.EndsWith("CombinedStock"))
                .Where(y => !y.Name.EndsWith("PlaceholderAttribute"))
                .AsImplementedInterfaces().PropertiesAutowired();
            builder.Register(c => c.Resolve<IConfigurationFactory>().LoadDefault()).AsSelf();
            builder.Register((_, _) => CreateDatabaseFactory().Open()).As<IDbConnection>().ExternallyOwned();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IFileSystem))!).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerLifetimeScope();

        }

        private static OrmLiteConnectionFactory CreateDatabaseFactory()
        {
            var cfg = new ConfigurationFactory().LoadDefault()?.MqSqlData;
            MySqlDialect.Provider.RegisterConverter<DateTime>(new DateTimeConverter());
            MySqlDialect.Provider.GetDateTimeConverter().DateStyle = DateTimeKind.Local;
            var connectionstring = "Server=" + cfg?.Server +
                                   ";Database=" + cfg?.Database +
                                   ";Uid=" + cfg?.Uid +
                                   ";Pwd=" + cfg?.Pwd + ";";
            return new OrmLiteConnectionFactory(connectionstring, MySqlDialect.Provider);
        }
    }
}
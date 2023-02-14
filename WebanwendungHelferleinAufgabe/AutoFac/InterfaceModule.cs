using System.Data;
using System.IO.Abstractions;
using System.Reflection;
using Autofac;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Converters;
using WebanwendungHelferleinAufgabe.Configuration;
using WebanwendungHelferleinAufgabe.Configuration.Struct;
using WebanwendungHelferleinAufgabe.Repository;

namespace WebanwendungHelferleinAufgabe.AutoFac
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
            builder.Register((c, p) => CreateDatabaseFactory().Open()).As<IDbConnection>().ExternallyOwned();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IFileSystem))!).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerLifetimeScope();

        }

        private Config Config { get; set; }
        private OrmLiteConnectionFactory CreateDatabaseFactory()
        {
            var cfg = new ConfigurationFactory().LoadDefault();
            MySqlDialect.Provider.RegisterConverter<DateTime>(new DateTimeConverter());
            MySqlDialect.Provider.GetDateTimeConverter().DateStyle = DateTimeKind.Local;
            var connectionstring = "";
                // "Server=" + cfg.Server +
                //                    ";Database=" + cfg.Database +
                //                    ";Uid=" + cfg.UID +
                //                    ";Pwd=" + cfg.PWD + ";";
            return new OrmLiteConnectionFactory(connectionstring, MySqlDialect.Provider);
        }
    }
}
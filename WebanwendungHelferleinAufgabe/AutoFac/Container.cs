using System.Data;
using System.IO.Abstractions;
using System.Reflection;
using Autofac;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Converters;

namespace WebanwendungHelferleinAufgabe.AutoFac;

public static class Container
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();
        builder.RegisterModule(new AutoMapperModule());
        builder.RegisterModule<InterfaceModule>();
        
        builder.RegisterType<MainWindow>().AsSelf();
        return builder.Build();
    }

}
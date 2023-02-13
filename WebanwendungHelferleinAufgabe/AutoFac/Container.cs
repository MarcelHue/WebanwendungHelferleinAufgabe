using System.IO.Abstractions;
using System.Reflection;
using Autofac;

namespace WebanwendungHelferleinAufgabe.AutoFac;

public class Container
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();
        builder.RegisterModule(new MainModule());
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(IFileSystem))!).AsImplementedInterfaces();
        // builder.Register(c => c.Resolve<IConfigurationFactory>().LoadDefault()).AsSelf().SingleInstance();
        // builder.Register(c => c.Resolve<IMqttClientFactory>().Create()).AsSelf().SingleInstance();
        builder.RegisterType<MainWindow>().AsSelf();
        return builder.Build();
    }
}
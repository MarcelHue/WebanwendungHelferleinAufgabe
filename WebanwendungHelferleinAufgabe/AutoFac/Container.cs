using Autofac;

namespace WHA.AutoFac;

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
using System.Reflection;
using Autofac;
using AutoMapper;
using Module = Autofac.Module;

namespace WebanwendungHelferleinAufgabe.AutoFac;

public class MainModule: Module
    {
        private static void RegisterServices(ContainerBuilder builder) => RegisterAutoMapper(builder);

        private static void RegisterAutoMapper(ContainerBuilder builder)
        {
            var assembliesToScanArray = new[] { Assembly.GetExecutingAssembly() };

            var allTypes = assembliesToScanArray
                .Where(a => !a.IsDynamic && a.GetName().Name != nameof(AutoMapper))
                .Distinct()
                .SelectMany(a => a.DefinedTypes)
                .ToArray();

            var openTypes = new[]
            {
                typeof(IValueResolver<,,>),
                typeof(IMemberValueResolver<,,,>),
                typeof(ITypeConverter<,>),
                typeof(IValueConverter<,>),
                typeof(IMappingAction<,>),
            };

            foreach(var type in openTypes.SelectMany(
                        openType =>
                            allTypes.Where(
                                t => t.IsClass && !t.IsAbstract && ImplementsGenericInterface(t.AsType(), openType))))
            {
                builder.RegisterType(type.AsType()).InstancePerDependency();
            }

            builder.Register<IConfigurationProvider>(
                _ => new MapperConfiguration(cfg => cfg.AddMaps(assembliesToScanArray)));

            builder.Register(
                    c =>
                    {
                        var context = c.Resolve<IComponentContext>();
                        var config = context.Resolve<IConfigurationProvider>();
                        return config.CreateMapper(context.Resolve);
                    })
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }

        private static bool ImplementsGenericInterface(Type type, Type interfaceType) =>
            IsGenericType(type, interfaceType) ||
            type.GetTypeInfo()
                .ImplementedInterfaces
                .Any(@interface => IsGenericType(@interface, interfaceType));

        private static bool IsGenericType(Type type, Type genericType) =>
            type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == genericType;

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(y => !y.Name.EndsWith("Exception"))
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();

            RegisterServices(builder);
        }
    }
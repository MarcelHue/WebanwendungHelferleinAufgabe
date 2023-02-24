using System.Reflection;
using Autofac;
using AutoMapper;

namespace WebanwendungHelferleinAufgabe.AutoFac
{
    public class AutoMapperModule : Autofac.Module
    {
        private readonly IEnumerable<Assembly> assembliesToScan;

        public AutoMapperModule(IEnumerable<Assembly> assembliesToScan) => this.assembliesToScan = assembliesToScan;

        public AutoMapperModule(params Assembly[] assembliesToScan)
            : this((IEnumerable<Assembly>)assembliesToScan)
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var assembliesToScanArray = this.assembliesToScan as Assembly[] ?? this.assembliesToScan.ToArray();

            var allTypes = assembliesToScanArray
                .Where(a => !a.IsDynamic && a.GetName().Name != nameof(AutoMapper))
                .Distinct() // avoid AutoMapper.DuplicateTypeMapConfigurationException
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

            foreach (var type in openTypes.SelectMany(openType =>
                allTypes.Where(t => t.IsClass && !t.IsAbstract && ImplementsGenericInterface(t.AsType(), openType))))
            {
                builder.RegisterType(type.AsType()).InstancePerDependency();
            }

            builder.Register<IConfigurationProvider>(ctx =>
                new MapperConfiguration(cfg => cfg.AddMaps(assembliesToScanArray)));

            builder.Register(c =>
                {
                    //This resolves a new context that can be used lateron.
                    var context = c.Resolve<IComponentContext>();
                    var config = context.Resolve<IConfigurationProvider>();
                    return config.CreateMapper(context.Resolve);
                })
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }

        private static bool ImplementsGenericInterface(Type type, Type interfaceType)
            => IsGenericType(type, interfaceType) || type.GetTypeInfo().ImplementedInterfaces
                .Any(@interface => IsGenericType(@interface, interfaceType));

        private static bool IsGenericType(Type type, Type genericType)
            => type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == genericType;
    }
}

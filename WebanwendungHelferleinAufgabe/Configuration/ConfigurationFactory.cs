using System.IO.Abstractions;
using System.Reflection;
using Newtonsoft.Json;
using WHA.Configuration.Struct;

namespace WHA.Configuration;

public class ConfigurationFactory : IConfigurationFactory
{
    private readonly IFileSystem fileSystem;

    public ConfigurationFactory()
    {
        this.fileSystem = new FileSystem();
    }

    public Config LoadDefault() => this.Load<Config>("config.json");

    private T Load<T>(string configFile)
    {
        var assemblyFolder = new Uri(Assembly.GetExecutingAssembly().Location).LocalPath;
        var path = this.fileSystem.Path.GetDirectoryName(assemblyFolder) + Path.DirectorySeparatorChar;

        using var reader = new StreamReader(path + configFile);
        var fileContent = reader.ReadToEnd();

        return JsonConvert.DeserializeObject<T>(fileContent);
    }
}
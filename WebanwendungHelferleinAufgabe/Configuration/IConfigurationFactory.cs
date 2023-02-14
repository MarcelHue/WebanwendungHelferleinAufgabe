using Google.Protobuf.WellKnownTypes;

namespace WebanwendungHelferleinAufgabe.Configuration;

public interface IConfigurationFactory
{
    Struct.Config LoadDefault();
}
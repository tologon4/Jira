using System.Reflection;
using AutoMapper;

namespace Jira.Application.Common.Mappings;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile()
        : this(Assembly.GetExecutingAssembly()) { }
    public AssemblyMappingProfile(Assembly assembly) => ApplyMaapingsFromAssembly(assembly);

    private void ApplyMaapingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
    
    
    
}
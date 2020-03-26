using AutoMapper;
using System;
using System.Linq;
using System.Reflection;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var exportedTypes = assembly.GetExportedTypes();
            var interfaces = exportedTypes.Where(x => x.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IViewOf<>)));
            var tests = exportedTypes.SelectMany(x => x.GetInterfaces().Where(i => i.IsGenericType).Select(i => i.GetGenericTypeDefinition()));

            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IViewOf<>)))
                .ToList();

            foreach (var type in types)
            {
                if (!type.ContainsGenericParameters)
                {
                    var instance = Activator.CreateInstance(type);
                    var methodInfo = type.GetMethod("Mapping");
                    if (methodInfo != null)
                    {
                        methodInfo?.Invoke(instance, new object[] { this });
                    }
                    else
                    {
                        methodInfo = type.GetInterfaces().Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IViewOf<>)).Single().GetMethod("Mapping");
                        methodInfo?.Invoke(instance, new object[] { this });
                    }
                }
            }
        }
    }
}

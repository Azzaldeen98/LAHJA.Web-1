using AutoGenerator.Enums;
using System.Reflection;

namespace AutoGenerator.Config.Attributes
{
    public class MethodRouteProviderAttribute : Attribute
    {
        public Dictionary<SupportedMethods, (string Target, string[] CustomParams)> Routes { get; }

        public MethodRouteProviderAttribute(Type routeMapType)
        {
            var field = routeMapType.GetField("Routes", BindingFlags.Static | BindingFlags.Public);
            if (field == null)
                throw new ArgumentException("Expected public static field 'Routes'.");

            var routes = field.GetValue(null) as (SupportedMethods Method, string Target, string[] CustomParams)[];
            if (routes == null)
                throw new ArgumentException("'Routes' must be of type (SupportedMethods, string, string[])[]");

            Routes = routes
                .GroupBy(r => r.Method)
                .ToDictionary(g => g.Key, g =>
                {
                    if (g.Count() > 1)
                        throw new InvalidOperationException($"Duplicate mapping for: {g.Key}");
                    var first = g.First();
                    return (first.Target, first.CustomParams);
                });
        }
    }





}

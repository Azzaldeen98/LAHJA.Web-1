namespace AutoGenerator.Code;
using AutoGenerator.Config.Attributes;

using Shared.Interfaces;
using System;
using System.Linq;
using System.Reflection;

public partial class ModelInspector
{
    public static void InspectModels<TInterface>(Assembly assembly)
    {
      
        var dsoModels = assembly.GetTypes()
            .Where(t => typeof(TInterface).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
            .ToList();

        foreach (var model in dsoModels)
        {
            Console.WriteLine($"Model: {model.Name}");

            var properties = model.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                Console.WriteLine($"  - Property: {prop.Name}, Type: {prop.PropertyType.Name}");

                // فحص ما إذا كانت الخاصية تحمل سمة [Filterable]
                var isFilterable = prop.GetCustomAttributes(typeof(FilterableAttribute), inherit: true).Any();
                if (isFilterable)
                {
                    Console.WriteLine($"    * This property is marked as [Filterable]");
                }
            }

            Console.WriteLine();
        }
    }

}

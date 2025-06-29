namespace AutoGenerator.CodeAnalysis;

using AutoGenerator.Attributes;
using Shared.Interfaces;
using System;
using System.Linq;
using System.Reflection;

/// <summary>
/// Provides functionality to inspect model classes that implement a specific interface,
/// extracting public properties and identifying custom attributes such as [Filterable].
/// Useful for metadata analysis, dynamic filtering, and UI generation tools.
/// </summary>
public partial class ModelMetadataInspector
{

    /// <summary>
    /// Inspects model types within the given assembly that implement <typeparamref name="TInterface"/>,
    /// prints their properties, and checks for the presence of specific attributes like [Filterable].
    /// </summary>
    /// <typeparam name="TInterface">The interface that target model classes implement.</typeparam>
    /// <param name="assembly">The assembly containing the model types to inspect.</param>
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

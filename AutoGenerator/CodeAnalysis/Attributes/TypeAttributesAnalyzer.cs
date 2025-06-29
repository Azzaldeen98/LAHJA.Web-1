namespace AutoGenerator.CodeAnalysis.Attributes;
using System;
using System.Linq;
using System.Reflection;



/// <summary>
/// Provides functionality to analyze and retrieve attributes applied on types, their properties, and fields.
/// This class utilizes reflection to inspect custom attributes applied to classes, properties, and fields within an assembly.
/// </summary>
public class TypeAttributesAnalyzer
{    
    /// <summary>
    /// Analyzes and prints information about all classes within the specified assembly
    /// that implement the given interface <typeparamref name="TInterface"/>.
    /// For each class, it lists the class attributes, properties, and property attributes.
    /// </summary>
    /// <typeparam name="TInterface">The interface type to filter classes by.</typeparam>
    /// <param name="assembly">The assembly to scan for types.</param>
    public static void AnalyzeModelsFromInterface<TInterface>(Assembly assembly)
        {
            var modelTypes = assembly.GetTypes()
                .Where(t => typeof(TInterface).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                .ToList();

            foreach (var type in modelTypes)
            {
                Console.WriteLine($"📦 Class: {type.Name}");

                // قراءة السمات الخاصة بالكلاس
                var classAttributes = GetClassAttributes(type);
                foreach (var attr in classAttributes)
                {
                    Console.WriteLine($"  🔖 [Class Attribute] {attr.GetType().Name}");
                }

                Console.WriteLine($"  🧩 Properties:");
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var prop in properties)
                {
                    Console.WriteLine($"    - Property: {prop.Name} ({prop.PropertyType.Name})");

                    // قراءة السمات الخاصة بالخاصية
                    var propertyAttributes = prop.GetCustomAttributes(true);
                    foreach (var attr in propertyAttributes)
                    {
                        Console.WriteLine($"      🔖 [Property Attribute] {attr.GetType().Name}");
                    }
                }

                Console.WriteLine();
            }
        }
    /// <summary>
    /// Gets all custom attributes applied directly on the specified <paramref name="type"/>.
    /// </summary>
    /// <param name="type">The type (class) to inspect.</param>
    /// <param name="withInherited">If true, includes inherited attributes; otherwise, only attributes declared on the type itself.</param>
    /// <returns>An array of attributes applied on the class.</returns>
    public static object[] GetClassAttributes(Type type, bool withInherited = false)
        {
            Console.WriteLine($"Attributes on class: {type.Name}");

            // السمات على الكلاس نفسه
            return type.GetCustomAttributes(withInherited);
        }
    /// <summary>
    /// Gets all custom attributes applied to each property of the specified <paramref name="type"/>.
    /// </summary>
    /// <param name="type">The type whose properties are inspected.</param>
    /// <param name="withInherited">If true, includes inherited attributes on properties.</param>
    /// <returns>
    /// A dictionary where each key is a <see cref="PropertyInfo"/> and the value is an array of attributes applied on that property.
    /// </returns>
    public static Dictionary<PropertyInfo, object[]> GetPropertiesAttributes(Type type, bool withInherited = false) {


            var attributes = new Dictionary<PropertyInfo, object[]>();
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

            // السمات على الخصائص
            foreach (var prop in type.GetProperties(bindingFlags))
            {
                var propAttributes = prop.GetCustomAttributes(withInherited);
                attributes[prop] = propAttributes;

            }

            return attributes;
        }
    /// <summary>
    /// Gets all custom attributes applied to each field of the specified <paramref name="type"/>.
    /// </summary>
    /// <param name="type">The type whose fields are inspected.</param>
    /// <param name="withInherited">If true, includes inherited attributes on fields.</param>
    /// <returns>
    /// A dictionary where each key is a <see cref="FieldInfo"/> and the value is an array of attributes applied on that field.
    /// </returns>
    public static Dictionary<FieldInfo, object[]> GetFieldsAttributes(Type type, bool withInherited = false)
        {
            var attributes = new Dictionary<FieldInfo, object[]>();

            // BindingFlags to include non-public and inherited fields if needed
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

            foreach (var field in type.GetFields(bindingFlags))
            {
                var fieldAttributes = field.GetCustomAttributes(withInherited);
                if (fieldAttributes.Any())
                {
                    attributes[field] = fieldAttributes.ToArray();
                }
            }

            return attributes;
        }


}

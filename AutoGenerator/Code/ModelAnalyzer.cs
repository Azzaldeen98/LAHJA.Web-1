namespace AutoGenerator.Code;
using System;
using System.Linq;
using System.Reflection;


public class ModelAnalyzer
{
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

        public static object[] GetClassAttributes(Type type, bool withInherited = false)
        {
            Console.WriteLine($"Attributes on class: {type.Name}");

            // السمات على الكلاس نفسه
            return type.GetCustomAttributes(withInherited);
        }

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

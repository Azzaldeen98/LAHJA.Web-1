using System.Formats.Asn1;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace AutoGenerator.Config;

public class TypeFilterBuilder
{
    private Func<Type, bool> _predicate = t => true;

    /// <summary>
    /// Filters types that belong to the specified namespace.
    /// </summary>
    public TypeFilterBuilder InNamespace(string Namespace)
    {
        if(!string.IsNullOrWhiteSpace(Namespace))
                _predicate = Combine(_predicate, t => t.Namespace == Namespace);

        return this;
    }

    /// <summary>
    /// Filters types that implement the specified interface.
    /// </summary>
    public TypeFilterBuilder IsImplementInterface<TInterface>(bool flag = true)
    {
        if (typeof(TInterface).IsInterface)
            _predicate = Combine(_predicate, t => typeof(TInterface).IsAssignableFrom(t) == flag);
        return this;
    }
    public TypeFilterBuilder IsImplementInterface(Type interfaceType, bool flag = true)
    {
        if(interfaceType!=null && interfaceType.IsInterface)
            _predicate = Combine(_predicate, t => interfaceType.IsAssignableFrom(t) == flag);
        return this;
    }

    /// <summary>
    /// Filters types that are decorated with the specified attribute.
    /// </summary>
    public TypeFilterBuilder HasAttribute<TAttribute>(bool flag = true) 
    {

       
        _predicate = Combine(_predicate, t => t.GetCustomAttributes(typeof(TAttribute), true).Any() == flag);
        return this;
    }

    public object[] GetAttributes<TClass>(bool inherit = true) 
    {
        return typeof(TClass).GetCustomAttributes(inherit);
    }    
    public MethodInfo[] GetMethods<TClass>() 
    {
        return typeof(TClass).GetMethods();
    }    
    public PropertyInfo[] GetProperties<TClass>() 
    {
        return typeof(TClass).GetProperties();
    }

    /// <summary>
    /// Filters types that are classes.
    /// </summary>
    public TypeFilterBuilder IsClass(bool flag = true)
    {
        _predicate = Combine(_predicate, t => t.IsClass == flag);
        return this;
    }

    /// <summary>
    /// Filters types that are abstract.
    /// </summary>
    public TypeFilterBuilder IsAbstract(bool flag = true)
    {
        _predicate = Combine(_predicate, t => t.IsAbstract == flag);
        return this;
    }
    public TypeFilterBuilder WhereNameStartWith(string text,bool shouldExist = true)
    {
        if (!string.IsNullOrWhiteSpace(text))
            _predicate = Combine(_predicate, t => t.Name.StartsWith(text));
        return this;
    }
    public TypeFilterBuilder WhereNameEndWith(string text, bool shouldExist = true)
    {
        if (!string.IsNullOrWhiteSpace(text))
            _predicate = Combine(_predicate, t => t.Name.EndsWith(text));
        return this;
    }

    public TypeFilterBuilder WhereNameContains(string text, bool shouldExist = true)
    {
        if(!string.IsNullOrWhiteSpace(text))
            _predicate = Combine(_predicate, t => t.Name.Contains(text));
        return this;
    }
    /// <summary>
    /// Filters types that are public.
    /// </summary>
    public TypeFilterBuilder IsPublic(bool flag = true)
    {
        _predicate = Combine(_predicate, t => t.IsPublic == flag);
        return this;
    }

    /// <summary>
    /// Filters types that have a parameterless constructor.
    /// </summary>
    public TypeFilterBuilder HasParameterlessConstructor(bool flag = true)
    {
        _predicate = Combine(_predicate, t => t.GetConstructor(Type.EmptyTypes) != null == flag);
        return this;
    }

    /// <summary>
    /// Filters types that have a constructor with the specified parameter types.
    /// </summary>
    public TypeFilterBuilder HasConstructor(bool flag, params Type[] parameterTypes)
    {
        _predicate = Combine(_predicate, t => t.GetConstructor(parameterTypes) != null == flag);
        return this;
    }

    /// <summary>
    /// Filters types based on whether they have any constructors.
    /// </summary>
    public TypeFilterBuilder HasConstructors(bool flag = true)
    {
        _predicate = Combine(_predicate, t => t.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Any(c => c.GetParameters().Length > 0) == flag);
        return this;
    }

    /// <summary>
    /// Filters types based on whether they have any methods.
    /// </summary>
    public TypeFilterBuilder HasMethods(bool flag = true)
    {
        //| BindingFlags.DeclaredOnly
        _predicate = Combine(_predicate, t => t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly).Any(m => !m.IsSpecialName) == flag);
        return this;
    }
    /// <summary>
    /// Filters types that do not inherit from any class other than System.Object.
    /// </summary>
    public TypeFilterBuilder DoesInheritFrom(Type type, bool shouldExist = true)
    {
        _predicate = Combine(_predicate, t =>
            type.IsAssignableFrom(t) == shouldExist);
        return this;
    }

    /// <summary>
    /// Filters types that do not inherit from any class other than System.Object.
    /// </summary>
    public TypeFilterBuilder DoesInherit(bool shouldExist = true)
    {
        return DoesInheritFrom(typeof(object), shouldExist);
    }
    /// <summary>
    /// Filters types that are generic classes.
    /// </summary>
    public TypeFilterBuilder IsGenericType(bool shouldBeGeneric = true)
    {
        _predicate = Combine(_predicate, t => t.IsGenericType == shouldBeGeneric);
        return this;
    }
    /// <summary>
    /// Filters types that have at least one generic method.
    /// </summary>
    public TypeFilterBuilder HasGenericMethods(bool shouldExist = true)
    {
        _predicate = Combine(_predicate, t =>
        {
            var methods = t.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            var hasGeneric = methods.Any(m => m.IsGenericMethod);
            return hasGeneric == shouldExist;
        });
        return this;
    }

    public TypeFilterBuilder HasNonSpecialMethods(bool shouldExist = true)
    {
        _predicate = Combine(_predicate, t =>
        {
            var methods = t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);
            var hasNonSpecialMethods = methods.Any(m => !m.IsSpecialName);
            return hasNonSpecialMethods == shouldExist;
        });
        return this;
    }


    /// <summary>
    /// Filters types that are static classes.
    /// </summary>
    public TypeFilterBuilder IsStaticClass(bool flag = true)
    {
        _predicate = Combine(_predicate, t => (t.IsAbstract && t.IsSealed && t.IsClass) == flag);
        return this;
    }
    /// <summary>
    /// Filters types based on the presence or absence of static methods.
    /// </summary>
    /// <param name="shouldExist">
    /// If true, filters types that have at least one static method.
    /// If false, filters types that have no static methods.
    /// Default is true.
    /// </param>
    /// <returns>The current builder instance.</returns>
    public TypeFilterBuilder HasStaticMethods(bool shouldExist = true)
    {
        _predicate = Combine(_predicate, t =>
        {
            var hasStaticMethods = t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Any();
            return hasStaticMethods == shouldExist;
        });
        return this;
    }

    /// <summary>
    /// Filters types based on the presence or absence of static properties.
    /// </summary>
    /// <param name="shouldExist">
    /// If true, filters types that have at least one static property.
    /// If false, filters types that have no static properties.
    /// Default is true.
    /// </param>
    /// <returns>The current builder instance.</returns>
    public TypeFilterBuilder HasStaticProperties(bool shouldExist = true)
    {
        _predicate = Combine(_predicate, t =>
        {
            var hasStaticProperties = t.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Any();
            return hasStaticProperties == shouldExist;
        });
        return this;
    }

    /// <summary>
    /// Filters types based on the presence or absence of methods matching the given binding flags.
    /// </summary>
    public TypeFilterBuilder HasMethods(BindingFlags bindingFlags, bool shouldExist = true)
    {
        _predicate = Combine(_predicate, t =>
        {
            var methods = t.GetMethods(bindingFlags);
            return methods.Length > 0 == shouldExist;
        });

        return this;
    }

    /// <summary>
    /// Filters types based on the presence or absence of properties matching the given binding flags.
    /// </summary>
    public TypeFilterBuilder HasProperties(BindingFlags bindingFlags, bool shouldExist = true)
    {
        _predicate = Combine(_predicate, t =>
        {
            var props = t.GetProperties(bindingFlags);
            return props.Length > 0 == shouldExist;
        });

        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public TypeFilterBuilder Custom(Func<Type, bool> predicate)
    {
        _predicate = Combine(_predicate, predicate);
        return this;
    }

    /// <summary>
    /// Combines two predicates using logical AND.
    /// </summary>
    private Func<Type, bool> Combine(Func<Type, bool> first, Func<Type, bool> second)
    {
        return t => first(t) && second(t);
    }

    /// <summary>
    /// Builds and returns the combined predicate based on all applied filters.
    /// </summary>
    public Func<Type, bool> Build() => _predicate;
}


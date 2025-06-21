//using Castle.DynamicProxy;
//
//using System.Diagnostics.CodeAnalysis;
//using System.Reflection;
//namespace LAHJA.Services.Infrastructure.Extensions;
//public static class ErrorServiceCollectionExtensions
//{


//    public static IServiceCollection AddWithInterceptor<TService>(this IServiceCollection services)
//        where TService : class
//    {
//        services.AddSingleton(provider =>
//        {
//            var proxyGenerator = new ProxyGenerator();
//            var interceptor = provider.GetRequiredService<ErrorHandlingInterceptor>();
//            var actualInstance = ActivatorUtilities.CreateInstance<TService>(provider);

//            return proxyGenerator.CreateClassProxyWithTarget(
//                typeof(TService),
//                actualInstance,
//                interceptor);
//        });
//        return services;
//    }


//    public static void RegistersGenericServices<TInterface>(this IServiceCollection services)
//    {
//        var interfaceType = typeof(TInterface);
//        var assembly = Assembly.GetExecutingAssembly();

//        var typesToRegister = assembly.GetTypes()
//            .Where(t => t.IsClass && !t.IsAbstract && interfaceType.IsAssignableFrom(t))
//            .ToList();

//        var methodInfo = typeof(ErrorServiceCollectionExtensions)
//            .GetMethods(BindingFlags.Static | BindingFlags.Public)
//            .First(m => m.Name == "AddWithInterceptor" && m.IsGenericMethod);


//        foreach (var type in typesToRegister)
//        {
//            var genericMethod = methodInfo.MakeGenericMethod(type);
//            genericMethod.Invoke(null, new object[] { services });
//        }
//    }


//    public static IServiceCollection AddScopedWithInterceptor<TInterface, TImplementation, TInterceptor>(
//            this IServiceCollection services)
//            where TInterface : class
//            where TImplementation : class, TInterface
//            where TInterceptor : class, IInterceptor
//    {
//        //services.AddSingleton<ProxyGenerator>();
//        //services.AddSingleton<ErrorHandlingInterceptor>(); 
//        //services.AddScoped<TImplementation>();

//        services.AddScoped<TInterface>(provider =>
//        {
//            var generator = provider.GetRequiredService<ProxyGenerator>();
//            var interceptor = provider.GetRequiredService<TInterceptor>();// ErrorHandlingInterceptor>();
//            var implementation = provider.GetRequiredService<TImplementation>();

//            return generator.CreateInterfaceProxyWithTarget<TInterface>(implementation, interceptor);
//        });

//        return services;
//    }

//    public static IServiceCollection AddScopedWithInterceptor<TService, TInterceptor>(
//    this IServiceCollection services)
//    where TService : class
//    where TInterceptor : class, IInterceptor
//    {

//        // إضافة TService كخدمة Scoped عبر Proxy
//        services.AddScoped<TService>(provider =>
//        {
//            var generator = provider.GetRequiredService<ProxyGenerator>();
//            var interceptor = provider.GetRequiredService<TInterceptor>();// ErrorHandlingInterceptor>();
//            var implementation = provider.GetRequiredService<TService>();

//            // هنا نتحقق إذا كان TService هو فئة أو واجهة
//            if (typeof(TService).IsInterface)
//            {
//                // إذا كانت TService واجهة، نستخدم CreateInterfaceProxyWithTarget
//                return generator.CreateInterfaceProxyWithTarget<TService>(implementation, interceptor);
//            }
//            else
//            {
//                // إذا كانت TService فئة، نستخدم CreateClassProxyWithTarget
//                return generator.CreateClassProxyWithTarget<TService>(implementation, interceptor);
//            }
//        });

//        return services;
//    }

//}

using AutoGenerator.CodeAnalysis.Injections;

namespace AutoGenerator.Config
{
    /// <summary>
    /// Factory class responsible for creating instances of <see cref="ICodeInjectionService"/> 
    /// based on the specified <see cref="InjectionType"/>.
    /// </summary>
    public static class CodeInjectionServiceFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="ICodeInjectionService"/> corresponding to the given injection type.
        /// </summary>
        /// <param name="injectionType">The type of code injection to create a service for.</param>
        /// <returns>An implementation of <see cref="ICodeInjectionService"/>.</returns>
        /// <exception cref="NotSupportedException">Thrown when the specified injection type is not supported.</exception>
        public static ICodeInjectionService CreateService(InjectionType injectionType)
        {
            return injectionType switch
            {
                InjectionType.Interface => new InterfaceInjectionService(),
                // InjectionType.Property => new PropertyInjectionService(),
                // InjectionType.Method => new MethodInjectionService(),
                _ => throw new NotSupportedException($"InjectionType {injectionType} is not supported"),
            };
        }
    }


}

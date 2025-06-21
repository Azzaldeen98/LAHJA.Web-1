namespace AutoGenerator.Config
{
    public static class CodeInjectionServiceFactory
    {
        public static ICodeInjectionService CreateService(InjectionType injectionType)
        {
            return injectionType switch
            {
                InjectionType.Interface =>  new InterfaceInjectionService(),
                //InjectionType.Property => new PropertyInjectionService(),
                //InjectionType.Method => new MethodInjectionService(),
                _ => throw new NotSupportedException($"InjectionType {injectionType} is not supported"),
            };
        }
    }

    }

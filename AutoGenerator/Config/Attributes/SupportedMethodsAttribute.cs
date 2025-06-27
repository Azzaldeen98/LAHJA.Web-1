using AutoGenerator.Enums;

namespace AutoGenerator.Config.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class SupportedMethodsAttribute : Attribute
    {
        public SupportedMethods Methods { get; }
        public string [] MethodsName { get; }

        public SupportedMethodsAttribute(SupportedMethods methods= SupportedMethods.GetAll)
        {
            Methods = methods;
        }

        public SupportedMethodsAttribute(params string [] methods )
        {
            MethodsName = methods;
        }
    } 


}

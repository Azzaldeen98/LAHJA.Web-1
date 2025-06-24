using AutoGenerator.Enums;

namespace AutoGenerator.Config.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SupportedMethodsAttribute : Attribute
    {
        public SupportedMethods Methods { get; }
        public SupportedMethodsAttribute(SupportedMethods methods= SupportedMethods.GetAll)
        {
            Methods = methods;
        }
    } 


}

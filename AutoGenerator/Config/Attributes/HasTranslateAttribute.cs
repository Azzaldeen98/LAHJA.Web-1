using AutoGenerator.Enums;

namespace AutoGenerator.Config.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class HasTranslateAttribute : Attribute
    {
        public bool IsTranslate { get; }
        public SupportedMethods  Methods { get; }
        public string []  MethodsName { get; }

        public HasTranslateAttribute(bool isTranslate=true)
        {
            IsTranslate = isTranslate;
        }

        public HasTranslateAttribute(SupportedMethods methods, bool isTranslate = true) : this(isTranslate)
        {
            Methods = methods;
        }
        public HasTranslateAttribute(params string[] methodsName) : this(true)
        {
            MethodsName = methodsName;
        }

        public HasTranslateAttribute(bool isTranslate = true,params string[] methodsName):this(isTranslate)
        {
            MethodsName = methodsName;
        }       
  
    }

}

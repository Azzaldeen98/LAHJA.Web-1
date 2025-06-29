namespace AutoGenerator.Attributes
{
    using AutoGenerator.Enums;
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AutoMapperAttribute : Attribute
    {
        public bool IsMapped { get; set; }
        public Type[] TargetTypes { get; }
        public SupportedMethods Methods { get; }


        public AutoMapperAttribute(SupportedMethods methods, bool isMapped = true)
        {
            IsMapped = isMapped;
            Methods = methods;
            TargetTypes = Array.Empty<Type>();

        }
        public AutoMapperAttribute(bool isMapped=true) 
        {
            IsMapped = isMapped;
            TargetTypes = Array.Empty<Type>();
            Methods = SupportedMethods.CUGET;
        }

        public AutoMapperAttribute(bool isMapped = true,params Type[] targetTypes) 
        {
            IsMapped = isMapped;
            TargetTypes = targetTypes;
            Methods = SupportedMethods.CUGET;
        }

   
    }

}

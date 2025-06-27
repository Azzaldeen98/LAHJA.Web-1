using AutoGenerator.Enums;

namespace AutoGenerator.Config.Attributes
{
    [AttributeUsage(AttributeTargets.Class , AllowMultiple = true)]
    public class MethodRouteAttribute : Attribute
    {
        public SupportedMethods SourceMethod { get; }
        public string TargetMethodName { get; }
        public string SourceMethodName { get; }
        public string[] CustomParams { get; }

        public MethodRouteAttribute(SupportedMethods sourceMethod, string targetMethodName="", params string[] customParams)
        {
            SourceMethod = sourceMethod;
            TargetMethodName = targetMethodName;
            CustomParams = customParams;
        }
        public MethodRouteAttribute(string sourceMethodName, string targetMethodName="", params string[] customParams)
        {
            SourceMethodName = sourceMethodName;
            TargetMethodName = targetMethodName;
            CustomParams = customParams;
        }


    }




}

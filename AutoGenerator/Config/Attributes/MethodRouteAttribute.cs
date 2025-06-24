using AutoGenerator.Enums;

namespace AutoGenerator.Config.Attributes
{
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method, AllowMultiple = true)]
    public class MethodRouteAttribute : Attribute
    {
        public SupportedMethods SourceMethod { get; set; }
        public string TargetMethodName { get; set; }


        public  Dictionary<SupportedMethods, string> TargetMethods = new Dictionary<SupportedMethods, string>();

        public MethodRouteAttribute(SupportedMethods sourceMethod,string targetMethodName)
        {

            if (!string.IsNullOrWhiteSpace(targetMethodName)) 
            {
                if (!TargetMethods.ContainsKey(sourceMethod)) 
                {
                    SourceMethod = sourceMethod;
                    TargetMethodName = targetMethodName;
                    TargetMethods.Add(sourceMethod, targetMethodName);
                }
                    
            }
                
        }
    }

}

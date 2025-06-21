namespace AutoGenerator.Config.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class IgnoreAutomateMapperAttribute : Attribute
    {
        public bool IgnoreMapping { get; set; }

        // Constructor with default value as true
        public IgnoreAutomateMapperAttribute(bool ignoreMapping = true)
        {
            IgnoreMapping = ignoreMapping;
        }
    }

}

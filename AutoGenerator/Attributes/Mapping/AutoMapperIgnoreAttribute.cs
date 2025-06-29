namespace AutoGenerator.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    
    public class AutoMapperIgnoreAttribute : Attribute
    {
        public bool IgnoreMapping { get; set; }

        // Constructor with default value as true
        public AutoMapperIgnoreAttribute(bool ignoreMapping = true)
        {
            IgnoreMapping = ignoreMapping;
        }
    }

}

namespace AutoGenerator.Config.Attributes
{
    using System;




    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class ServiceKeyAttribute : Attribute
    {
        public string Services { get; }

        public ServiceKeyAttribute(string service)
        {
            Services = service;
        }
    }
}

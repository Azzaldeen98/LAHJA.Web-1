using AutoGenerator.Enums;
using System;

namespace AutoGenerator.Config.Attributes
{
  

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class AutoGenerateAttribute : Attribute
    {
        public GenerationTarget GenerateTarget { get; }

        public AutoGenerateAttribute(GenerationTarget target)
        {
            GenerateTarget = target;
        }
    }

}

namespace AutoGenerator.Attributes
{
    using AutoGenerator.Enums;
    using System;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Class , AllowMultiple = true, Inherited= false)]


    public class AutomateMapperWithAttribute : Attribute
    {
        public LayersModels TargetLayerModel { get; }
        public string[] TargetTypes { get; }

        public AutomateMapperWithAttribute(LayersModels targetModel, params string[] targetTypes)
        {
            //foreach (var typeName in targetTypes)
            //{
            //    if (!IsValidClassNameWithPascalCase(typeName))
            //    {
            //        throw new ArgumentException($"Invalid class name: '{typeName}'. It must follow C# identifier naming rules.");
            //    }
            //}

            TargetLayerModel = targetModel;
            TargetTypes = targetTypes;
        }
        // تفرض معيار PascalCase  يجب ان يبداء الاسم بحرف كبير بالاضافة الى مراهاة قواعد التسمية للمتغيرات
        private bool IsValidClassNameWithPascalCase(string name)
        {
            return Regex.IsMatch(name, @"^[A-Z][a-zA-Z0-9]*$");
        }

        // يسمح بأسماء تبدأ بحرف أو underscore، وتليها أحرف أو أرقام أو underscore
        private bool IsValidClassName(string name)
        {
            return Regex.IsMatch(name, @"^[_a-zA-Z][_a-zA-Z0-9]*$");
        }
    }

    //public class AutomateMapperWithAttribute : Attribute
    //{
    //    public LayersModels TargetLayerModel { get; }
    //    public string[] TargetTypes { get; }


    //    public AutomateMapperWithAttribute(LayersModels targetModel, params string[] targetTypes)
    //    {
    //        TargetLayerModel = targetModel;
    //        TargetTypes = targetTypes;

    //    }


    //}

}

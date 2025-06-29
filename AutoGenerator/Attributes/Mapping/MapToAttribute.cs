namespace AutoGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class MapToAttribute : Attribute
    {
        public string TargetType { get; }
        public string TargetProperty { get; }

        public MapToAttribute(string targetType, string targetProperty)
        {
            TargetType = targetType?.ToUpperInvariant();
            TargetProperty = targetProperty;
        }
    }

}

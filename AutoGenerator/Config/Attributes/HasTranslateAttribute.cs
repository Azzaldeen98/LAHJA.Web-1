namespace AutoGenerator.Config.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class HasTranslateAttribute : Attribute
    {
        public bool IsTranslate { get; }

        public HasTranslateAttribute(bool isTranslate=true)
        {
            IsTranslate = isTranslate;
        }
    }

}

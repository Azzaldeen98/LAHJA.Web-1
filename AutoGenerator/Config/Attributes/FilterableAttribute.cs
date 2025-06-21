namespace AutoGenerator.Config.Attributes
{

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FilterableAttribute : Attribute
    {
        public string FilterName { get; }

        public FilterableAttribute() { }
        public FilterableAttribute(string filterName = null)
        {
            FilterName = filterName;
        }
    }




}

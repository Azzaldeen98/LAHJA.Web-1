namespace AutoGenerator.Config.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class MapEnabledAttribute : Attribute
    {
        public bool IsMapped { get; set; }

        // Constructor to define whether mapping is enabled or not.
        public MapEnabledAttribute(bool isMapped = true)
        {
            IsMapped = isMapped;
        }
    }
}

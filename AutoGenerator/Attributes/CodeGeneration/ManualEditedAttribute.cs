namespace AutoGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.All, AllowMultiple = false)]
    public class ManualEditedAttribute : Attribute
    {
        //public string GenerateTarget { get; }

        public ManualEditedAttribute()
        {
           
        }
    }

}

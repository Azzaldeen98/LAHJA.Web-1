namespace AutoGenerator.Config.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class RouteToAttribute : Attribute
    {

        public string Name { get; set; }
        //public string TargetName { get; set; }
        public RouteToAttribute(string name)
        {

            if (!string.IsNullOrWhiteSpace(name) )
            {
                Name = name;

            }

        }
    }

}

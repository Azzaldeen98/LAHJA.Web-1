namespace AutoGenerator.CodeAnalysis.Descriptors
{
    public class ClassDescriptor
    {
        public string Name { get; set; } = "";
        public List<MethodDescriptor> Methods { get; set; } = new();
        public List<PropertyDescriptor> Properties { get; set; } = new();
        public List<FieldDescriptor> Fields { get; set; } = new();

        public List<string> Attributes { get; set; } = new();

        public string? Code { get; set; }

    }


}

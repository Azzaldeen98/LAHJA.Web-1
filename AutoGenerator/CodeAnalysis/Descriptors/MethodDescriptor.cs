namespace AutoGenerator.CodeAnalysis.Descriptors
{
    public class MethodDescriptor
    {
        public string Name { get; set; } = "";
        public List<string> Attributes { get; set; } = new();
        public string? Code { get; set; }
    }


}

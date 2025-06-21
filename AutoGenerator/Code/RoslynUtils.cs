using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoGenerator.Code
{
    public static class RoslynUtils
    {
        public static SemanticModel CreateSemanticModel(SyntaxTree tree)
        {
            var references = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location))
                .Select(a => MetadataReference.CreateFromFile(a.Location))
                .Cast<MetadataReference>()
                .ToList();

            var compilation = CSharpCompilation.Create("TempCompilation")
                .AddReferences(references)
                .AddSyntaxTrees(tree);

            return compilation.GetSemanticModel(tree);
        }
    }
    
}

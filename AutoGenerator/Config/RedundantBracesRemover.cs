namespace AutoGenerator.Config
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public class RedundantBracesRemover : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            var outerBlock = node.Body;

            // إذا لم يكن هناك جسم دالة، نعود كما هو
            if (outerBlock == null || outerBlock.Statements.Count != 1)
                return base.VisitMethodDeclaration(node);

            // هل الجملة الوحيدة داخل جسم الدالة هي بلوك؟
            if (outerBlock.Statements[0] is BlockSyntax innerBlock)
            {
                // استبدل جسم الدالة بالبلوك الداخلي
                var newMethod = node.WithBody(innerBlock);
                return base.VisitMethodDeclaration(newMethod);
            }

            return base.VisitMethodDeclaration(node);
        }
    }





}

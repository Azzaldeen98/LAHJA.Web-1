namespace AutoGenerator.Config
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System.Linq;
    public class MethodBodyRewriter : CSharpSyntaxRewriter
    {
        private readonly Dictionary<string, string> _methodBodies;

        public MethodBodyRewriter(Dictionary<string, string> methodBodies)
        {
            _methodBodies = methodBodies;
        }
        //public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        //{
        //    // تحقق هل الدالة تحتوي على throw new NotImplementedException()
        //    var throwsNotImplemented = node.Body?.DescendantNodes()
        //        .OfType<ThrowStatementSyntax>()
        //        .Any(t => t.ToString().Contains("NotImplementedException")) ?? false;

        //    if (!throwsNotImplemented)
        //        return node;

        //    // هل يوجد كود جديد للدالة؟
        //    if (!_methodBodies.TryGetValue(node.Identifier.Text, out string newStatementsCode))
        //        return node;

        //    // معالجة الكود الجديد كسلسلة أو كـ Block كامل
        //    var blockSyntax = TryParseBlock(newStatementsCode);
        //    if (blockSyntax == null)
        //        return node; // كود غير صالح

        //    // التأكد من وجود async لو فيه await
        //    var isAsync = node.Modifiers.Any(m => m.IsKind(SyntaxKind.AsyncKeyword));
        //    var containsAwait = newStatementsCode.Contains("await");

        //    MethodDeclarationSyntax newMethod = node;

        //    if (containsAwait && !isAsync)
        //    {
        //        newMethod = node.WithModifiers(node.Modifiers.Add(SyntaxFactory.Token(SyntaxKind.AsyncKeyword)));
        //    }

        //    newMethod = newMethod.WithBody(blockSyntax);

        //    return newMethod;
        //}
        //private static BlockSyntax TryParseBlock(string code)
        //{
        //    // نحاول تحليل الكود كـ Block (يجب أن يبدأ بـ { وينتهي بـ })
        //    var tree = SyntaxFactory.ParseSyntaxTree(code);
        //    var root = tree.GetRoot();

        //    var block = root.DescendantNodes()
        //        .OfType<BlockSyntax>()
        //        .FirstOrDefault();

        //    return block;
        //}

        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            // تحقق هل الدالة تحتوي على throw new NotImplementedException()
            var throwsNotImplemented = node.Body?.DescendantNodes()
                .OfType<ThrowStatementSyntax>()
                .Any(t => t.ToString().Contains("NotImplementedException")) ?? false;


            if (!throwsNotImplemented)
                return node;

            // هل يوجد كود جديد للدالة؟
            if (!_methodBodies.TryGetValue(node.Identifier.Text, out string newStatementsCode))
                return node; // لا تعديل

            // توليد بلوك جديد للكود
            var newBody = SyntaxFactory.Block(SyntaxFactory.ParseStatement(newStatementsCode));

            // التأكد من وجود async لو فيه await
            var isAsync = node.Modifiers.Any(m => m.IsKind(SyntaxKind.AsyncKeyword));
            var containsAwait = newStatementsCode.Contains("await");

            MethodDeclarationSyntax newMethod = node;

            if (containsAwait && !isAsync)
            {
                newMethod = node.WithModifiers(node.Modifiers.Add(SyntaxFactory.Token(SyntaxKind.AsyncKeyword)));
            }

            newMethod = newMethod.WithBody(newBody);

            return newMethod;
        }
    }





}

namespace AutoGenerator.Config
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using System.Linq;
    /// <summary>
    /// A syntax rewriter that replaces method bodies based on a provided mapping of method names to new code.
    /// Specifically targets methods that contain a `throw new NotImplementedException()` statement.
    /// </summary>
    public class MethodBodyRewriter : CSharpSyntaxRewriter
    {
        private readonly Dictionary<string, string> _methodBodies;

        /// <summary>
        /// Initializes a new instance of <see cref="MethodBodyRewriter"/>.
        /// </summary>
        /// <param name="methodBodies">A dictionary mapping method names to their new method body code as strings.</param>
        public MethodBodyRewriter(Dictionary<string, string> methodBodies)
        {
            _methodBodies = methodBodies;
        }

        /// <summary>
        /// Visits method declarations in the syntax tree.
        /// If the method contains a `throw new NotImplementedException()` statement and a new body is provided,
        /// replaces the method body with the new code.
        /// Also adds the `async` modifier if the new code contains `await` but the method is not async.
        /// </summary>
        /// <param name="node">The method declaration syntax node to visit.</param>
        /// <returns>The modified method declaration syntax node if changes were made; otherwise, the original node.</returns>
        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            // Check if the method throws NotImplementedException
            var throwsNotImplemented = node.Body?.DescendantNodes()
                .OfType<ThrowStatementSyntax>()
                .Any(t => t.ToString().Contains("NotImplementedException")) ?? false;

            if (_methodBodies == null || !throwsNotImplemented)
                return node;

            // Check if a new method body exists for this method
            if (!_methodBodies.TryGetValue(node.Identifier.Text, out string newStatementsCode))
                return node; // no change

            // Create new method body block
            var newBody = SyntaxFactory.Block(SyntaxFactory.ParseStatement(newStatementsCode));

            // Detect async keyword if 'await' is used in new body
            var isAsync = node.Modifiers.Any(m => m.IsKind(SyntaxKind.AsyncKeyword));
            var containsAwait = newStatementsCode.Contains("await");

            MethodDeclarationSyntax newMethod = node;

            // Add async modifier if necessary
            if (containsAwait && !isAsync)
            {
                newMethod = node.WithModifiers(node.Modifiers.Add(SyntaxFactory.Token(SyntaxKind.AsyncKeyword)));
            }

            // Replace method body
            newMethod = newMethod.WithBody(newBody);

            return newMethod;
        }
    }






}

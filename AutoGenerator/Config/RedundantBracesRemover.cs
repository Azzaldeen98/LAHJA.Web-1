namespace AutoGenerator.Config
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// A syntax rewriter that removes redundant braces from method bodies.
    /// Specifically, it targets methods whose body contains a single statement,
    /// and that statement itself is a block (i.e., extra braces).
    /// In such cases, it replaces the method body with the inner block,
    /// effectively removing the redundant braces.
    /// </summary>
    public class RedundantBracesRemover : CSharpSyntaxRewriter
    {
        /// <summary>
        /// Visits a method declaration and removes redundant braces if the method's body
        /// consists of exactly one statement which is a block.
        /// </summary>
        /// <param name="node">The method declaration syntax node.</param>
        /// <returns>
        /// The modified method declaration node with redundant braces removed, 
        /// or the original node if no changes are required.
        /// </returns>
        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            var outerBlock = node.Body;

            // If method has no body or has more than one statement, no changes are made
            if (outerBlock == null || outerBlock.Statements.Count != 1)
                return base.VisitMethodDeclaration(node);

            // Check if the single statement is itself a block (redundant braces)
            if (outerBlock.Statements[0] is BlockSyntax innerBlock)
            {
                // Replace the method body with the inner block to remove redundancy
                var newMethod = node.WithBody(innerBlock);
                return base.VisitMethodDeclaration(newMethod);
            }

            return base.VisitMethodDeclaration(node);
        }
    }






}

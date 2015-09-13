using Microsoft.CodeAnalysis.CSharp;

namespace BITS.Compilers.CSharp.Syntax
{
    public abstract class CSharpSyntaxNode<TSelf, TSyntaxNode> : SyntaxNode<TSelf, TSyntaxNode>
        where TSelf : CSharpSyntaxNode<TSelf, TSyntaxNode>
        where TSyntaxNode : CSharpSyntaxNode
    {
        # region • Ctor's •

        internal protected CSharpSyntaxNode() {}

        internal protected CSharpSyntaxNode(TSyntaxNode @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's
    }
}

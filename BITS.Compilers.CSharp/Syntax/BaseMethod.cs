using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public abstract class BaseMethod<TSelf, TSyntaxNode> : Member<TSelf, TSyntaxNode>
        where TSelf : BaseMethod<TSelf, TSyntaxNode>
        where TSyntaxNode : BaseMethodDeclarationSyntax
    {
        # region • Ctor's •

        internal protected BaseMethod() {}

        internal protected BaseMethod(TSyntaxNode @syntaxNode)
            : base(@syntaxNode) { }

        # endregion Ctor's
    }
}
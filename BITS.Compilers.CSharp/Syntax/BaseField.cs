using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public abstract class BaseField<TSelf, TSyntaxNode> : Member<TSelf, TSyntaxNode>
        where TSelf : BaseField<TSelf, TSyntaxNode>
        where TSyntaxNode : BaseFieldDeclarationSyntax
    {
        # region • Ctor's •

        internal protected BaseField() {}

        internal protected BaseField(TSyntaxNode @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's
    }
}
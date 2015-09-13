using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public abstract class BaseProperty<TSelf, TSyntaxNode> : Member<TSelf, TSyntaxNode>
        where TSelf : BaseProperty<TSelf, TSyntaxNode>
        where TSyntaxNode : BasePropertyDeclarationSyntax
    {
        # region • Ctor's •

        internal protected BaseProperty() {}
        
        internal protected BaseProperty(TSyntaxNode @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's
    }
}
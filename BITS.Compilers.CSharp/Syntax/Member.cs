using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class Member : Member<Member>
    {
        # region • Ctor's •

        internal Member(MemberDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) { }

        # endregion Ctor's

        protected override Member New(MemberDeclarationSyntax @syntaxNode)
        {
            return new Member(@syntaxNode);
        }
    }

    public abstract class Member<TSelf> : Member<TSelf, MemberDeclarationSyntax>
        where TSelf : Member<TSelf>
    {
        # region • Ctor's •

        internal protected Member(MemberDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's
    }

    public abstract class Member<TSelf, TSyntaxNode> : CSharpSyntaxNode<TSelf, TSyntaxNode>
        where TSelf : Member<TSelf, TSyntaxNode>
        where TSyntaxNode : MemberDeclarationSyntax
    {
        # region • Ctor's •

        internal protected Member() {}

        internal protected Member(TSyntaxNode @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        public virtual TSelf GetPartial()
        {
            return default(TSelf);
        }

        public virtual IEnumerable<TSelf> AsPartial()
        {
            yield break;
        }
    }
}
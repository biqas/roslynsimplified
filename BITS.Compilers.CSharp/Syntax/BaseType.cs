using System;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public abstract class BaseType<TSelf, TSyntaxNode> : Member<TSelf, TSyntaxNode>
        where TSelf : BaseType<TSelf, TSyntaxNode>
        where TSyntaxNode : BaseTypeDeclarationSyntax
    {
        # region • Ctor's •

        internal protected BaseType() {}

        internal protected BaseType(TSyntaxNode @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Helper •

        public virtual String GetName()
        {
            return this.Syntax.GetName();
        }

        public virtual String GetFullName()
        {
            return this.Syntax.GetFullName();
        }

        # endregion Helper
    }
}
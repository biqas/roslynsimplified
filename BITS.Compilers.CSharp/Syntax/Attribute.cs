using System;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class Attribute : Attribute<Attribute>
    {
        # region • Ctor's •

        public Attribute(String @name)
            : base(@name) {}

        internal Attribute(AttributeSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        protected override Attribute New(AttributeSyntax @syntaxNode)
        {
            return new Attribute(@syntaxNode);
        }

        # endregion Methods
    }

    public abstract class Attribute<TSelf> : CSharpSyntaxNode<TSelf, AttributeSyntax>
       where TSelf : Attribute<TSelf>
    {
        # region • Ctor's •

        protected Attribute(String @name)
        {
            this.Init(Factory(@name));
        }

        internal protected Attribute(AttributeSyntax @syntaxNode)
            : base(@syntaxNode) { }

        # endregion Ctor's

        # region • Methods •

        # region • Initializations •

        public virtual TSelf Init(String @name)
        {
            return this.Init(
                Factory(@name));
        }

        # endregion Initializations

        # region • Arguments •

        public virtual TSelf AddArgument(String @expression)
        {
            return Self(this.Syntax
                .AddArgument(@expression));
        }

        public virtual TSelf AddArgument(String @name, String @expression)
        {
            return Self(this.Syntax
                .AddArgument(@name, @expression));
        }

        # endregion Argument

        # region • Factories •

        public static AttributeSyntax Factory(String @name)
        {
            return SyntaxFactory.Attribute(
                SyntaxFactory.ParseName(@name));
        }

        # endregion Factories

        # endregion Methods
    }
}

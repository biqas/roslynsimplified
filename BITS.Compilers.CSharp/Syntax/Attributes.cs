using System;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class Attributes : Attributes<Attributes>
    {
        # region • Ctor's •

        public Attributes(String @name)
            : base(@name) {}

        public Attributes(String @name, String @expression)
            : base(@name, @expression) {}

        public Attributes(String @name,
            String @argumentName, String @expression)
            : base(@name, @argumentName, @expression) {}

        internal Attributes(AttributeListSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        protected override Attributes New(AttributeListSyntax @syntaxNode)
        {
            return new Attributes(@syntaxNode);
        }

        # endregion Methods
    }

    public abstract class Attributes<TSelf> : SyntaxNode<TSelf, AttributeListSyntax>
        where TSelf : Attributes<TSelf>
    {
        # region • Ctor's •

        protected Attributes(String @name)
        {
            this.Init(Factory()
                .AddAttribute(@name));
        }

        protected Attributes(String @name, String @expression)
        {
            this.Init(Factory()
                .AddAttribute(@name, @expression));
        }

        protected Attributes(String @name,
            String @argumentName, String @expression)
        {
            this.Init(Factory()
                .AddAttribute(@name, @argumentName, @expression));
        }

        internal protected Attributes(AttributeListSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        # region • Initializations •

        public virtual TSelf Init(String @name)
        {
            return this.Init(Factory()
                .AddAttribute(@name));
        }

        public virtual TSelf Init(String @name, String @expression)
        {
            return this.Init(Factory()
                .AddAttribute(@name, @expression));
        }

        public virtual TSelf Init(String @name, String @argumentName,
            String @expression)
        {
            return this.Init(Factory()
                .AddAttribute(@name, @argumentName, @expression));
        }

        # endregion Initializations

        # region • Attributes •

        public virtual TSelf AddAttribute(String @name)
        {
            return Self(this.Syntax
                .AddAttribute(@name));
        }

        public virtual TSelf AddAttribute(String @name, String @expression)
        {
            return Self(this.Syntax
                .AddAttribute(@name, @expression));
        }

        public virtual TSelf AddAttribute(String @name, String @argumentName,
            String @expression)
        {
            return Self(this.Syntax
                .AddAttribute(@name, @argumentName, @expression));
        }

        # endregion Attributes

        # region • Factories •

        public static AttributeListSyntax Factory()
        {
            return Microsoft.CodeAnalysis.CSharp.SyntaxFactory.AttributeList();
        }

        # endregion Factories

        # endregion Methods
    }
}

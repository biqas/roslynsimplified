using System;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class Using : Using<Using>
    {
        # region • Ctor's •

        public Using(Namespace @namespace)
            : base(@namespace) { }

        public Using(String @identifier)
            : base(@identifier) { }

        public Using(String @alias, String @identifier)
            : base(@alias, @identifier) { }

        internal Using(UsingDirectiveSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        protected override Using New(UsingDirectiveSyntax @syntaxNode)
        {
            return new Using(@syntaxNode);
        }

        # endregion Methods
    }

    public abstract partial class Using<TSelf> : CSharpSyntaxNode<TSelf, UsingDirectiveSyntax>
        where TSelf : Using<TSelf>
    {
        # region • Ctor's •

        protected Using(Namespace @namespace)
        {
            this.Init(@namespace);
        }

        protected Using(String @identifier)
        {
            this.Init(@identifier);
        }

        protected Using(String @alias, String @identifier)
        {
            this.Init(@alias, @identifier);
        }

        internal protected Using(UsingDirectiveSyntax @syntaxNode)
            : base(@syntaxNode) { }

        # endregion Ctor's

        # region • Methods •

        # region • Initializations •

        public virtual TSelf Init(Namespace @namespace)
        {
            return this.Init(@namespace.Syntax.Name.ToFullString());
        }

        public virtual TSelf Init(String @identifier)
        {
            return this.Init(
                Factory(@identifier));
        }

        public virtual TSelf Init(String @alias, String @identifier)
        {
            return this.Init(
                Factory(@alias, @identifier));
        }

        # endregion Initializations

        # region • Alias •

        public virtual TSelf WithAlias<TType>(String @expression)
        {
            return Self(this.Syntax
                .WithAlias(@expression));
        }

        public virtual TSelf WithAlias(String @alias, String @identifier)
        {
            return Self(this.Syntax
                .WithAlias(@alias, @identifier));
        }

        # endregion Alias

        # region • Name •

        public virtual TSelf WithName(String @identifier)
        {
            return Self(this.Syntax
                .WithName(@identifier));
        }

        # endregion Name

        # region • Factories •

        public static UsingDirectiveSyntax Factory(String @identifier)
        {
            return SyntaxFactory.UsingDirective(
                SyntaxFactory.IdentifierName(@identifier));
        }

        public static UsingDirectiveSyntax Factory(String @alias, String @identifier)
        {
            return SyntaxFactory.UsingDirective(
                SyntaxFactory.IdentifierName(@identifier))
                .WithAlias(@alias, @identifier);
        }

        # endregion Factories

        # endregion Methods
    }
}

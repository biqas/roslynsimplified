using System;
using System.Collections.Generic;
using System.Linq;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class Indexer : Indexer<Indexer>
    {
        # region • Ctor's •

        public Indexer(Type @type)
            : base(@type) {}

        internal Indexer(IndexerDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        protected override Indexer New(IndexerDeclarationSyntax @syntaxNode)
        {
            return new Indexer(@syntaxNode);
        }

        # endregion Methods
    }

    public abstract class Indexer<TSelf> : BaseProperty<TSelf, IndexerDeclarationSyntax>
        where TSelf : Indexer<TSelf>
    {
        # region • Ctor's •

        protected Indexer(Type @type)
        {
            this.Init(Factory(@type));
        }

        internal protected Indexer(IndexerDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        # region • Initializations •

        public virtual TSelf Init<T, TE>(Type<T, TE> @type)
            where T : Type<T, TE>
            where TE : TypeDeclarationSyntax
        {
            return this.Init(Factory(@type));
        }

        public virtual TSelf Init<T>(Type<T> @type)
            where T : Type<T>
        {
            return this.Init(Factory(@type));
        }

        public virtual TSelf Init<T>(Type @type)
        {
            return this.Init(Factory(@type));
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

        public virtual IEnumerable<Attributes> GetAttributes()
        {
            return this.Syntax.GetAttributes()
                .Select(x => new Attributes(x));
        }

        # endregion Attributes

        # region • Modifiers •

        public virtual TSelf AddModifiers(MODIFIER @modifier)
        {
            return Self(this.Syntax
                .AddModifiers(@modifier));
        }

        public virtual TSelf WithModifiers(MODIFIER @modifier)
        {
            return Self(this.Syntax
                .WithModifiers(@modifier));
        }

        # endregion Modifiers

        # region • Type •

        public virtual TSelf WithType(TypeSyntax @typeSyntax)
        {
            return Self(this.Syntax
                .WithType(@typeSyntax));
        }

        public virtual TSelf WithType<T, TE>(Type<T, TE> @type)
            where T : Type<T, TE>
            where TE : TypeDeclarationSyntax
        {
            return Self(this.Syntax
                .WithType(@type.Syntax.GetTypeSyntax()));
        }

        public virtual TSelf WithType<TType>(Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .WithType<TType>(@withFullName));
        }

        public virtual TSelf WithType(System.Type @type,
            Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .WithType(@type, @withFullName));
        }

        public virtual TSelf WithType(String @typeName)
        {
            return Self(this.Syntax
                .WithType(@typeName));
        }

        # endregion Type

        # region • Parameters •

        public virtual TSelf AddParameter<TType>(
            String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax.AddParameter<TType>(
                @parameterName, @withFullName));
        }

        public virtual TSelf AddParameter(System.Type @type,
            String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax.AddParameter(
                @type, @parameterName, @withFullName));
        }

        public virtual TSelf AddParameter(
            String @typeName, String @parameterName)
        {
            return Self(this.Syntax.AddParameter(
                @typeName, @parameterName));
        }

        public virtual TSelf AddRefParameter<TType>(
            String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax.AddRefParameter<TType>(
                @parameterName, @withFullName));
        }

        public virtual TSelf AddRefParameter(System.Type @type,
            String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax.AddRefParameter(
                @type, @parameterName, @withFullName));
        }

        public virtual TSelf AddRefParameter(
            String @typeName, String @parameterName)
        {
            return Self(this.Syntax.AddRefParameter(
                @typeName, @parameterName));
        }

        public virtual TSelf AddParamsParameter<TType>(
            String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax.AddParamsParameter<TType>(
                @parameterName, @withFullName));
        }

        public virtual TSelf AddParamsParameter(System.Type @type,
            String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax.AddParamsParameter(
                @type, @parameterName, @withFullName));
        }

        public virtual TSelf AddParamsParameter(
            String @typeName, String @parameterName)
        {
            return Self(this.Syntax.AddParamsParameter(
                @typeName, @parameterName));
        }

        public virtual TSelf AddParameter<TType>(PARAMETER_TYPE @parameterType,
            String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax.AddParameter<TType>(@parameterType,
                @parameterName, @withFullName));
        }

        public virtual TSelf AddParameter(PARAMETER_TYPE @parameterType,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax.AddParameter(
                @parameterType, @type, @parameterName, @withFullName));
        }

        public virtual TSelf AddParameter(PARAMETER_TYPE @parameterType,
            String @typeName, String @parameterName)
        {
            return Self(this.Syntax.AddParameter(
                @parameterType, @typeName, @parameterName));
        }

        # endregion Parameters

        # region • Getter •

        public virtual TSelf WithGetter(MODIFIER @modifier)
        {
            return Self(this.Syntax
                .WithGetter(@modifier));
        }

        public virtual TSelf WithGetter(params String[] @statements)
        {
            return Self(this.Syntax
                .WithGetter(@statements));
        }

        public virtual TSelf WithGetter(Indexer.Getter @getter)
        {
            return Self(this.Syntax
                .WithGetter(@getter.Syntax));
        }

        public virtual TSelf WithGetter(AccessorDeclarationSyntax @getter)
        {
            return Self(this.Syntax
                .WithGetter(@getter));
        }

        # endregion Getter

        # region • Setter •

        public virtual TSelf WithSetter(MODIFIER @modifier)
        {
            return Self(this.Syntax
                .WithSetter(@modifier));
        }

        public virtual TSelf WithSetter(params String[] @statements)
        {
            return Self(this.Syntax
                .WithSetter(@statements));
        }

        public virtual TSelf WithSetter(Indexer.Setter @getter)
        {
            return Self(this.Syntax
                .WithSetter(@getter.Syntax));
        }

        public virtual TSelf WithSetter(AccessorDeclarationSyntax @getter)
        {
            return Self(this.Syntax
                .WithSetter(@getter));
        }

        # endregion Setter

        # region • Factories •

        public static IndexerDeclarationSyntax Factory(Type @type)
        {
            return SyntaxFactory.IndexerDeclaration(
                @type.Syntax.GetTypeSyntax());
        }

        public static IndexerDeclarationSyntax Factory<T>(Type<T> @type)
            where T : Type<T>
        {
            return SyntaxFactory.IndexerDeclaration(
                @type.Syntax.GetTypeSyntax());
        }

        public static IndexerDeclarationSyntax Factory<T, TE>(Type<T, TE> @type)
            where T : Type<T, TE>
            where TE : TypeDeclarationSyntax
        {
            return SyntaxFactory.IndexerDeclaration(
                @type.Syntax.GetTypeSyntax());
        }

        # endregion Factories

        # endregion Methods

        # region • Inner Classes •

        # region • Getter •

        public sealed class Getter : Getter<Getter>
        {
            # region • Ctor's •

            public Getter(Boolean @isAuto = true)
                : base(@isAuto) {}

            internal Getter(AccessorDeclarationSyntax @syntaxNode)
                : base(@syntaxNode) {}

            # endregion Ctor's
            
            # region • Methods •

            protected override Getter New(AccessorDeclarationSyntax @syntaxNode)
            {
                return new Getter(@syntaxNode);
            }

            # endregion Methods
        }

        public abstract class Getter<TInnerSelf> : CSharpSyntaxNode<TInnerSelf, AccessorDeclarationSyntax>
            where TInnerSelf : Getter<TInnerSelf>
        {
            # region • Ctor's •

            protected Getter(Boolean @isAuto = true)
            {
                this.Init(Factory(@isAuto));
            }

            internal protected Getter(AccessorDeclarationSyntax @syntaxNode)
                : base(@syntaxNode) {}

            # endregion Ctor's

            # region • Methods •

            # region • Initializations •

            public virtual TInnerSelf Init(Boolean @isAuto = true)
            {
                return this.Init(Factory(@isAuto));
            }

            # endregion Initializations

            # region • Attributes •

            public virtual TInnerSelf AddAttribute(String @name)
            {
                return Self(this.Syntax
                    .AddAttribute(@name));
            }

            public virtual TInnerSelf AddAttribute(String @name, String @expression)
            {
                return Self(this.Syntax
                    .AddAttribute(@name, @expression));
            }

            public virtual TInnerSelf AddAttribute(String @name, String @argumentName,
                String @expression)
            {
                return Self(this.Syntax
                    .AddAttribute(@name, @argumentName, @expression));
            }

            # endregion Attributes

            # region • Modifiers •

            public virtual TInnerSelf AddModifiers(MODIFIER @modifier)
            {
                return Self(this.Syntax
                    .AddModifiers(@modifier));
            }

            public virtual TInnerSelf WithModifiers(MODIFIER @modifier)
            {
                return Self(this.Syntax
                    .WithModifiers(@modifier));
            }

            # endregion Modifiers

            # region • Body •

            public virtual TInnerSelf WithBody(params String[] @statements)
            {
                return Self(this.Syntax
                    .WithBody(@statements));
            }

            # endregion Body

            # region • Statements •

            public virtual TInnerSelf AddStatements(params String[] @statements)
            {
                return Self(this.Syntax
                    .AddStatements(@statements));
            }

            public virtual TInnerSelf WithStatements(params String[] @statements)
            {
                return Self(this.Syntax
                    .WithStatements(@statements));
            }

            # endregion Statements

            # region • Factories •

            private static AccessorDeclarationSyntax Factory(Boolean @isAuto = true)
            {
                return SyntaxFactory.AccessorDeclaration(
                    SyntaxKind.GetAccessorDeclaration)
                    .IsAuto(@isAuto);
            }

            # endregion Factories

            # endregion Methods
        }

        # endregion Getter

        # region • Setter •

        public sealed class Setter : Setter<Setter>
        {
            # region • Ctor's •

            public Setter(Boolean @isAuto = true)
                : base(@isAuto) {}

            internal Setter(AccessorDeclarationSyntax @syntaxNode)
                : base(@syntaxNode) {}

            # endregion Ctor's

            # region • Methods •

            protected override Setter New(AccessorDeclarationSyntax @syntaxNode)
            {
                return new Setter(@syntaxNode);
            }

            # endregion Methods
        }

        public abstract class Setter<TInnerSelf> : CSharpSyntaxNode<TInnerSelf, AccessorDeclarationSyntax>
            where TInnerSelf : Setter<TInnerSelf>
        {
            # region • Ctor's •

            protected Setter(Boolean @isAuto = true)
            {
                this.Init(Factory(@isAuto));
            }

            internal protected Setter(AccessorDeclarationSyntax @syntaxNode)
                : base(@syntaxNode) {}

            # endregion Ctor's

            # region • Methods •

            # region • Initializations •

            public virtual TInnerSelf Init(Boolean @isAuto = true)
            {
                return this.Init(Factory(@isAuto));
            }

            # endregion Initializations

            # region • Attributes •

            public virtual TInnerSelf AddAttribute(String @name)
            {
                return Self(this.Syntax
                    .AddAttribute(@name));
            }

            public virtual TInnerSelf AddAttribute(String @name, String @expression)
            {
                return Self(this.Syntax
                    .AddAttribute(@name, @expression));
            }

            public virtual TInnerSelf AddAttribute(String @name, String @argumentName,
                String @expression)
            {
                return Self(this.Syntax
                    .AddAttribute(@name, @argumentName, @expression));
            }

            # endregion Attributes

            # region • Modifiers •

            public virtual TInnerSelf AddModifiers(MODIFIER @modifier)
            {
                return Self(this.Syntax
                    .AddModifiers(@modifier));
            }

            public virtual TInnerSelf WithModifiers(MODIFIER @modifier)
            {
                return Self(this.Syntax
                    .WithModifiers(@modifier));
            }

            # endregion Modifiers

            # region • Body •

            public virtual TInnerSelf WithBody(params String[] @statements)
            {
                return Self(this.Syntax
                    .WithBody(@statements));
            }

            # endregion Body

            # region • Statements •

            public virtual TInnerSelf AddStatements(params String[] @statements)
            {
                return Self(this.Syntax
                    .AddStatements(@statements));
            }

            public virtual TInnerSelf WithStatements(params String[] @statements)
            {
                return Self(this.Syntax
                    .WithStatements(@statements));
            }

            # endregion Statements

            # region • Factories •

            private static AccessorDeclarationSyntax Factory(Boolean @isAuto = true)
            {
                return SyntaxFactory.AccessorDeclaration(
                    SyntaxKind.SetAccessorDeclaration)
                    .IsAuto(@isAuto);
            }

            # endregion Factories

            # endregion Methods
        }

        # endregion Setter

        # endregion Inner Classes
    }
}

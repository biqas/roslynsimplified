using System;
using System.Collections.Generic;
using System.Linq;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class Property : Property<Property>
    {
        # region • Ctor's •

        public Property(System.Type @type, String @identifier,
            Boolean @withFullName = false)
            : base(@type, @identifier, @withFullName) {}

        public Property(String @typeName, String @identifier)
            : base(@typeName, @identifier) {}

        internal Property(PropertyDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        protected override Property New(PropertyDeclarationSyntax @syntaxNode)
        {
            return new Property(@syntaxNode);
        }

        # endregion Methods
    }

    public abstract class Property<TSelf> : BaseProperty<TSelf, PropertyDeclarationSyntax>
        where TSelf : Property<TSelf>
    {
        # region • Ctor's •

        protected Property(System.Type @type, String @identifier,
            Boolean @withFullName = false)
        {
            this.Init(Factory(@type, @identifier, @withFullName))
                .WithAutoAccessors();
        }

        protected Property(String @typeName, String @identifier)
        {
            this.Init(Factory(@typeName, @identifier))
                .WithAutoAccessors();
        }

        internal protected Property(PropertyDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) { }

        # endregion Ctor's

        # region • Methods •

        # region • Initializations •

        public virtual TSelf Init<T, TE>(Type<T, TE> @type, String @identifier)
            where T : Type<T, TE>
            where TE : TypeDeclarationSyntax
        {
            return this.Init(Factory(
                @type, @identifier));
        }

        public virtual TSelf Init<TType>(String @identifier,
            Boolean @withFullName = false)
        {
            return this.Init(Factory<TType>(
                @identifier, @withFullName));
        }

        public virtual TSelf Init(System.Type @type, String @identifier,
            Boolean @withFullName = false)
        {
            return this.Init(Factory(
                @type, @identifier, @withFullName));
        }
        
        public virtual TSelf Init(String @typeName, String @identifier)
        {
            return this.Init(
                Factory(@typeName, @identifier));
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

        # region • Identifier •

        public virtual TSelf WithIdentifier(String @identifier)
        {
            return Self(this.Syntax
                .WithIdentifier(@identifier));
        }

        # endregion Identifier

        # region • Accessors •

        public virtual TSelf WithAutoAccessors()
        {
            return Self(this.Syntax.WithAutoAccessors());
        }

        public virtual IEnumerable<IAccessor> GetAccessors()
        {
            return this.Syntax.GetAccessors()
                .Select(Accessor.Factory);
        }

        # endregion Accessors

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

        public virtual TSelf WithGetter(Property.Getter @getter)
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

        public virtual TSelf WithSetter(Property.Setter @getter)
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

        private static PropertyDeclarationSyntax Factory<TType>(String @identifier,
            Boolean @withFullName = false)
        {
            return SyntaxFactory.PropertyDeclaration(
                SyntaxFactory.ParseTypeName(typeof(Object).Name), @identifier)
                .WithType<TType>(@withFullName);
        }

        private static PropertyDeclarationSyntax Factory(System.Type @type,
            String @identifier, Boolean @withFullName = false)
        {
            return SyntaxFactory.PropertyDeclaration(
                SyntaxFactory.ParseTypeName(typeof(Object).Name), @identifier)
                .WithType(@type, @withFullName);
        }

        private static PropertyDeclarationSyntax Factory(String @typeName,
            String @identifier)
        {
            return SyntaxFactory.PropertyDeclaration(
                SyntaxFactory.ParseTypeName(@typeName), @identifier);
        }

        private static PropertyDeclarationSyntax Factory<T, TE>(
            Type<T, TE> @type, String @identifier)
            where T : Type<T, TE>
            where TE : TypeDeclarationSyntax
        {
            return SyntaxFactory.PropertyDeclaration(
                @type.Syntax.GetTypeSyntax(), @identifier);
        }

        # endregion Factories

        # endregion Methods

        # region • Inner Classes •

        //public sealed class Accessor : Accessor<Accessor>
        //{
        //    protected override Accessor New()
        //    {
        //        return new Accessor();
        //    }
        //}

        public static class Accessor
        {
            # region • Factories •

            public static IAccessor Factory(AccessorDeclarationSyntax @syntax)
            {
                switch (@syntax.Kind())
                {
                    case SyntaxKind.GetAccessorDeclaration:
                        return new Getter(@syntax);

                    case SyntaxKind.SetAccessorDeclaration:
                        return new Setter(@syntax);

                    default:
                        throw new ArgumentOutOfRangeException("syntax");
                }
            }

            # endregion Factories
        }

        public interface IAccessor
        {
            
        }

        public abstract class Accessor<TInnerSelf> : CSharpSyntaxNode<TInnerSelf, AccessorDeclarationSyntax>, IAccessor
            where TInnerSelf : Accessor<TInnerSelf>
        {
            # region • Ctor's •

            internal protected Accessor() {}

            internal protected Accessor(AccessorDeclarationSyntax @syntaxNode)
                : base(@syntaxNode) { }

            # endregion Ctor's

            # region • Methods •

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

            public virtual IEnumerable<Attributes> GetAttributes()
            {
                return this.Syntax.GetAttributes()
                    .Select(x => new Attributes(x));
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

            # endregion Methods
        }

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

        public abstract class Getter<TInnerSelf> : Accessor<TInnerSelf>
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

            # region • Factories •

            private static AccessorDeclarationSyntax Factory(Boolean @isAuto = true)
            {
                return SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
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

        public abstract class Setter<TInnerSelf> : Accessor<TInnerSelf>
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

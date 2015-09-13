using System;
using System.Collections.Generic;
using System.Linq;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class Field : Field<Field>
    {
        # region • Ctor's •

        public Field(String @identifier)
            : base(@identifier) {}

        internal Field(FieldDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        protected override Field New(FieldDeclarationSyntax @syntaxNode)
        {
            return new Field(@syntaxNode);
        }

        # endregion Methods
    }

    public abstract partial class Field<TSelf> : BaseField<TSelf, FieldDeclarationSyntax>
        where TSelf : Field<TSelf>
    {
        # region • Ctor's •

        protected Field(String @identifier)
        {
            this.Init(Factory(@identifier));
        }

        internal protected Field(FieldDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) { }

        # endregion Ctor's

        # region • Methods •

        # region • Initializations •

        public virtual TSelf Init(String @identifier)
        {
            return this.Init(Factory(@identifier));
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

        /// <summary>
        /// Add modifiers to class decleration syntax.
        /// </summary>
        /// <param name="modifier"></param>
        /// <returns></returns>
        public virtual TSelf AddModifiers(MODIFIER @modifier)
        {
            return Self(this.Syntax
                .AddModifiers(@modifier));
        }

        /// <summary>
        /// Sets the modifiers to class decleration.
        /// </summary>
        /// <param name="modifier"></param>
        /// <returns></returns>
        public virtual TSelf WithModifiers(MODIFIER @modifier)
        {
            return Self(this.Syntax
                .WithModifiers(@modifier));
        }

        # endregion Modifiers

        # region • Type •

        public virtual TSelf WithType(TypeSyntax @typeSyntax)
        {
            return WithType(@typeSyntax.ToString());
        }

        public virtual TSelf WithType<T, TE>(Type<T, TE> @class)
            where T : Type<T, TE>
            where TE : TypeDeclarationSyntax
        {
            return WithType(@class.Syntax.GetTypeSyntax());
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

        # region • Initializer •

        public virtual TSelf WithInitializer(String @expression)
        {
            return Self(this.Syntax
                .WithInitializer(@expression));
        }

        # endregion Initializer

        # region • Factories •

        private static FieldDeclarationSyntax Factory(String @identifier)
        {
            return SyntaxFactory.FieldDeclaration(
                SyntaxFactory.VariableDeclaration(
                    SyntaxFactory.ParseTypeName(typeof(Object).Name)))
                .WithIdentifier(@identifier);
        }

        # endregion Factories

        # endregion Methods
    }
}

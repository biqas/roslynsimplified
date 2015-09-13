using System;
using System.Collections.Generic;
using System.Linq;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class Enum : Enum<Enum>
    {
        # region • Ctor's •

        public Enum(String @identifier)
            : base(@identifier) {}

        internal Enum(EnumDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        protected override Enum New(EnumDeclarationSyntax @syntaxNode)
        {
            return new Enum(@syntaxNode);
        }

        # endregion Methods
    }

    public abstract class Enum<TSelf> : BaseType<TSelf, EnumDeclarationSyntax>
        where TSelf : Enum<TSelf>
    {
        # region • Ctor's •

        protected Enum(String @identifier)
        {
            this.Init(Factory(@identifier));
        }

        internal protected Enum(EnumDeclarationSyntax @syntaxNode)
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

        # region • Identifier •

        public virtual TSelf WithIdentifier(String @identifier)
        {
            return Self(this.Syntax
                .WithIdentifier(@identifier));
        }

        # endregion Identifier

        # region • BaseList •

        public virtual TSelf WithBaseClass(
            String @typeName)
        {
            return Self(this.Syntax
                .WithBaseClass(@typeName));
        }

        public virtual TSelf WithBaseClass(
            BaseTypeSyntax @classTypeSyntax)
        {
            return Self(this.Syntax
                .WithBaseClass(@classTypeSyntax));
        }

        # endregion BaseList

        # region • Members •

        # region • Constants •

        public virtual TSelf AddConstants(params String[] @identifiers)
        {
            return Self(this.Syntax
                .AddConstants(@identifiers));
        }

        public virtual TSelf AddConstants(params EnumMemberDeclarationSyntax[] @enumMemberSyntax)
        {
            return Self(this.Syntax
                .AddConstants(@enumMemberSyntax));
        }

        public virtual IEnumerable<EnumMemberDeclarationSyntax> GetConstants()
        {
            return this.Syntax.GetConstants();
        }

        # endregion Constants

        public virtual IEnumerable<EnumMemberDeclarationSyntax> GetMembers()
        {
            return this.Syntax.GetMembers();
        }

        # endregion Members

        # region • Helper •

        //public virtual String GetName()
        //{
        //    return this.Syntax.GetName();
        //}

        //public virtual String GetFullName()
        //{
        //    return this.Syntax.GetFullName();
        //}

        # endregion Helper

        # region • Factories •

        public static EnumDeclarationSyntax Factory(String @identifier)
        {
            return SyntaxFactory.EnumDeclaration(
                SyntaxFactory.Identifier(identifier));
        }

        # endregion Factories

        # endregion Methods
    }
}

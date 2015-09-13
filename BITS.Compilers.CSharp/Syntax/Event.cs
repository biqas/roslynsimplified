using System;
using System.Collections.Generic;
using System.Linq;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class Event : Event<Event>
    {
        # region • Ctor's •

        public Event(String @identifier)
            : base(@identifier) {}

        internal Event(EventDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        protected override Event New(EventDeclarationSyntax @syntaxNode)
        {
            return new Event(@syntaxNode);
        }

        # endregion Methods
    }

    public abstract partial class Event<TSelf> : BaseProperty<TSelf, EventDeclarationSyntax>
        where TSelf : Event<TSelf>
    {
        # region • Ctor's •

        protected Event(String @identifier)
        {
            this.Init(Factory(@identifier));
        }

        internal protected Event(EventDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) { }

        # endregion Ctor's

        # region • Methods •

        # region • Initializations •

        public virtual TSelf Init(String @identifier)
        {
            return this.Init(
                Factory(@identifier));
        }

        public virtual TSelf Init<TType>(String @identifier, Boolean @withFullName = true)
        {
            return this.Init(
                Factory<TType>(@identifier, @withFullName));
        }

        public virtual TSelf Init(System.Type @type, String @identifier, Boolean @withFullName = true)
        {
            return this.Init(
                Factory(@type, @identifier, @withFullName));
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

        # region • ReturnType •

        public virtual TSelf WithDelegate<TType>(Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .WithDelegate<TType>(@withFullName));
        }

        public virtual TSelf WithDelegate(System.Type @type, Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .WithDelegate(@type, @withFullName));
        }

        public virtual TSelf WithReturnType(String @typeName)
        {
            return Self(this.Syntax
                .WithDelegate(@typeName));
        }

        # endregion ReturnType

        # region • Identifier •

        public virtual TSelf WithIdentifier(String @identifier)
        {
            return Self(this.Syntax
                .WithIdentifier(@identifier));
        }

        # endregion Identifier

        # region • Factories •

        public static EventDeclarationSyntax Factory(String @identifier)
        {
            return SyntaxFactory.EventDeclaration(
                SyntaxFactory.ParseTypeName(typeof(Object).Name), @identifier);
        }

        public static EventDeclarationSyntax Factory<TType>(String @identifier, Boolean @withFullName = true)
        {
            return SyntaxFactory.EventDeclaration(
                SyntaxFactory.ParseTypeName(typeof(Object).Name), @identifier)
                .WithDelegate<TType>(@withFullName);
        }

        public static EventDeclarationSyntax Factory(System.Type @type, String @identifier, Boolean @withFullName = true)
        {
            return SyntaxFactory.EventDeclaration(
                SyntaxFactory.ParseTypeName(typeof(Object).Name), @identifier)
                .WithDelegate(@type, @withFullName);
        }

        public static EventDeclarationSyntax Factory(String @typeName, String @identifier)
        {
            return SyntaxFactory.EventDeclaration(
                SyntaxFactory.ParseTypeName(typeof(Object).Name), @identifier)
                .WithDelegate(@typeName);
        }

        # endregion Factories

        # endregion Methods
    }
}

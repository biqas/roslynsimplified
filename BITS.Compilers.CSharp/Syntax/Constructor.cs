using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class Constructor : Constructor<Constructor>
    {
        # region • Ctor's •

        public Constructor(String @identifier)
            : base(@identifier) {}

        internal Constructor(ConstructorDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        protected override Constructor New(ConstructorDeclarationSyntax @syntaxNode)
        {
            return new Constructor(@syntaxNode);
        }

        # endregion Methods
    }

    public abstract partial class Constructor<TSelf> : BaseMethod<TSelf, ConstructorDeclarationSyntax>
        where TSelf : Constructor<TSelf>
    {
        # region • Ctor's •

        protected Constructor(String @identifier)
        {
            this.Init(Factory(@identifier));
        }

        internal protected Constructor(ConstructorDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        # region • Initializations •

        public virtual TSelf Init(String @identifier)
        {
            return this.Init(
                Factory(@identifier));
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

        # region • Identifier •

        public virtual TSelf WithIdentifier(String @identifier)
        {
            return Self(this.Syntax
                .WithIdentifier(@identifier));
        }

        # endregion Identifier

        # region • Parameters •

        public virtual TSelf AddParameter<TType>(String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .AddParameter<TType>(@parameterName, @withFullName));
        }

        public virtual TSelf AddParameter(System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .AddParameter(@type, @parameterName, @withFullName));
        }

        public virtual TSelf AddParameter(String @typeName, String @parameterName)
        {
            return Self(this.Syntax
                .AddParameter(@typeName, @parameterName));
        }

        public virtual TSelf AddInParameter<TType>(String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .AddInParameter<TType>(@parameterName, @withFullName));
        }

        public virtual TSelf AddInParameter(System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .AddInParameter(@type, @parameterName, @withFullName));
        }

        public virtual TSelf AddInParameter(String @typeName, String @parameterName)
        {
            return Self(this.Syntax
                .AddInParameter(@typeName, @parameterName));
        }

        public virtual TSelf AddOutParameter<TType>(String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .AddOutParameter<TType>(@parameterName, @withFullName));
        }

        public virtual TSelf AddOutParameter(System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .AddOutParameter(@type, @parameterName, @withFullName));
        }

        public virtual TSelf AddOutParameter(String @typeName, String @parameterName)
        {
            return Self(this.Syntax
                .AddOutParameter(@typeName, @parameterName));
        }

        public virtual TSelf AddRefParameter<TType>(String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .AddRefParameter<TType>(@parameterName, @withFullName));
        }

        public virtual TSelf AddRefParameter(System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .AddRefParameter(@type, @parameterName, @withFullName));
        }

        public virtual TSelf AddRefParameter(String @typeName, String @parameterName)
        {
            return Self(this.Syntax
                .AddRefParameter(@typeName, @parameterName));
        }

        public virtual TSelf AddParamsParameter<TType>(String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .AddParamsParameter<TType>(@parameterName, @withFullName));
        }

        public virtual TSelf AddParamsParameter(System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .AddParamsParameter(@type, @parameterName, @withFullName));
        }

        public virtual TSelf AddParamsParameter(String @typeName, String @parameterName)
        {
            return Self(this.Syntax
                .AddParamsParameter(@typeName, @parameterName));
        }

        # endregion Parameters

        # region • Body •

        public virtual TSelf WithBody(params String[] @statements)
        {
            return Self(this.Syntax
                .WithBody(@statements));
        }

        # endregion Body

        # region • Statements •

        public virtual TSelf AddStatements(params String[] @statements)
        {
            return Self(this.Syntax
                .AddStatements(@statements));
        }

        public virtual TSelf AddStatements(params Expression<Action>[] @statements)
        {
            return Self(this.Syntax
                .AddStatements(@statements));
        }

        public virtual TSelf WithStatements(params String[] @statements)
        {
            return Self(this.Syntax
                .WithStatements(@statements));
        }

        # endregion Statements

        # region • Factories •

        public static ConstructorDeclarationSyntax Factory(String @identifier)
        {
            return SyntaxFactory.ConstructorDeclaration(
                @identifier);
        }

        # endregion Factories

        # endregion Methods
    }
}

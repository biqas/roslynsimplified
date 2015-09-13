using System;
using System.Collections.Generic;
using System.Linq;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class Delegate : Delegate<Delegate>
    {
        # region • Ctor's •

        public Delegate(String @identifier)
            : base(@identifier) {}

        public Delegate(System.Type @type, String @identifier, Boolean @withFullName = true)
            : base(@type, @identifier, @withFullName) {}

        public Delegate(String @typeName, String @identifier)
            : base(@typeName, @identifier) {}

        internal Delegate(DelegateDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        protected override Delegate New(DelegateDeclarationSyntax @syntaxNode)
        {
            return new Delegate(@syntaxNode);
        }

        # endregion Methods
    }

    public abstract partial class Delegate<TSelf> : Member<TSelf, DelegateDeclarationSyntax>
        where TSelf : Delegate<TSelf>
    {
        # region • Ctor's •

        protected Delegate(String @identifier)
        {
            this.Init(Factory(@identifier));
        }

        protected Delegate(System.Type @type, String @identifier, Boolean @withFullName = true)
        {
            this.Init(Factory(@type, @identifier, @withFullName));
        }

        protected Delegate(String @typeName, String @identifier)
        {
            this.Init(Factory(@typeName, @identifier));
        }

        internal protected Delegate(DelegateDeclarationSyntax @syntaxNode)
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

        public virtual TSelf WithReturnType<TType>(Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .WithReturnType<TType>(@withFullName));
        }

        public virtual TSelf WithReturnType(System.Type @type, Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .WithReturnType(@type, @withFullName));
        }

        public virtual TSelf WithReturnType(String @typeName)
        {
            return Self(this.Syntax
                .WithReturnType(@typeName));
        }

        # endregion ReturnType

        # region • Identifier •

        public virtual TSelf WithIdentifier(String @identifier)
        {
            return Self(this.Syntax
                .WithIdentifier(@identifier));
        }

        # endregion Identifier

        # region • Type Parameters •

        public virtual TSelf AddTypeParameter(String @typeParameterName, String @parameterName)
        {
            return Self(this.Syntax
                .AddTypeParameter(@typeParameterName, @parameterName));
        }

        public virtual TSelf AddTypeParameter(String @typeParameterName)
        {
            return Self(this.Syntax
                .AddTypeParameter(@typeParameterName));
        }

        public virtual TSelf WithTypeParameters(params String[] @typeParameterNames)
        {
            return Self(this.Syntax
                .WithTypeParameters(@typeParameterNames));
        }

        # endregion Type Parameters

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

        # region • ConstraintClauses •

        public virtual TSelf AddNewConstraint(String @typeParameter)
        {
            return Self(this.Syntax
                .AddNewConstraint(@typeParameter));
        }

        public virtual TSelf AddClassConstraint(String @typeParameter)
        {
            return Self(this.Syntax
                .AddClassConstraint(@typeParameter));
        }

        public virtual TSelf AddStructConstraint(String @typeParameter)
        {
            return Self(this.Syntax
                .AddStructConstraint(@typeParameter));
        }

        public virtual TSelf AddTypeConstraint(String @typeParameter,
            String @typeName)
        {
            return Self(this.Syntax
                .AddTypeConstraint(@typeParameter, @typeName));
        }

        public virtual TSelf AddTypeConstraint(String @typeParameter,
            TypeSyntax @typeSyntax)
        {
            return Self(this.Syntax
                .AddTypeConstraint(@typeParameter, @typeSyntax));
        }

        public virtual TSelf WithNewConstraints(String @typeParameter)
        {
            return Self(this.Syntax
                .WithNewConstraints(@typeParameter));
        }

        public virtual TSelf WithClassConstraint(String @typeParameter)
        {
            return Self(this.Syntax
                .WithClassConstraint(@typeParameter));
        }

        public virtual TSelf WithStructConstraint(String @typeParameter)
        {
            return Self(this.Syntax
                .WithStructConstraint(@typeParameter));
        }

        public virtual TSelf WithTypeConstraint(String @typeParameter,
            String @typeName)
        {
            return Self(this.Syntax
                .WithTypeConstraint(@typeParameter, @typeName));
        }

        public virtual TSelf WithTypeConstraint(String @typeParameter,
            TypeSyntax @typeSyntax)
        {
            return Self(this.Syntax
                .WithTypeConstraint(@typeParameter, @typeSyntax));
        }

        # endregion ConstraintClauses

        # region • Factories •

        public static DelegateDeclarationSyntax Factory(String @identifier)
        {
            return SyntaxFactory.DelegateDeclaration(
                SyntaxFactory.ParseTypeName(typeof(Object).Name),
                @identifier)
                .WithReturnVoid();
        }

        public static DelegateDeclarationSyntax Factory<TType>(String @identifier, Boolean @withFullName = true)
        {
            return SyntaxFactory.DelegateDeclaration(
                SyntaxFactory.ParseTypeName(typeof(Object).Name),
                @identifier)
                .WithReturnType<TType>(@withFullName);
        }

        public static DelegateDeclarationSyntax Factory(System.Type @type, String @identifier, Boolean @withFullName = true)
        {
            return SyntaxFactory.DelegateDeclaration(
                SyntaxFactory.ParseTypeName(typeof(Object).Name),
                @identifier)
                .WithReturnType(@type, @withFullName);
        }

        public static DelegateDeclarationSyntax Factory(String @typeName, String @identifier)
        {
            return SyntaxFactory.DelegateDeclaration(
                SyntaxFactory.ParseTypeName(typeof(Object).Name), @identifier)
                .WithReturnType(@typeName);
        }

        # endregion Factories

        # endregion Methods
    }
}

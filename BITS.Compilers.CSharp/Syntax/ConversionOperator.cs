using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class ConversionOperator : ConversionOperator<ConversionOperator>
    {
        # region • Ctor's •

        public ConversionOperator(CONVERSION @conversion,
            System.Type @type, Boolean @withFullName = true)
            : base(@conversion, @type, @withFullName) {}

        public ConversionOperator(CONVERSION @conversion, String @returnTypeName)
            : base(@conversion, @returnTypeName) {}

        public ConversionOperator(CONVERSION @conversion, TypeSyntax @typeSyntax)
            : base(@conversion, @typeSyntax) {}

        internal ConversionOperator(ConversionOperatorDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        protected override ConversionOperator New(ConversionOperatorDeclarationSyntax @syntaxNode)
        {
            return new ConversionOperator(@syntaxNode);
        }

        # endregion Methods
    }

    public abstract class ConversionOperator<TSelf> : BaseMethod<TSelf, ConversionOperatorDeclarationSyntax>
        where TSelf : ConversionOperator<TSelf>
    {
        # region • Ctor's •

        protected ConversionOperator(CONVERSION @conversion,
            System.Type @type, Boolean @withFullName = true)
        {
            this.Init(Factory(@conversion, @type, @withFullName));
        }

        protected ConversionOperator(CONVERSION @conversion,
            String @returnTypeName)
        {
            this.Init(Factory(@conversion, @returnTypeName));
        }

        protected ConversionOperator(CONVERSION @conversion,
            TypeSyntax @typeSyntax)
        {
            this.Init(Factory(@conversion, @typeSyntax));
        }

        internal protected ConversionOperator(ConversionOperatorDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) { }

        # endregion Ctor's

        # region • Methods •

        # region • Initializations •

        public virtual TSelf Init<TType>(CONVERSION @conversion,
            Boolean @withFullName = true)
        {
            return this.Init(
                Factory<TType>(@conversion, @withFullName));
        }

        public virtual TSelf Init(CONVERSION @conversion,
            System.Type @type, Boolean @withFullName = true)
        {
            return this.Init(
                Factory(@conversion, @type, @withFullName));
        }

        public virtual TSelf Init(CONVERSION @conversion,
            String @returnTypeName)
        {
            return this.Init(
                Factory(@conversion, @returnTypeName));
        }

        public virtual TSelf Init(CONVERSION @conversion,
            TypeSyntax @typeSyntax)
        {
            return this.Init(
                Factory(@conversion, @typeSyntax));
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

        public virtual TSelf WithType<TType>(Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .WithType<TType>(@withFullName));
        }

        public virtual TSelf WithType(System.Type @type, Boolean @withFullName = false)
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

        # region • Conversion •

        public virtual TSelf IsImplicit()
        {
            return Self(this.Syntax
                .IsImplicit());
        }

        public virtual TSelf IsExplicit()
        {
            return Self(this.Syntax
                .IsExplicit());
        }

        # endregion Conversion

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

        public static ConversionOperatorDeclarationSyntax Factory<TType>(
            CONVERSION @conversion, Boolean @withFullName = true)
        {
            return Factory(@conversion, typeof(TType), @withFullName);
        }

        public static ConversionOperatorDeclarationSyntax Factory(
            CONVERSION @conversion, System.Type @type, Boolean @withFullName = true)
        {
            var name = @withFullName
                ? type.GetFullName()
                : type.GetName();

            return Factory(@conversion, name);
        }

        public static ConversionOperatorDeclarationSyntax Factory(
            CONVERSION @conversion, String @typeName)
        {
            return Factory(@conversion, SyntaxFactory.ParseTypeName(@typeName));
        }

        public static ConversionOperatorDeclarationSyntax Factory(
            CONVERSION @conversion, TypeSyntax @typeSyntax)
        {
            return SyntaxFactory.ConversionOperatorDeclaration(
                @conversion.GetSyntaxToken(), @typeSyntax);
        }

        # endregion Factories

        # endregion Methods
    }
}

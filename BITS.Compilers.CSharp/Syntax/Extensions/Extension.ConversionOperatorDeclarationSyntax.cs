using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionConversionConversionOperatorDeclarationSyntax
    {
        # region • Modifiers •

        public static ConversionOperatorDeclarationSyntax AddModifiers(this ConversionOperatorDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.AddModifiers(
                @modifier.GetSyntaxTokens().ToArray());
        }

        public static ConversionOperatorDeclarationSyntax WithModifiers(this ConversionOperatorDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.WithModifiers(
                SyntaxFactory.TokenList(@modifier.GetSyntaxTokens()));
        }

        # endregion Modifiers

        # region • Type •

        public static ConversionOperatorDeclarationSyntax WithType<TType>(this ConversionOperatorDeclarationSyntax @this,
            Boolean @withFullName = false)
        {
            return @this.WithType(
                typeof(TType), @withFullName);
        }

        public static ConversionOperatorDeclarationSyntax WithType(this ConversionOperatorDeclarationSyntax @this,
            System.Type @type, Boolean @withFullName = false)
        {
            return @this.WithType(@withFullName
                ? @type.GetFullName()
                : @type.GetName());
        }

        public static ConversionOperatorDeclarationSyntax WithType(this ConversionOperatorDeclarationSyntax @this,
            String @typeName)
        {
            return @this.WithType(
                SyntaxFactory.ParseTypeName(@typeName));
        }

        # endregion Type

        # region • Conversion •

        public static ConversionOperatorDeclarationSyntax IsImplicit(this ConversionOperatorDeclarationSyntax @this)
        {
            return @this.WithImplicitOrExplicitKeyword(
                SyntaxFactory.Token(SyntaxKind.ImplicitKeyword));
        }

        public static ConversionOperatorDeclarationSyntax IsExplicit(this ConversionOperatorDeclarationSyntax @this)
        {
            return @this.WithImplicitOrExplicitKeyword(
                SyntaxFactory.Token(SyntaxKind.ExplicitKeyword));
        }

        # endregion Conversion

        # region • Parameters •

        public static ConversionOperatorDeclarationSyntax AddParameter<TType>(this ConversionOperatorDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                typeof(TType), @parameterName, @withFullName);
        }

        public static ConversionOperatorDeclarationSyntax AddParameter(this ConversionOperatorDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(@withFullName
                ? @type.GetFullName()
                : @type.GetName(), @parameterName);
        }

        public static ConversionOperatorDeclarationSyntax AddParameter(this ConversionOperatorDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameterListParameters(
                SyntaxFactory.Parameter(SyntaxFactory.Identifier(@parameterName))
                    .WithType(@typeName));
        }

        public static ConversionOperatorDeclarationSyntax AddInParameter<TType>(this ConversionOperatorDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.IN, @parameterName, @withFullName);
        }

        public static ConversionOperatorDeclarationSyntax AddInParameter(this ConversionOperatorDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.IN, @type, @parameterName, @withFullName);
        }

        public static ConversionOperatorDeclarationSyntax AddInParameter(this ConversionOperatorDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.IN, @typeName, @parameterName);
        }

        public static ConversionOperatorDeclarationSyntax AddOutParameter<TType>(this ConversionOperatorDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.OUT, @parameterName, @withFullName);
        }

        public static ConversionOperatorDeclarationSyntax AddOutParameter(this ConversionOperatorDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.OUT, @type, @parameterName, @withFullName);
        }

        public static ConversionOperatorDeclarationSyntax AddOutParameter(this ConversionOperatorDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.OUT, @typeName, @parameterName);
        }

        public static ConversionOperatorDeclarationSyntax AddRefParameter<TType>(this ConversionOperatorDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.REF, @parameterName, @withFullName);
        }

        public static ConversionOperatorDeclarationSyntax AddRefParameter(this ConversionOperatorDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.REF, @type, @parameterName, @withFullName);
        }

        public static ConversionOperatorDeclarationSyntax AddRefParameter(this ConversionOperatorDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.REF, @typeName, @parameterName);
        }

        public static ConversionOperatorDeclarationSyntax AddParamsParameter<TType>(this ConversionOperatorDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.PARAMS, @parameterName, @withFullName);
        }

        public static ConversionOperatorDeclarationSyntax AddParamsParameter(this ConversionOperatorDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.PARAMS, @type, @parameterName, @withFullName);
        }

        public static ConversionOperatorDeclarationSyntax AddParamsParameter(this ConversionOperatorDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.PARAMS, @typeName, @parameterName);
        }

        public static ConversionOperatorDeclarationSyntax AddParameter<TType>(this ConversionOperatorDeclarationSyntax @this,
            PARAMETER_TYPE @modifier, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(@modifier,
                typeof(TType), @parameterName, @withFullName);
        }

        public static ConversionOperatorDeclarationSyntax AddParameter(this ConversionOperatorDeclarationSyntax @this,
            PARAMETER_TYPE @modifier, System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                @modifier, @withFullName
                    ? @type.GetFullName()
                    : @type.GetName(), @parameterName);
        }

        public static ConversionOperatorDeclarationSyntax AddParameter(this ConversionOperatorDeclarationSyntax @this,
            PARAMETER_TYPE @modifier, String @typeName, String @parameterName)
        {
            if (@modifier == PARAMETER_TYPE.PARAMS)
            {
                if (@typeName.LastIndexOf("[]", StringComparison.Ordinal) <= 0 && @parameterName.LastIndexOf("[]", StringComparison.Ordinal) <= 0)
                    @typeName += "[]";
            }

            return @this.AddParameterListParameters(
                SyntaxFactory.Parameter(SyntaxFactory.Identifier(@parameterName))
                    .WithModifiers(@modifier)
                    .WithType(@typeName));
        }

        # endregion Parameters

        # region • Body •

        public static ConversionOperatorDeclarationSyntax WithBody(this ConversionOperatorDeclarationSyntax @this,
            params String[] @statements)
        {
            if (@statements == null || !@statements.Any())
                return @this;

            return @this
                .WithSemicolonToken(default(SyntaxToken))
                .WithBody(Block.Factory(@statements));
        }

        # endregion Body

        # region • Statements •

        public static ConversionOperatorDeclarationSyntax AddStatements(this ConversionOperatorDeclarationSyntax @this,
            params String[] @statements)
        {
            if (@this.Body == null)
                @this = @this.WithBody(SyntaxFactory.Block());

            return @this.WithBody(
                @this.Body.AddStatements(@statements))
                .WithSemicolonToken(default(SyntaxToken));
        }

        public static ConversionOperatorDeclarationSyntax AddStatements(this ConversionOperatorDeclarationSyntax @this,
            params Expression<Action>[] @statements)
        {
            if (@this.Body == null)
                @this = @this.WithBody(SyntaxFactory.Block());

            return @this.WithBody(
                @this.Body.AddStatements(@statements))
                .WithSemicolonToken(default(SyntaxToken));
        }

        public static ConversionOperatorDeclarationSyntax WithStatements(this ConversionOperatorDeclarationSyntax @this,
            params String[] @statements)
        {
            return @this.WithBody(
                SyntaxFactory.Block()
                    .WithStatements(@statements))
                .WithSemicolonToken(default(SyntaxToken));
        }

        # endregion Statements
    }
}

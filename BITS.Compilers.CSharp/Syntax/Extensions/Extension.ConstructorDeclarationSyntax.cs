using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionConstructorDeclarationSyntax
    {
        # region • Modifiers •

        public static ConstructorDeclarationSyntax AddModifiers(this ConstructorDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.AddModifiers(
                @modifier.GetSyntaxTokens().ToArray());
        }

        public static ConstructorDeclarationSyntax WithModifiers(this ConstructorDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.WithModifiers(
                SyntaxFactory.TokenList(@modifier.GetSyntaxTokens()));
        }

        # endregion Modifiers

        # region • Identifier •

        public static ConstructorDeclarationSyntax WithIdentifier(this ConstructorDeclarationSyntax @this,
            String @identifier)
        {
            return @this.WithIdentifier(
                SyntaxFactory.Identifier(@identifier));
        }

        # endregion Identifier

        # region • Parameters •

        public static ConstructorDeclarationSyntax AddParameter<TType>(this ConstructorDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                typeof(TType), @parameterName, @withFullName);
        }

        public static ConstructorDeclarationSyntax AddParameter(this ConstructorDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(@withFullName
                ? @type.GetFullName()
                : @type.GetName(), @parameterName);
        }

        public static ConstructorDeclarationSyntax AddParameter(this ConstructorDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameterListParameters(
                SyntaxFactory.Parameter(SyntaxFactory.Identifier(@parameterName))
                    .WithType(@typeName));
        }

        public static ConstructorDeclarationSyntax AddInParameter<TType>(this ConstructorDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.IN, @parameterName, @withFullName);
        }

        public static ConstructorDeclarationSyntax AddInParameter(this ConstructorDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.IN, @type, @parameterName, @withFullName);
        }

        public static ConstructorDeclarationSyntax AddInParameter(this ConstructorDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.IN, @typeName, @parameterName);
        }

        public static ConstructorDeclarationSyntax AddOutParameter<TType>(this ConstructorDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.OUT, @parameterName, @withFullName);
        }

        public static ConstructorDeclarationSyntax AddOutParameter(this ConstructorDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.OUT, @type, @parameterName, @withFullName);
        }

        public static ConstructorDeclarationSyntax AddOutParameter(this ConstructorDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.OUT, @typeName, @parameterName);
        }

        public static ConstructorDeclarationSyntax AddRefParameter<TType>(this ConstructorDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.REF, @parameterName, @withFullName);
        }

        public static ConstructorDeclarationSyntax AddRefParameter(this ConstructorDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.REF, @type, @parameterName, @withFullName);
        }

        public static ConstructorDeclarationSyntax AddRefParameter(this ConstructorDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.REF, @typeName, @parameterName);
        }

        public static ConstructorDeclarationSyntax AddParamsParameter<TType>(this ConstructorDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.PARAMS, @parameterName, @withFullName);
        }

        public static ConstructorDeclarationSyntax AddParamsParameter(this ConstructorDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.PARAMS, @type, @parameterName, @withFullName);
        }

        public static ConstructorDeclarationSyntax AddParamsParameter(this ConstructorDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.PARAMS, @typeName, @parameterName);
        }

        public static ConstructorDeclarationSyntax AddParameter<TType>(this ConstructorDeclarationSyntax @this,
            PARAMETER_TYPE @modifier, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(@modifier,
                typeof(TType), @parameterName, @withFullName);
        }

        public static ConstructorDeclarationSyntax AddParameter(this ConstructorDeclarationSyntax @this,
            PARAMETER_TYPE @modifier, System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                @modifier, @withFullName
                    ? @type.GetFullName()
                    : @type.GetName(), @parameterName);
        }

        public static ConstructorDeclarationSyntax AddParameter(this ConstructorDeclarationSyntax @this,
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

        public static ConstructorDeclarationSyntax WithBody(this ConstructorDeclarationSyntax @this,
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

        public static ConstructorDeclarationSyntax AddStatements(this ConstructorDeclarationSyntax @this,
            params String[] @statements)
        {
            if (@this.Body == null)
                @this = @this.WithBody(SyntaxFactory.Block());

            return @this.WithBody(
                @this.Body.AddStatements(@statements))
                .WithSemicolonToken(default(SyntaxToken));
        }

        public static ConstructorDeclarationSyntax AddStatements(this ConstructorDeclarationSyntax @this,
            params Expression<Action>[] @statements)
        {
            if (@this.Body == null)
                @this = @this.WithBody(SyntaxFactory.Block());

            return @this.WithBody(
                @this.Body.AddStatements(@statements))
                .WithSemicolonToken(default(SyntaxToken));
        }

        public static ConstructorDeclarationSyntax WithStatements(this ConstructorDeclarationSyntax @this,
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

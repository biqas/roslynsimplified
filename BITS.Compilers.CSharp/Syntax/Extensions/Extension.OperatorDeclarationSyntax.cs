using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionOperatorDeclarationSyntax
    {
        # region • Modifiers •

        public static OperatorDeclarationSyntax AddModifiers(this OperatorDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.AddModifiers(
                @modifier.GetSyntaxTokens().ToArray());
        }

        public static OperatorDeclarationSyntax WithModifiers(this OperatorDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.WithModifiers(
                SyntaxFactory.TokenList(@modifier.GetSyntaxTokens()));
        }

        # endregion Modifiers

        # region • ReturnType •

        public static OperatorDeclarationSyntax WithReturnType<TType>(this OperatorDeclarationSyntax @this,
            Boolean @withFullName = false)
        {
            return @this.WithReturnType(
                typeof(TType), @withFullName);
        }

        public static OperatorDeclarationSyntax WithReturnType(this OperatorDeclarationSyntax @this,
            System.Type @type, Boolean @withFullName = false)
        {
            return @this.WithReturnType(@withFullName
                ? @type.GetFullName()
                : @type.GetName());
        }

        public static OperatorDeclarationSyntax WithReturnType(this OperatorDeclarationSyntax @this,
            String @typeName)
        {
            return @this.WithReturnType(
                SyntaxFactory.ParseTypeName(@typeName));
        }

        # endregion ReturnType

        # region • Operations •

        public static OperatorDeclarationSyntax WithOperation(this OperatorDeclarationSyntax @this,
            OPERATION @operation)
        {
            return @this.WithOperatorToken(
                @operation.GetSyntaxToken());
        }

        # endregion Operations

        # region • Parameters •

        public static OperatorDeclarationSyntax AddParameter<TType>(this OperatorDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                typeof(TType), @parameterName, @withFullName);
        }

        public static OperatorDeclarationSyntax AddParameter(this OperatorDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(@withFullName
                ? @type.GetFullName()
                : @type.GetName(), @parameterName);
        }

        public static OperatorDeclarationSyntax AddParameter(this OperatorDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameterListParameters(
                SyntaxFactory.Parameter(SyntaxFactory.Identifier(@parameterName))
                    .WithType(@typeName));
        }

        public static OperatorDeclarationSyntax AddInParameter<TType>(this OperatorDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.IN, @parameterName, @withFullName);
        }

        public static OperatorDeclarationSyntax AddInParameter(this OperatorDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.IN, @type, @parameterName, @withFullName);
        }

        public static OperatorDeclarationSyntax AddInParameter(this OperatorDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.IN, @typeName, @parameterName);
        }

        public static OperatorDeclarationSyntax AddOutParameter<TType>(this OperatorDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.OUT, @parameterName, @withFullName);
        }

        public static OperatorDeclarationSyntax AddOutParameter(this OperatorDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.OUT, @type, @parameterName, @withFullName);
        }

        public static OperatorDeclarationSyntax AddOutParameter(this OperatorDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.OUT, @typeName, @parameterName);
        }

        public static OperatorDeclarationSyntax AddRefParameter<TType>(this OperatorDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.REF, @parameterName, @withFullName);
        }

        public static OperatorDeclarationSyntax AddRefParameter(this OperatorDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.REF, @type, @parameterName, @withFullName);
        }

        public static OperatorDeclarationSyntax AddRefParameter(this OperatorDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.REF, @typeName, @parameterName);
        }

        public static OperatorDeclarationSyntax AddParamsParameter<TType>(this OperatorDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.PARAMS, @parameterName, @withFullName);
        }

        public static OperatorDeclarationSyntax AddParamsParameter(this OperatorDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.PARAMS, @type, @parameterName, @withFullName);
        }

        public static OperatorDeclarationSyntax AddParamsParameter(this OperatorDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.PARAMS, @typeName, @parameterName);
        }

        public static OperatorDeclarationSyntax AddParameter<TType>(this OperatorDeclarationSyntax @this,
            PARAMETER_TYPE @modifier, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(@modifier,
                typeof(TType), @parameterName, @withFullName);
        }

        public static OperatorDeclarationSyntax AddParameter(this OperatorDeclarationSyntax @this,
            PARAMETER_TYPE @modifier, System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                @modifier, @withFullName
                    ? @type.GetFullName()
                    : @type.GetName(), @parameterName);
        }

        public static OperatorDeclarationSyntax AddParameter(this OperatorDeclarationSyntax @this,
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

        public static OperatorDeclarationSyntax WithBody(this OperatorDeclarationSyntax @this,
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

        public static OperatorDeclarationSyntax AddStatements(this OperatorDeclarationSyntax @this,
            params String[] @statements)
        {
            if (@this.Body == null)
                @this = @this.WithBody(SyntaxFactory.Block());

            return @this.WithBody(
                @this.Body.AddStatements(@statements))
                .WithSemicolonToken(default(SyntaxToken));
        }

        public static OperatorDeclarationSyntax AddStatements(this OperatorDeclarationSyntax @this,
            params Expression<Action>[] @statements)
        {
            if (@this.Body == null)
                @this = @this.WithBody(SyntaxFactory.Block());

            return @this.WithBody(
                @this.Body.AddStatements(@statements))
                .WithSemicolonToken(default(SyntaxToken));
        }

        public static OperatorDeclarationSyntax WithStatements(this OperatorDeclarationSyntax @this,
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

using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionParameterSyntax
    {
        # region • Modifiers •

        public static ParameterSyntax AddModifiers(this ParameterSyntax @this,
            PARAMETER_TYPE @parameterType)
        {
            return @this.AddModifiers(
                ((MODIFIER)@parameterType).GetSyntaxTokens().ToArray());
        }

        public static ParameterSyntax WithModifiers(this ParameterSyntax @this,
            PARAMETER_TYPE @parameterType)
        {
            return @this.WithModifiers(
                SyntaxFactory.TokenList(((MODIFIER)@parameterType).GetSyntaxTokens()));
        }

        public static ParameterSyntax AsIn(this ParameterSyntax @this)
        {
            return @this.WithModifiers(PARAMETER_TYPE.IN);
        }

        public static ParameterSyntax AsOut(this ParameterSyntax @this)
        {
            return @this.WithModifiers(PARAMETER_TYPE.OUT);
        }

        public static ParameterSyntax AsRef(this ParameterSyntax @this)
        {
            return @this.WithModifiers(PARAMETER_TYPE.REF);
        }

        public static ParameterSyntax AsParams(this ParameterSyntax @this)
        {
            return @this.WithModifiers(PARAMETER_TYPE.PARAMS);
        }

        # endregion Modifiers

        # region • Type •

        public static ParameterSyntax WithType<TType>(this ParameterSyntax @this,
            Boolean @withfullName = true)
        {
            return @this.WithType(typeof(TType), @withfullName);
        }

        public static ParameterSyntax WithType(this ParameterSyntax @this,
            System.Type @type, Boolean @withFullName = true)
        {
            return @this.WithType(@withFullName ? @type.GetFullName() : @type.GetName());
        }

        public static ParameterSyntax WithType(this ParameterSyntax @this,
            String @typeName)
        {
            return @this.WithType(SyntaxFactory.ParseTypeName(@typeName))
                .NormalizeTypeName();
        }

        # endregion Type

        # region • Identifier •

        public static ParameterSyntax WithIdentifier(this ParameterSyntax @this,
            String @identifier)
        {
            return @this.WithIdentifier(
                SyntaxFactory.Identifier(@identifier));
        }

        # endregion Identifier

        # region • Default Value •

        public static ParameterSyntax WithDefault(this ParameterSyntax @this,
            String @expression)
        {
            return @this.WithDefault(
                SyntaxFactory.EqualsValueClause(
                    SyntaxFactory.ParseExpression(@expression)));
        }

        public static ParameterSyntax WithDefaultType<TType>(this ParameterSyntax @this,
            Boolean @withfullName = true)
        {
            return @this.WithDefaultType(typeof(TType), @withfullName);
        }

        public static ParameterSyntax WithDefaultType(this ParameterSyntax @this,
            System.Type @type, Boolean @withFullName = true)
        {
            return @this.WithDefaultType(@withFullName
                ? @type.GetFullName()
                : @type.GetName());
        }

        public static ParameterSyntax WithDefaultType(this ParameterSyntax @this,
            String @typeName)
        {
            return @this.WithDefault(
                String.Format("default({0})", @typeName));
        }

        # endregion Default Value
    }
}

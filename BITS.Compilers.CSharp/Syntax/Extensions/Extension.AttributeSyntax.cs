using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    /// <summary>
    /// Extension methods for attribute nodes.
    /// </summary>
    public static class ExtensionAttributeSyntax
    {
        public static AttributeSyntax WithName(this AttributeSyntax @this, String @name)
        {
            return @this.WithName(
                SyntaxFactory.ParseName(@name));
        }

        public static AttributeSyntax AddArgument(this AttributeSyntax @this,
            String @expression)
        {
            return @this.AddArgumentListArguments(
                SyntaxFactory.AttributeArgument(
                    SyntaxFactory.GetStandaloneExpression(
                        SyntaxFactory.ParseExpression(@expression))));
        }

        public static AttributeSyntax AddArgument(this AttributeSyntax @this,
            String @name, String @expression)
        {
            return @this.AddArgumentListArguments(
                SyntaxFactory.AttributeArgument(
                    SyntaxFactory.GetStandaloneExpression(
                        SyntaxFactory.ParseExpression(@expression)))
                    .WithName(@name));
        }

        public static AttributeSyntax AddArguments(this AttributeSyntax @this,
            params AttributeArgumentSyntax[] @attributeArguments)
        {
            return @this.AddArgumentListArguments(@attributeArguments);
        }

        public static AttributeSyntax WithArgument(this AttributeSyntax @this,
            String @expression)
        {
            return @this.WithArguments(
                SyntaxFactory.AttributeArgument(
                    SyntaxFactory.GetStandaloneExpression(
                        SyntaxFactory.ParseExpression(@expression))));
        }

        public static AttributeSyntax WithArgument(this AttributeSyntax @this,
            String @name, String @expression)
        {
            return @this.WithArguments(
                SyntaxFactory.AttributeArgument(
                    SyntaxFactory.GetStandaloneExpression(
                        SyntaxFactory.ParseExpression(@expression)))
                    .WithName(@name));
        }

        public static AttributeSyntax WithArguments(this AttributeSyntax @this,
            params AttributeArgumentSyntax[] @attributeArguments)
        {
            return @this.WithArgumentList(
                SyntaxFactory.AttributeArgumentList(
                    SyntaxFactory.SeparatedList(@attributeArguments,
                        Enumerable.Repeat(
                            SyntaxFactory.Token(SyntaxKind.CommaToken),
                            @attributeArguments.Count() - 1))));
        }

        # region • Factories •

        public static AttributeSyntax Factory(
            String @name)
        {
            return SyntaxFactory.Attribute(
                SyntaxFactory.ParseName(@name));
        }

        public static AttributeSyntax Factory(
            String @name, String @expression)
        {
            return SyntaxFactory.Attribute(
                    SyntaxFactory.ParseName(@name))
                .WithArgument(@expression);
        }

        # endregion Factories
    }
}
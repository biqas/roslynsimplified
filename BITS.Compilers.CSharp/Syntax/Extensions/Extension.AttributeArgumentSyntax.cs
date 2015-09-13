using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static class ExtensionAttributeArgumentSyntax
    {
        public static AttributeArgumentSyntax WithName(this AttributeArgumentSyntax @this, String @name)
        {
            return @this.WithNameEquals(
                SyntaxFactory.NameEquals(@name));
        }

        public static AttributeArgumentSyntax WithExpression(this AttributeArgumentSyntax @this, String @expression)
        {
            return @this.WithExpression(
                SyntaxFactory.GetStandaloneExpression(
                    SyntaxFactory.ParseExpression(@expression)));
        }
    }
}

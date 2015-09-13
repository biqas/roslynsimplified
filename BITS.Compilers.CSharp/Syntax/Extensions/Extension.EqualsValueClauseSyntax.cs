using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionEqualsValueClauseSyntax
    {
        # region • Value •

        public static EqualsValueClauseSyntax WithValue(this EqualsValueClauseSyntax @this,
            String @expression)
        {
            return @this.WithValue(
                SyntaxFactory.ParseExpression(@expression));
        }

        # endregion Value
    }
}
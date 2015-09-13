using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionTypeParameterSyntax
    {
        # region • Variance •

        public static TypeParameterSyntax WithVariance(this TypeParameterSyntax @this,
            VARIANCE @variance)
        {
            return @this.WithVariance(
                @variance.GetSyntaxToken());
        }

        public static TypeParameterSyntax WithVariance(this TypeParameterSyntax @this,
            SyntaxToken @syntaxToken)
        {
            return @this.WithVarianceKeyword(
                @syntaxToken);
        }

        # endregion Variance

        # region • Identifier •

        public static TypeParameterSyntax WithIdentifier(this TypeParameterSyntax @this,
            String @identifier)
        {
            return @this.WithIdentifier(
                SyntaxFactory.Identifier(@identifier));
        }

        # endregion Identifier
    }
}

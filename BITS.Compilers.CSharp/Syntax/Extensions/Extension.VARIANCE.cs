using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static class ExtensionVariance
    {
        public static SyntaxToken GetSyntaxToken(this VARIANCE @this)
        {
            try
            {
                return SyntaxFactory.Token((SyntaxKind)Convert
                    .ChangeType(@this, typeof(SyntaxKind)));
            }
            catch
            {
                return SyntaxFactory.Token(SyntaxKind.None);
            }
        }

        public static VARIANCE GetVariance(this SyntaxToken @this)
        {
            var variance = VARIANCE.NONE;

            try
            {
                variance = (VARIANCE)Convert.ChangeType(
                    @this, typeof(VARIANCE));
            }
            catch
            {
                return variance;
            }

            return variance;
        }
    }
}

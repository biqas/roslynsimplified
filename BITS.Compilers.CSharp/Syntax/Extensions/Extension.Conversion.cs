using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static class ExtensionConversion
    {
        public static SyntaxToken GetSyntaxToken(this CONVERSION @this)
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

        public static CONVERSION GetVariance(this SyntaxToken @this)
        {
            var conversion = CONVERSION.NONE;

            try
            {
                conversion = (CONVERSION)Convert.ChangeType(
                    @this, typeof(CONVERSION));
            }
            catch
            {
                return conversion;
            }

            return conversion;
        }
    }
}

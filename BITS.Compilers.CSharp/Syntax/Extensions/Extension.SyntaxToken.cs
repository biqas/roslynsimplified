using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionSyntaxToken
    {
        public static VARIANCE GetVariance(this SyntaxToken @this)
        {
            if (@this.Kind() == SyntaxKind.InKeyword)
                return VARIANCE.IN;

            if (@this.Kind() == SyntaxKind.OutKeyword)
                return VARIANCE.OUT;

            return VARIANCE.NONE;
        }
    }
}

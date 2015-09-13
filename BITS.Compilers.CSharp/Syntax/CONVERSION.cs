using Microsoft.CodeAnalysis.CSharp;

namespace BITS.Compilers.CSharp.Syntax
{
    public enum CONVERSION : ushort
    {
        NONE,
 
        IMPLICIT = SyntaxKind.ImplicitKeyword,

        EXPLICIT = SyntaxKind.ExplicitKeyword,
    }
}

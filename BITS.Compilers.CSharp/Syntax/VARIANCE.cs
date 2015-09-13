using Microsoft.CodeAnalysis.CSharp;

namespace BITS.Compilers.CSharp.Syntax
{
    public enum VARIANCE
    {
        NONE = 0,

        IN   = SyntaxKind.InKeyword,

        OUT  = SyntaxKind.OutKeyword,
    }
}
using Microsoft.CodeAnalysis.CSharp;

namespace BITS.Compilers.CSharp.Syntax
{
    public enum CONSTRUCTOR_CALL : ushort
    {
        BASE = SyntaxKind.BaseKeyword,

        THIS = SyntaxKind.ThisKeyword,
    }
}

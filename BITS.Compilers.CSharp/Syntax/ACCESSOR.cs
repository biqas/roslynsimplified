using Microsoft.CodeAnalysis.CSharp;

namespace BITS.Compilers.CSharp.Syntax
{
    public enum ACCESSOR : ushort
    {
        GET = SyntaxKind.GetAccessorDeclaration,

        SET = SyntaxKind.SetAccessorDeclaration,
    }
}

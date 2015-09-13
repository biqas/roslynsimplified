using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static class ExtensionOperation
    {
        public static SyntaxToken GetSyntaxToken(this OPERATION @this)
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

        public static OPERATION GetOperation(this SyntaxToken @this)
        {
            var operation = OPERATION.NONE;

            try
            {
                operation = (OPERATION) Convert.ChangeType(
                    @this, typeof (OPERATION));
            }
            catch
            {
                return operation;
            }

            return operation;
        }
    }
}

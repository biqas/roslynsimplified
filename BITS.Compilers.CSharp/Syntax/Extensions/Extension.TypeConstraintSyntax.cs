using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionTypeConstraintSyntax
    {
        # region • Type •

        public static TypeConstraintSyntax WithType(this TypeConstraintSyntax @this,
            String @typeName)
        {
            return @this.WithType(
                SyntaxFactory.ParseTypeName(@typeName));
        }

        # endregion Type
    }
}

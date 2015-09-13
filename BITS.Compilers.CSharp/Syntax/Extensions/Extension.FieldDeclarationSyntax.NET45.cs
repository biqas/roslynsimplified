using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    /// <summary>
    /// Extension methods for field nodes.
    /// </summary>
    public static partial class ExtensionFieldDeclarationSyntax
    {
        # region • Attributes •

        public static FieldDeclarationSyntax AddAttribute(this FieldDeclarationSyntax @this,
            String @name)
        {
            return @this.WithAttributeLists(SyntaxFactory.List<AttributeListSyntax>()
                .Add(SyntaxFactory.AttributeList()
                    .AddAttribute(@name)));
        }

        public static FieldDeclarationSyntax AddAttribute(this FieldDeclarationSyntax @this,
            String @name, String @expression)
        {
            return @this.WithAttributeLists(SyntaxFactory.List<AttributeListSyntax>()
                .Add(SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @expression)));
        }

        public static FieldDeclarationSyntax AddAttribute(this FieldDeclarationSyntax @this,
            String @name, String @argumentName, String @expression)
        {
            return @this.WithAttributeLists(SyntaxFactory.List<AttributeListSyntax>()
                .Add(SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @argumentName, @expression)));
        }

        public static IEnumerable<AttributeListSyntax> GetAttributes(
            this FieldDeclarationSyntax @this)
        {
            return @this.AttributeLists;
        }

        # endregion Attributes
    }
}

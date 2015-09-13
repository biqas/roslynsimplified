using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionIndexerDeclarationSyntax
    {
        # region • Attributes •

        public static IndexerDeclarationSyntax AddAttribute(this IndexerDeclarationSyntax @this,
           String @name)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name));
        }

        public static IndexerDeclarationSyntax AddAttribute(this IndexerDeclarationSyntax @this,
            String @name, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @expression));
        }

        public static IndexerDeclarationSyntax AddAttribute(this IndexerDeclarationSyntax @this,
            String @name, String @argumentName, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @argumentName, @expression));
        }

        public static IEnumerable<AttributeListSyntax> GetAttributes(
            this IndexerDeclarationSyntax @this)
        {
            return @this.AttributeLists;
        }

        # endregion Attributes
    }
}

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionEnumDeclarationSyntax
    {
        # region • Attributes •

        public static EnumDeclarationSyntax AddAttribute(this EnumDeclarationSyntax @this,
           String @name)
        {
            return @this.AddAttributeLists(
                Microsoft.CodeAnalysis.CSharp.SyntaxFactory.AttributeList()
                    .AddAttribute(@name));
        }

        public static EnumDeclarationSyntax AddAttribute(this EnumDeclarationSyntax @this,
            String @name, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @expression));
        }

        public static EnumDeclarationSyntax AddAttribute(this EnumDeclarationSyntax @this,
            String @name, String @argumentName, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @argumentName, @expression));
        }

        public static IEnumerable<AttributeListSyntax> GetAttributes(
            this EnumDeclarationSyntax @this)
        {
            return @this.AttributeLists;
        }

        # endregion Attributes

        # region • BaseList •

        private static EnumDeclarationSyntax AddBaseClass(this EnumDeclarationSyntax @this,
            String @classTypeName)
        {
            return @this.AddBaseListTypes(
                SyntaxFactory.SimpleBaseType(
                    SyntaxFactory.ParseTypeName(
                        SyntaxFactory.Identifier(@classTypeName).ToFullString())));
        }

        # endregion BaseList
    }
}

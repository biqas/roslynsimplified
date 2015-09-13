using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionEnumMemberDeclarationSyntax
    {
        # region • Attributes •

        public static EnumMemberDeclarationSyntax AddAttribute(this EnumMemberDeclarationSyntax @this,
           String @name)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name));
        }

        public static EnumMemberDeclarationSyntax AddAttribute(this EnumMemberDeclarationSyntax @this,
            String @name, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @expression));
        }

        public static EnumMemberDeclarationSyntax AddAttribute(this EnumMemberDeclarationSyntax @this,
            String @name, String @argumentName, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @argumentName, @expression));
        }

        public static IEnumerable<AttributeListSyntax> GetAttributes(
            this EnumMemberDeclarationSyntax @this)
        {
            return @this.AttributeLists;
        }

        # endregion Attributes
    }
}

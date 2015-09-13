using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionEnumMemberDeclarationSyntax
    {
        # region • Identifier •

        public static EnumMemberDeclarationSyntax WithIdentifier(this EnumMemberDeclarationSyntax @this,
            String @identifier)
        {
            return @this.WithIdentifier(
                SyntaxFactory.Identifier(@identifier));
        }

        # endregion Identifier

        # region • Value •

        public static EnumMemberDeclarationSyntax WithValue(this EnumMemberDeclarationSyntax @this,
            String @value)
        {
            var expression = SyntaxFactory.ParseExpression(
                String.Format("{0} = {1}",
                @this.Identifier, @value));

            return @this.WithEqualsValue(
                SyntaxFactory.EqualsValueClause(expression));
        }

        # endregion Initializer
    }
}

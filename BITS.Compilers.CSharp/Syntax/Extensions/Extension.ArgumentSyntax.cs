using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static class ExtensionArgumentSyntax
    {
        # region • Identifier •

        public static ArgumentSyntax WithIdentifier(this ArgumentSyntax @this,
            String @identifier)
        {
            return @this.WithNameColon(
                SyntaxFactory.NameColon(@identifier));
        }

        # endregion Identifier

        # region • Ref / Out •

        public static ArgumentSyntax IsRef(this ArgumentSyntax @this)
        {
            return @this.WithRefOrOutKeyword(
                SyntaxFactory.Token(SyntaxKind.RefKeyword));
        }

        public static ArgumentSyntax IsOut(this ArgumentSyntax @this)
        {
            return @this.WithRefOrOutKeyword(
                SyntaxFactory.Token(SyntaxKind.OutKeyword));
        }

        # endregion Ref / Out

        # region • Expression •

        public static ArgumentSyntax WithExpression(this ArgumentSyntax @this,
            String @expression)
        {
            return @this.WithExpression(
                SyntaxFactory.ParseExpression(@expression));
        }

        # endregion Expression
        
        # region • Factories •

        public static ArgumentSyntax Factory(
            String @expression)
        {
            return SyntaxFactory.Argument(
                SyntaxFactory.ParseExpression(@expression));
        }

        public static ArgumentSyntax Factory(
            String @identifier, String @expression)
        {
            return SyntaxFactory.Argument(
                    SyntaxFactory.ParseExpression(@expression))
                .WithIdentifier(@identifier);
        }

        # endregion Factories
    }
}

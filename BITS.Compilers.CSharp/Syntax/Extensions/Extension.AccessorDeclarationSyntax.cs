using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static class ExtensionAccessorDeclarationSyntax
    {
        # region • Attributes •

        public static AccessorDeclarationSyntax AddAttribute(this AccessorDeclarationSyntax @this,
           String @name)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name));
        }

        public static AccessorDeclarationSyntax AddAttribute(this AccessorDeclarationSyntax @this,
            String @name, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @expression));
        }

        public static AccessorDeclarationSyntax AddAttribute(this AccessorDeclarationSyntax @this,
            String @name, String @argumentName, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @argumentName, @expression));
        }

        public static IEnumerable<AttributeListSyntax> GetAttributes(
            this AccessorDeclarationSyntax @this)
        {
            return @this.AttributeLists;
        }

        # endregion Attributes

        # region • Modifiers •

        public static AccessorDeclarationSyntax AddModifiers(this AccessorDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.AddModifiers(
                @modifier.GetSyntaxTokens().ToArray());
        }

        public static AccessorDeclarationSyntax WithModifiers(this AccessorDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.WithModifiers(
                SyntaxFactory.TokenList(@modifier.GetSyntaxTokens()));
        }

        # endregion Modifiers

        # region • Body •

        public static AccessorDeclarationSyntax IsAuto(this AccessorDeclarationSyntax @this,
            Boolean @isAuto = true)
        {
            if (isAuto)
            {
                return @this
                    .WithBody(null)
                    .WithSemicolonToken(
                        SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            }

            return @this
                .WithSemicolonToken(default(SyntaxToken));
        }

        public static AccessorDeclarationSyntax WithBody(this AccessorDeclarationSyntax @this,
            params String[] @statements)
        {
            if (@statements == null || !@statements.Any())
                return @this;

            return @this
                .WithSemicolonToken(default(SyntaxToken))
                .WithBody(Block.Factory(@statements));
        }

        # endregion Body

        # region • Statements •

        public static AccessorDeclarationSyntax AddStatements(this AccessorDeclarationSyntax @this,
            params String[] @statements)
        {
            if (@this.Body == null)
                @this = @this.WithBody(SyntaxFactory.Block());

            return @this.WithBody(
                @this.Body.AddStatements(@statements))
                .WithSemicolonToken(default(SyntaxToken));
        }

        public static AccessorDeclarationSyntax AddStatements(this AccessorDeclarationSyntax @this,
            params Expression<Action>[] @statements)
        {
            if (@this.Body == null)
                @this = @this.WithBody(SyntaxFactory.Block());

            return @this.WithBody(
                @this.Body.AddStatements(@statements))
                .WithSemicolonToken(default(SyntaxToken));
        }

        public static AccessorDeclarationSyntax WithStatements(this AccessorDeclarationSyntax @this,
            params String[] @statements)
        {
            return @this.WithBody(
                SyntaxFactory.Block()
                    .WithStatements(@statements))
                .WithSemicolonToken(default(SyntaxToken));
        }

        # endregion Statements

        # region • Factories •

        public static AccessorDeclarationSyntax Factory(ACCESSOR @accessor)
        {
            return SyntaxFactory.AccessorDeclaration(
                (SyntaxKind)@accessor);
        }

        # endregion Factories
    }
}

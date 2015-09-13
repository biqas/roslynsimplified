using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    /// <summary>
    /// Extension methods for field nodes.
    /// </summary>
    public static partial class ExtensionFieldDeclarationSyntax
    {
        # region • Modifiers •

        public static FieldDeclarationSyntax AddModifiers(this FieldDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.AddModifiers(
                @modifier.GetSyntaxTokens().ToArray());
        }

        public static FieldDeclarationSyntax WithModifiers(this FieldDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.WithModifiers(
                SyntaxFactory.TokenList(@modifier.GetSyntaxTokens()));
        }

        # endregion Modifiers

        # region • Type •

        public static FieldDeclarationSyntax WithType<TType>(this FieldDeclarationSyntax @this,
            Boolean @withFullName = false)
        {
            return @this.WithType(typeof(TType),
                @withFullName);
        }

        public static FieldDeclarationSyntax WithType(this FieldDeclarationSyntax @this,
            System.Type @type, Boolean @withFullName = false)
        {
            return @this.WithType(@withFullName
                ? @type.GetFullName()
                : @type.GetName());
        }

        public static FieldDeclarationSyntax WithType(this FieldDeclarationSyntax @this, String @typeName)
        {
            return @this.WithDeclaration(
                @this.Declaration.WithType(
                    SyntaxFactory.ParseTypeName(@typeName)));
        }

        # endregion Type

        # region • Identifier •

        public static FieldDeclarationSyntax WithIdentifier(this FieldDeclarationSyntax @this, String @identifier,
            String @expression = null)
        {
            var variableDeclaratorSyntax = SyntaxFactory.VariableDeclarator(@identifier);

            if (!String.IsNullOrEmpty(@expression))
            {
                var equalsValueClause = SyntaxFactory.EqualsValueClause(
                    SyntaxFactory.ParseExpression(@expression));

                variableDeclaratorSyntax = variableDeclaratorSyntax
                    .WithInitializer(equalsValueClause);
            }

            return @this.WithDeclaration(
                @this.Declaration.WithVariables(
                    SyntaxFactory.SeparatedList<VariableDeclaratorSyntax>()
                        .Add(variableDeclaratorSyntax)));
        }

        # endregion Identifier

        # region • Initializer •

        public static FieldDeclarationSyntax WithInitializer(this FieldDeclarationSyntax @this, String @expression)
        {
            var variableDeclaratorSyntax = @this.Declaration.Variables.FirstOrDefault();

            if (variableDeclaratorSyntax == default(VariableDeclaratorSyntax))
            {
                throw new Exception("A intitializer can only be defined if an identifier exists.");
            }

            if (!String.IsNullOrEmpty(@expression))
            {
                var equalsValueClause = SyntaxFactory.EqualsValueClause(
                    SyntaxFactory.ParseExpression(@expression));

                variableDeclaratorSyntax = variableDeclaratorSyntax
                    .WithInitializer(equalsValueClause);
            }

            return @this.WithDeclaration(
                @this.Declaration.WithVariables(
                    SyntaxFactory.SeparatedList<VariableDeclaratorSyntax>()
                        .Add(variableDeclaratorSyntax)));
        }

        # endregion Initializer
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionEnumDeclarationSyntax
    {
        # region • Modifiers •

        public static EnumDeclarationSyntax AddModifiers(this EnumDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.AddModifiers(
                @modifier.GetSyntaxTokens().ToArray());
        }

        public static EnumDeclarationSyntax WithModifiers(this EnumDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.WithModifiers(
                SyntaxFactory.TokenList(@modifier.GetSyntaxTokens()));
        }

        # endregion Modifiers

        # region • Identifier •

        public static EnumDeclarationSyntax WithIdentifier(this EnumDeclarationSyntax @this,
            String @identifier)
        {
            return @this.WithIdentifier(
                SyntaxFactory.Identifier(identifier));
        }

        # endregion Identifier

        # region • BaseList •

        public static EnumDeclarationSyntax WithBaseClass(this EnumDeclarationSyntax @this,
            String @typeName)
        {
            return @this.WithBaseList(
                SyntaxFactory.BaseList())
                .AddBaseClass(@typeName);
        }

        public static EnumDeclarationSyntax WithBaseClass(this EnumDeclarationSyntax @this,
            BaseTypeSyntax @classTypeSyntax)
        {
            return @this.WithBaseList(
                SyntaxFactory.BaseList())
                .AddBaseListTypes(@classTypeSyntax);
        }

        # endregion BaseList

        # region • Members •

        # region • Constants •

        public static EnumDeclarationSyntax AddConstants(this EnumDeclarationSyntax @this,
            params String[] @identifiers)
        {
            return @this.AddConstants(
                @identifiers.Select(
                    SyntaxFactory.EnumMemberDeclaration)
                .ToArray());
        }

        public static EnumDeclarationSyntax AddConstants(this EnumDeclarationSyntax @this,
            params EnumMemberDeclarationSyntax[] @enumMemberSyntax)
        {
            return @this.AddMembers(@enumMemberSyntax);
        }

        public static IEnumerable<EnumMemberDeclarationSyntax> GetConstants(
            this EnumDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.EnumMemberDeclaration);
        }

        # endregion Constants

        public static IEnumerable<EnumMemberDeclarationSyntax> GetMembers(
            this EnumDeclarationSyntax @this)
        {
            return @this.Members;
        }

        # endregion Members

        # region • Helpers •

        public static Boolean IsPartial(this EnumDeclarationSyntax @this)
        {
            return @this.Modifiers.Contains(
                SyntaxFactory.Token(
                    SyntaxKind.PartialKeyword));
        }

        public static Boolean HasBaseClass(this EnumDeclarationSyntax @this)
        {
            return @this.BaseList != null && @this.BaseList.Types.Any();
        }

        public static String GetName(this EnumDeclarationSyntax @this)
        {
            return @this.Identifier.ValueText;
        }

        public static String GetFullName(this EnumDeclarationSyntax @this)
        {
            if (@this.Parent == null)
                return @this.GetName();

            var member = @this.Parent as BaseTypeDeclarationSyntax;

            if (member == null)
            {
                throw new Exception(
                    $"Parent type:'{@this.Parent.GetType().Name}' " +
                    $"of this type:'{@this.GetType().Name}' " +
                    $"'{@this.GetName()}' is not a member.");
            }

            return $"{member.GetName()}.{@this.GetName()}";
        }

        # endregion Helpers
    }
}

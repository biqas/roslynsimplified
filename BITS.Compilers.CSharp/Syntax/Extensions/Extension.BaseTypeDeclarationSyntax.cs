using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static class ExtensionBaseTypeDeclarationSyntax
    {
        public static TypeSyntax GetTypeSyntax(this BaseTypeDeclarationSyntax @this)
        {
            return SyntaxFactory.ParseTypeName(@this.ToFullString());
        }

        # region • Helper •

        public static String GetName(this BaseTypeDeclarationSyntax @this)
        {
            return @this.Identifier.ToString();
        }

        public static String GetFullName(this BaseTypeDeclarationSyntax @this)
        {
            if (@this.Parent == null)
                return @this.GetName();

            var member = @this.Parent as BaseTypeDeclarationSyntax;

            if (member == null)
            {
                var @namesapce = @this.Parent as NamespaceDeclarationSyntax;

                if (@namesapce != null)
                {
                    return $"{@namesapce.GetName()}.{@this.GetName()}";
                }

                throw new Exception(
                    $"Parent type:'{@this.Parent.GetType().Name}'" +
                    $" of this type:'{@this.GetType().Name}' " +
                    $"'{@this.GetName()}' is not a member.");
            }

            return $"{member.GetName()}.{@this.GetName()}";
        }

        # endregion Helper
    }
}
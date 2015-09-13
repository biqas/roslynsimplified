using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    /// <summary>
    /// Extension methods for field nodes.
    /// </summary>
    public static class ExtensionUsingDirectiveSyntax
    {
        # region • Alias •

        public static UsingDirectiveSyntax WithAlias(this UsingDirectiveSyntax @this,
            String @expression)
        {
            return @this.WithAlias(
                SyntaxFactory.NameEquals(@expression));
        }
        public static UsingDirectiveSyntax WithAlias(this UsingDirectiveSyntax @this,
            String @alias, String @namespace)
        {
            return @this.WithAlias(
                SyntaxFactory.NameEquals(String.Format(
                    "{0} = {1}", @alias, @namespace)));
        }

        # endregion Alias

        # region • Name •

        public static UsingDirectiveSyntax WithName(this UsingDirectiveSyntax @this,
            String @namespace)
        {
            return @this.WithName(
                SyntaxFactory.IdentifierName(@namespace));
        }

        # endregion Name

        # region • Helper •

        public static String GetName(this UsingDirectiveSyntax @this)
        {
            return @this.Name.ToFullString();
        }

        # endregion Helper
    }
}

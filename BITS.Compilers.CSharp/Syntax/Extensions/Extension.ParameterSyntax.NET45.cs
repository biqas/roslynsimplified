using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionParameterSyntax
    {
        # region • Attributes •

        public static ParameterSyntax AddAttribute(this ParameterSyntax @this,
           String @name)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name));
        }

        public static ParameterSyntax AddAttribute(this ParameterSyntax @this,
            String @name, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @expression));
        }

        public static ParameterSyntax AddAttribute(this ParameterSyntax @this,
            String @name, String @argumentName, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @argumentName, @expression));
        }

        public static IEnumerable<AttributeListSyntax> GetAttributes(
            this ParameterSyntax @this)
        {
            return @this.AttributeLists;
        }

        # endregion Attributes

        # region • Helpers •

        private static ParameterSyntax NormalizeTypeName(this ParameterSyntax @this)
        {
            if (!@this.Modifiers.Any())
                return @this;

            if (@this.Type.ToFullString().LastIndexOf("[]", StringComparison.Ordinal) > 0)
                return @this;

            if (String.IsNullOrWhiteSpace(@this.Identifier.ToFullString()))
                return @this.WithType(@this.Type.ToFullString() + "[]");

            if (@this.Identifier.ToFullString().LastIndexOf("[]", StringComparison.Ordinal) > 0)
                return @this;

            return @this.WithType(@this.Type.ToFullString() + "[]");
        }

        # endregion Helpers
    }
}

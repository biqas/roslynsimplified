using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionEventDeclarationSyntax
    {
        # region • Modifiers •

        public static EventDeclarationSyntax AddModifiers(this EventDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.AddModifiers(
                @modifier.GetSyntaxTokens().ToArray());
        }

        public static EventDeclarationSyntax WithModifiers(this EventDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.WithModifiers(
                SyntaxFactory.TokenList(@modifier.GetSyntaxTokens()));
        }

        # endregion Modifiers

        # region • ReturnType •

        public static EventDeclarationSyntax WithDelegate<TType>(this EventDeclarationSyntax @this,
            Boolean @withFullName = false)
        {
            return @this.WithDelegate(
                typeof(TType), @withFullName);
        }

        public static EventDeclarationSyntax WithDelegate(this EventDeclarationSyntax @this,
            System.Type @type, Boolean @withFullName = false)
        {
            return @this.WithDelegate(@withFullName
                ? @type.GetFullName()
                : @type.GetName());
        }

        public static EventDeclarationSyntax WithDelegate(this EventDeclarationSyntax @this,
            String @typeName)
        {
            return @this.WithType(
                SyntaxFactory.ParseTypeName(@typeName));
        }

        # endregion ReturnType

        # region • Identifier •

        public static EventDeclarationSyntax WithIdentifier(this EventDeclarationSyntax @this,
            String @identifier)
        {
            return @this.WithIdentifier(
                SyntaxFactory.Identifier(@identifier));
        }

        # endregion Identifier
    }
}

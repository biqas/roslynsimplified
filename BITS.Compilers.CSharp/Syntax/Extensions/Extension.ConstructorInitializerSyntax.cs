using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionConstructorInitializerSyntax
    {
        # region • This / Base •

        public static ConstructorInitializerSyntax IsThis(
            this ConstructorInitializerSyntax @this)
        {
            return @this.WithThisOrBaseKeyword(
                SyntaxFactory.Token(SyntaxKind.ThisKeyword));
        }

        public static ConstructorInitializerSyntax IsBase(
            this ConstructorInitializerSyntax @this)
        {
            return @this.WithThisOrBaseKeyword(
                SyntaxFactory.Token(SyntaxKind.BaseKeyword));
        }

        # endregion This / Base

        # region • Arguments •

        public static ConstructorInitializerSyntax AddArguments(
            this ConstructorInitializerSyntax @this, params String[] @expressions)
        {
            return @this.AddArguments(@expressions
                .Select(ExtensionArgumentSyntax.Factory)
                .ToArray());
        }

        public static ConstructorInitializerSyntax AddArguments(
            this ConstructorInitializerSyntax @this, params ArgumentSyntax[] arguments)
        {
            return @this.AddArgumentListArguments(arguments);
        }

        public static ConstructorInitializerSyntax WithArguments(
            this ConstructorInitializerSyntax @this, params String[] @expressions)
        {
            return @this.WithArguments(@expressions
                .Select(ExtensionArgumentSyntax.Factory)
                .ToArray());
        }

        public static ConstructorInitializerSyntax WithArguments(
            this ConstructorInitializerSyntax @this, params ArgumentSyntax[] arguments)
        {
            return @this.WithArgumentList(
                SyntaxFactory.ArgumentList(
                    SyntaxFactory.SeparatedList(
                        @arguments,
                        Enumerable.Repeat(
                            SyntaxFactory.Token(
                                SyntaxKind.CommaToken),
                                @arguments.Count() - 1))));
        }

        # endregion Arguments

        # region • Factories •

        public static ConstructorInitializerSyntax Factory(CONSTRUCTOR_CALL @constructorCall,
            params ArgumentSyntax[] @arguments)
        {
            return SyntaxFactory.ConstructorInitializer(
                    (SyntaxKind)@constructorCall)
                .WithArguments(@arguments);
        }

        public static ConstructorInitializerSyntax Factory(CONSTRUCTOR_CALL @constructorCall,
            params String[] @arguments)
        {
            return SyntaxFactory.ConstructorInitializer(
                    (SyntaxKind)@constructorCall)
                .WithArguments(@arguments);
        }

        # endregion Factories
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static class ExtensionCompilationUnitSyntax
    {
        # region • Attributes •

        public static CompilationUnitSyntax AddAttribute(this CompilationUnitSyntax @this,
           String @name)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name));
        }

        public static CompilationUnitSyntax AddAttribute(this CompilationUnitSyntax @this,
            String @name, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @expression));
        }

        public static CompilationUnitSyntax AddAttribute(this CompilationUnitSyntax @this,
            String @name, String @argumentName, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @argumentName, @expression));
        }

        public static IEnumerable<AttributeListSyntax> GetAttributes(
            this CompilationUnitSyntax @this)
        {
            return @this.AttributeLists;
        }

        # endregion Attributes

        # region • Externs •

        public static CompilationUnitSyntax WithExterns(this CompilationUnitSyntax @this,
            params ExternAliasDirectiveSyntax[] @usings)
        {
            return @this.WithExterns(
                SyntaxFactory.List(@usings));
        }

        public static CompilationUnitSyntax WithExterns(this CompilationUnitSyntax @this,
            params String[] @externs)
        {
            return @this.WithExterns(
                @externs.Select(
                    SyntaxFactory.ExternAliasDirective)
                .ToArray());
        }

        # endregion Externs

        # region • Usings •

        public static CompilationUnitSyntax AddUsings(this CompilationUnitSyntax @this,
            params UsingDirectiveSyntax[] @usingsSyntax)
        {
            return @this.AddUsings(@usingsSyntax);
        }

        public static CompilationUnitSyntax WithUsings(this CompilationUnitSyntax @this,
            params UsingDirectiveSyntax[] @usings)
        {
            return @this.WithUsings(
                SyntaxFactory.List(@usings));
        }

        public static CompilationUnitSyntax WithUsings(this CompilationUnitSyntax @this,
            params String[] @namespaces)
        {
            return @this.WithUsings(
                @namespaces.Select(x =>
                    SyntaxFactory.UsingDirective(
                        SyntaxFactory.IdentifierName(x)))
                .ToArray());
        }

        public static IEnumerable<UsingDirectiveSyntax> GetUsings(
            this CompilationUnitSyntax @this)
        {
            return @this.Usings;
        }

        # endregion Usings

        # region • Members •

        public static IEnumerable<MemberDeclarationSyntax> GetMembers(
            this CompilationUnitSyntax @this)
        {
            return @this.Members;
        }

        # region • Namespaces •

        public static CompilationUnitSyntax AddNamespaces(this CompilationUnitSyntax @this,
            params NamespaceDeclarationSyntax[] @namespacesSyntax)
        {
            return @this.AddMembers(@namespacesSyntax);
        }

        public static CompilationUnitSyntax WithNamespaces(this CompilationUnitSyntax @this,
            params NamespaceDeclarationSyntax[] @namespacesSyntax)
        {
            return @this.WithMembers(
                SyntaxFactory.List<MemberDeclarationSyntax>(@namespacesSyntax));
        }

        public static IEnumerable<NamespaceDeclarationSyntax> GetNamespaces(
            this CompilationUnitSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.ClassDeclaration)
                .Cast<NamespaceDeclarationSyntax>();
        }

        # endregion Namespaces

        # endregion Members

        # region • Helper •


        # endregion Helper
    }
}
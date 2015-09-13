using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static class ExtensionNamespaceDirectiveSyntax
    {
        # region • Name •

        public static String GetFullName(this NamespaceDeclarationSyntax @this)
        {
            if (@this.Parent == null)
                return @this.GetName();

            var @namesapce = @this.Parent as NamespaceDeclarationSyntax;

            if (@namesapce == null)
            {
                throw new Exception(
                    $"Parent type:'{@this.Parent.GetType().Name}' " +
                    $"of this type:'{@this.GetType().Name}' " +
                    $"'{@this.GetName()}' is not a namespace.");
            }

            return $"{@namesapce.GetName()}.{@this.GetName()}";
        }

        public static String GetName(this NamespaceDeclarationSyntax @this)
        {
            return @this.Name.ToString();
        }

        public static NamespaceDeclarationSyntax WithName(this NamespaceDeclarationSyntax @this,
            String @name)
        {
            return @this.WithName(
                SyntaxFactory.IdentifierName(@name));
        }

        # endregion Name

        # region • Usings •

        public static NamespaceDeclarationSyntax WithUsings(this NamespaceDeclarationSyntax @this,
            params UsingDirectiveSyntax[] @usings)
        {
            return @this.WithUsings(
                SyntaxFactory.List(@usings));
        }

        public static NamespaceDeclarationSyntax WithUsings(this NamespaceDeclarationSyntax @this,
            params String[] @namespaces)
        {
            return @this.WithUsings(
                @namespaces.Select(x =>
                    SyntaxFactory.UsingDirective(
                        SyntaxFactory.IdentifierName(x)))
                .ToArray());
        }

        # endregion Usings

        # region • Members •

        public static NamespaceDeclarationSyntax WithMembers(this NamespaceDeclarationSyntax @this,
            params MemberDeclarationSyntax[] @members)
        {
            return @this.WithMembers(
                SyntaxFactory.List(@members));
        }

        public static IEnumerable<MemberDeclarationSyntax> GetMembers(
            this NamespaceDeclarationSyntax @this)
        {
            return @this.Members;
        }

        # region • Namespaces •

        public static NamespaceDeclarationSyntax AddNamespaces(this NamespaceDeclarationSyntax @this,
            params NamespaceDeclarationSyntax[] @namespaceSyntax)
        {
            return @this.AddMembers(@namespaceSyntax);
        }

        public static NamespaceDeclarationSyntax WithNamespaces(this NamespaceDeclarationSyntax @this,
            params NamespaceDeclarationSyntax[] @namespacesSyntax)
        {
            return @this.WithMembers(
                SyntaxFactory.List<MemberDeclarationSyntax>(@namespacesSyntax));
        }

        public static IEnumerable<NamespaceDeclarationSyntax> GetNamespaces(
            this NamespaceDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.ClassDeclaration)
                .Cast<NamespaceDeclarationSyntax>();
        }

        # endregion Namespaces

        # region • Usings •

        public static NamespaceDeclarationSyntax AddUsings(this NamespaceDeclarationSyntax @this,
            params UsingDirectiveSyntax[] @usingsSyntax)
        {
            return @this.AddUsings(@usingsSyntax);
        }

        public static IEnumerable<UsingDirectiveSyntax> GetUsings(
            this NamespaceDeclarationSyntax @this)
        {
            return @this.Usings;
        }

        # endregion Usings

        # region • Delegates •

        public static NamespaceDeclarationSyntax AddDelegates(this NamespaceDeclarationSyntax @this,
            params DelegateDeclarationSyntax[] @delegatesSyntax)
        {
            return @this.AddMembers(@delegatesSyntax);
        }

        public static IEnumerable<DelegateDeclarationSyntax> GetDelegates(
            this NamespaceDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.DelegateDeclaration)
                .Cast<DelegateDeclarationSyntax>();
        }

        # endregion Delegates

        # region • Interfaces •

        public static NamespaceDeclarationSyntax AddInterfaces(this NamespaceDeclarationSyntax @this,
            params InterfaceDeclarationSyntax[] @interfacesSyntax)
        {
            return @this.AddMembers(@interfacesSyntax);
        }

        public static IEnumerable<InterfaceDeclarationSyntax> GetInterfaces(
            this NamespaceDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.InterfaceDeclaration)
                .Cast<InterfaceDeclarationSyntax>();
        }

        # endregion Interfaces

        # region • Classes •

        public static NamespaceDeclarationSyntax AddClasses(this NamespaceDeclarationSyntax @this,
            params ClassDeclarationSyntax[] @classesSyntax)
        {
            return @this.AddMembers(@classesSyntax);
        }

        public static IEnumerable<ClassDeclarationSyntax> GetClasses(
            this NamespaceDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.ClassDeclaration)
                .Cast<ClassDeclarationSyntax>();
        }

        # endregion Classes

        # region • Structs •

        public static NamespaceDeclarationSyntax AddStructs(this NamespaceDeclarationSyntax @this,
            params StructDeclarationSyntax[] @structsSyntax)
        {
            return @this.AddMembers(@structsSyntax);
        }

        public static IEnumerable<StructDeclarationSyntax> GetStructs(
            this NamespaceDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.StructDeclaration)
                .Cast<StructDeclarationSyntax>();
        }

        # endregion Structs

        # region • Enums •

        public static NamespaceDeclarationSyntax AddEnums(this NamespaceDeclarationSyntax @this,
            params EnumDeclarationSyntax[] @enumsSyntax)
        {
            return @this.AddMembers(@enumsSyntax);
        }

        public static IEnumerable<EnumDeclarationSyntax> GetEnums(
            this NamespaceDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.EnumDeclaration)
                .Cast<EnumDeclarationSyntax>();
        }

        # endregion Enums

        # endregion Members

        # region • Helper •

        # endregion Helper
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionInterfaceDeclarationSyntax
    {
        # region • Modifiers •

        public static InterfaceDeclarationSyntax AddModifiers(this InterfaceDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.AddModifiers(
                @modifier.GetSyntaxTokens().ToArray());
        }

        public static InterfaceDeclarationSyntax WithModifiers(this InterfaceDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.WithModifiers(
                SyntaxFactory.TokenList(@modifier.GetSyntaxTokens()));
        }

        # endregion Modifiers

        # region • Identifier •

        public static InterfaceDeclarationSyntax WithIdentifier(this InterfaceDeclarationSyntax @this,
            String @identifier)
        {
            return @this.WithIdentifier(
                SyntaxFactory.Identifier(identifier));
        }

        # endregion Identifier

        # region • TypeParameters •

        public static InterfaceDeclarationSyntax AddTypeParameter<TType>(this InterfaceDeclarationSyntax @this,
            Boolean @withFullName = false)
        {
            var type = typeof(TType);

            return @this.AddTypeParameter(
                @withFullName
                    ? type.GetFullName()
                    : type.GetName());
        }

        public static InterfaceDeclarationSyntax AddTypeParameter(this InterfaceDeclarationSyntax @this,
            String @typeIdentifier)
        {
            return @this.AddTypeParameterListParameters(
                SyntaxFactory.TypeParameter(
                    SyntaxFactory.Identifier(@typeIdentifier)));
        }

        public static InterfaceDeclarationSyntax AddTypeParameter(this InterfaceDeclarationSyntax @this, 
            BaseTypeDeclarationSyntax @baseType)
        {
            return @this.AddTypeParameterListParameters(
                SyntaxFactory.TypeParameter(
                    @baseType.Identifier));
        }

        # endregion TypeParameters

        # region • ConstraintClauses •

        public static InterfaceDeclarationSyntax AddNewConstraint(this InterfaceDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.ConstructorConstraint());
        }

        public static InterfaceDeclarationSyntax AddClassConstraint(this InterfaceDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.ClassKeyword));
        }

        public static InterfaceDeclarationSyntax AddStructConstraint(this InterfaceDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.StructKeyword));
        }

        public static InterfaceDeclarationSyntax AddTypeConstraint(this InterfaceDeclarationSyntax @this,
            String @typeParameter, String @typeName)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(SyntaxFactory.ParseTypeName(@typeName)));
        }

        public static InterfaceDeclarationSyntax AddTypeConstraint(this InterfaceDeclarationSyntax @this,
            String @typeParameter, TypeSyntax @typeSyntax)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(@typeSyntax));
        }

        public static InterfaceDeclarationSyntax WithNewConstraints(this InterfaceDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.ConstructorConstraint());
        }

        public static InterfaceDeclarationSyntax WithClassConstraint(this InterfaceDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.ClassKeyword));
        }

        public static InterfaceDeclarationSyntax WithStructConstraint(this InterfaceDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.StructKeyword));
        }

        public static InterfaceDeclarationSyntax WithTypeConstraint(this InterfaceDeclarationSyntax @this,
            String @typeParameter, String @typeName)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(SyntaxFactory.ParseTypeName(@typeName)));
        }

        public static InterfaceDeclarationSyntax WithTypeConstraint(this InterfaceDeclarationSyntax @this,
            String @typeParameter, TypeSyntax @typeSyntax)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(@typeSyntax));
        }

        # endregion ConstraintClauses

        # region • BaseList •

        private static InterfaceDeclarationSyntax AddInterface(this InterfaceDeclarationSyntax @this,
            BaseTypeSyntax @interfaceTypeSyntax)
        {
            return @this.AddBaseListTypes(@interfaceTypeSyntax);
        }

        public static InterfaceDeclarationSyntax WithInterface(this InterfaceDeclarationSyntax @this,
            String @interfaceTypeName)
        {
            return @this.WithBaseList(
                SyntaxFactory.BaseList())
                .AddInterface(@interfaceTypeName);
        }

        public static InterfaceDeclarationSyntax WithInterface(this InterfaceDeclarationSyntax @this,
            BaseTypeSyntax @interfaceTypeSyntax)
        {
            return @this.WithBaseList(
                SyntaxFactory.BaseList())
                .AddInterface(@interfaceTypeSyntax);
        }

        # endregion BaseList

        # region • Member Methods •

        public static InterfaceDeclarationSyntax AddEvents(this InterfaceDeclarationSyntax @this,
            params EventDeclarationSyntax[] @eventsSyntax)
        {
            return @this.AddMembers(@eventsSyntax);
        }

        public static InterfaceDeclarationSyntax AddIndexers(this InterfaceDeclarationSyntax @this,
            params IndexerDeclarationSyntax[] @indexersSyntax)
        {
            return @this.AddMembers(@indexersSyntax);
        }

        public static InterfaceDeclarationSyntax AddProperties(this InterfaceDeclarationSyntax @this,
            params PropertyDeclarationSyntax[] @propertiesSyntax)
        {
            return @this.AddMembers(@propertiesSyntax);
        }

        public static InterfaceDeclarationSyntax AddMethods(this InterfaceDeclarationSyntax @this,
            params MethodDeclarationSyntax[] @methodsSyntax)
        {
            return @this.AddMembers(@methodsSyntax);
        }

        # endregion Member Methods

        # region • Members •

        # region • Events •

        public static IEnumerable<EventDeclarationSyntax> GetEvents(
            this InterfaceDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.EventDeclaration)
                .Cast<EventDeclarationSyntax>();
        }

        # endregion Events

        # region • Indexers •

        public static IEnumerable<IndexerDeclarationSyntax> GetIndexers(
            this InterfaceDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.IndexerDeclaration)
                .Cast<IndexerDeclarationSyntax>();
        }

        # endregion Indexers

        # region • Properties •

        public static IEnumerable<PropertyDeclarationSyntax> GetProperties(
            this InterfaceDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.PropertyDeclaration)
                .Cast<PropertyDeclarationSyntax>();
        }

        # endregion Properties

        # region • Methods •

        public static IEnumerable<MethodDeclarationSyntax> GetMethods(
            this InterfaceDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.MethodDeclaration)
                .Cast<MethodDeclarationSyntax>();
        }

        # endregion Methods

        public static IEnumerable<MemberDeclarationSyntax> GetMembers(
            this InterfaceDeclarationSyntax @this)
        {
            return @this.Members;
        }

        # endregion Members

        # region • Helpers •

        public static Boolean IsPartial(this InterfaceDeclarationSyntax @this)
        {
            return @this.Modifiers.Contains(
                SyntaxFactory.Token(
                    SyntaxKind.PartialKeyword));
        }

        public static Boolean HasBase(this InterfaceDeclarationSyntax @this)
        {
            return @this.BaseList != null && @this.BaseList.Types.Any();
        }

        # endregion Helpers
    }
}

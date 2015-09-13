using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionStructDeclarationSyntax
    {
        # region • Modifiers •

        public static StructDeclarationSyntax AddModifiers(this StructDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.AddModifiers(
                @modifier.GetSyntaxTokens().ToArray());
        }

        public static StructDeclarationSyntax WithModifiers(this StructDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.WithModifiers(
                SyntaxFactory.TokenList(@modifier.GetSyntaxTokens()));
        }

        # endregion Modifiers

        # region • Identifier •

        public static StructDeclarationSyntax WithIdentifier(this StructDeclarationSyntax @this,
            String @identifier)
        {
            return @this.WithIdentifier(
                SyntaxFactory.Identifier(identifier));
        }

        # endregion Identifier

        # region • TypeParameters •

        public static StructDeclarationSyntax AddTypeParameter<TType>(this StructDeclarationSyntax @this,
            Boolean @withFullName = false)
        {
            var type = typeof(TType);

            return @this.AddTypeParameter(
                @withFullName
                    ? type.GetFullName()
                    : type.GetName());
        }

        public static StructDeclarationSyntax AddTypeParameter(this StructDeclarationSyntax @this,
            String @typeIdentifier)
        {
            return @this.AddTypeParameterListParameters(
                SyntaxFactory.TypeParameter(
                    SyntaxFactory.Identifier(@typeIdentifier)));
        }

        public static StructDeclarationSyntax AddTypeParameter(this StructDeclarationSyntax @this, 
            BaseTypeDeclarationSyntax @baseType)
        {
            return @this.AddTypeParameterListParameters(
                SyntaxFactory.TypeParameter(
                    @baseType.Identifier));
        }

        # endregion TypeParameters

        # region • ConstraintClauses •

        public static StructDeclarationSyntax AddNewConstraint(this StructDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.ConstructorConstraint());
        }

        public static StructDeclarationSyntax AddClassConstraint(this StructDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.ClassKeyword));
        }

        public static StructDeclarationSyntax AddStructConstraint(this StructDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.StructKeyword));
        }

        public static StructDeclarationSyntax AddTypeConstraint(this StructDeclarationSyntax @this,
            String @typeParameter, String @typeName)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(SyntaxFactory.ParseTypeName(@typeName)));
        }

        public static StructDeclarationSyntax AddTypeConstraint(this StructDeclarationSyntax @this,
            String @typeParameter, TypeSyntax @typeSyntax)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(@typeSyntax));
        }

        public static StructDeclarationSyntax WithNewConstraints(this StructDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.ConstructorConstraint());
        }

        public static StructDeclarationSyntax WithClassConstraint(this StructDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.ClassKeyword));
        }

        public static StructDeclarationSyntax WithStructConstraint(this StructDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.StructKeyword));
        }

        public static StructDeclarationSyntax WithTypeConstraint(this StructDeclarationSyntax @this,
            String @typeParameter, String @typeName)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(SyntaxFactory.ParseTypeName(@typeName)));
        }

        public static StructDeclarationSyntax WithTypeConstraint(this StructDeclarationSyntax @this,
            String @typeParameter, TypeSyntax @typeSyntax)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(@typeSyntax));
        }

        # endregion ConstraintClauses

        # region • BaseList •

        private static StructDeclarationSyntax AddInterface(this StructDeclarationSyntax @this,
            BaseTypeSyntax @interfaceTypeSyntax)
        {
            return @this.AddBaseListTypes(@interfaceTypeSyntax);
        }

        public static StructDeclarationSyntax WithInterface(this StructDeclarationSyntax @this,
            String @interfaceTypeName)
        {
            return @this.WithBaseList(
                SyntaxFactory.BaseList())
                .AddInterface(@interfaceTypeName);
        }

        public static StructDeclarationSyntax WithInterface(this StructDeclarationSyntax @this,
            BaseTypeSyntax @interfaceTypeSyntax)
        {
            return @this.WithBaseList(
                SyntaxFactory.BaseList())
                .AddInterface(@interfaceTypeSyntax);
        }

        # endregion BaseList

        # region • Member Methods •

        public static StructDeclarationSyntax AddDelegates(this StructDeclarationSyntax @this,
            params DelegateDeclarationSyntax[] @delegatesSyntax)
        {
            return @this.AddMembers(@delegatesSyntax);
        }

        public static StructDeclarationSyntax AddEvents(this StructDeclarationSyntax @this,
            params EventDeclarationSyntax[] @eventsSyntax)
        {
            return @this.AddMembers(@eventsSyntax);
        }

        public static StructDeclarationSyntax AddOperators(this StructDeclarationSyntax @this,
            params OperatorDeclarationSyntax[] @operatorsSyntax)
        {
            return @this.AddMembers(@operatorsSyntax);
        }

        public static StructDeclarationSyntax AddConversionOperators(this StructDeclarationSyntax @this,
            params ConversionOperatorDeclarationSyntax[] @conversionOperatorsSyntax)
        {
            return @this.AddMembers(@conversionOperatorsSyntax);
        }

        public static StructDeclarationSyntax AddFields(this StructDeclarationSyntax @this,
            params FieldDeclarationSyntax[] @fieldsSyntax)
        {
            return @this.AddMembers(@fieldsSyntax);
        }

        public static StructDeclarationSyntax AddIndexers(this StructDeclarationSyntax @this,
            params IndexerDeclarationSyntax[] @indexersSyntax)
        {
            return @this.AddMembers(@indexersSyntax);
        }

        public static StructDeclarationSyntax AddProperties(this StructDeclarationSyntax @this,
            params PropertyDeclarationSyntax[] @propertiesSyntax)
        {
            return @this.AddMembers(@propertiesSyntax);
        }

        public static StructDeclarationSyntax AddConstructors(this StructDeclarationSyntax @this,
            params ConstructorDeclarationSyntax[] @constructorsSyntax)
        {
            return @this.AddMembers(@constructorsSyntax);
        }

        public static StructDeclarationSyntax AddMethods(this StructDeclarationSyntax @this,
            params MethodDeclarationSyntax[] @methodsSyntax)
        {
            return @this.AddMembers(@methodsSyntax);
        }

        public static StructDeclarationSyntax AddInterfaces(this StructDeclarationSyntax @this,
            params InterfaceDeclarationSyntax[] @interfacesSyntax)
        {
            return @this.AddMembers(@interfacesSyntax);
        }

        public static StructDeclarationSyntax AddClasses(this StructDeclarationSyntax @this,
            params ClassDeclarationSyntax[] @classesSyntax)
        {
            return @this.AddMembers(@classesSyntax);
        }

        public static StructDeclarationSyntax AddStructs(this StructDeclarationSyntax @this,
            params StructDeclarationSyntax[] @structsSyntax)
        {
            return @this.AddMembers(@structsSyntax);
        }

        public static StructDeclarationSyntax AddEnums(this StructDeclarationSyntax @this,
            params EnumDeclarationSyntax[] @enumsSyntax)
        {
            return @this.AddMembers(@enumsSyntax);
        }

        # endregion Member Methods

        # region • Members •

        # region • Delegates •

        public static IEnumerable<DelegateDeclarationSyntax> GetDelegates(
            this StructDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.DelegateDeclaration)
                .Cast<DelegateDeclarationSyntax>();
        }

        # endregion Events

        # region • Events •

        public static IEnumerable<EventDeclarationSyntax> GetEvents(
            this StructDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.EventDeclaration)
                .Cast<EventDeclarationSyntax>();
        }

        # endregion Events

        # region • Fields •

        public static IEnumerable<FieldDeclarationSyntax> GetFields(
            this StructDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.FieldDeclaration)
                .Cast<FieldDeclarationSyntax>();
        }

        # endregion Fields

        # region • Indexers •

        public static IEnumerable<IndexerDeclarationSyntax> GetIndexers(
            this StructDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.IndexerDeclaration)
                .Cast<IndexerDeclarationSyntax>();
        }

        # endregion Indexers

        # region • Properties •

        public static IEnumerable<PropertyDeclarationSyntax> GetProperties(
            this StructDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.PropertyDeclaration)
                .Cast<PropertyDeclarationSyntax>();
        }

        # endregion Properties

        # region • Constructors •

        public static IEnumerable<ConstructorDeclarationSyntax> GetConstructors(
            this StructDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.ConstructorDeclaration)
                .Cast<ConstructorDeclarationSyntax>();
        }

        # endregion Constructors

        # region • Operators •

        public static IEnumerable<OperatorDeclarationSyntax> GetOperators(
            this StructDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.OperatorDeclaration)
                .Cast<OperatorDeclarationSyntax>();
        }

        public static IEnumerable<ConversionOperatorDeclarationSyntax> GetConversionOperators(
            this StructDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.ConversionOperatorDeclaration)
                .Cast<ConversionOperatorDeclarationSyntax>();
        }

        # endregion Operators

        # region • Methods •

        public static IEnumerable<MethodDeclarationSyntax> GetMethods(
            this StructDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.MethodDeclaration)
                .Cast<MethodDeclarationSyntax>();
        }

        # endregion Methods

        # region • Inner Interfaces •

        public static IEnumerable<InterfaceDeclarationSyntax> GetInterfaces(
            this StructDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.InterfaceDeclaration)
                .Cast<InterfaceDeclarationSyntax>();
        }

        # endregion Inner Interfaces

        # region • Inner Classes •

        public static IEnumerable<ClassDeclarationSyntax> GetClasses(
            this StructDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.ClassDeclaration)
                .Cast<ClassDeclarationSyntax>();
        }

        # endregion Inner Classes

        # region • Inner Stucts •

        public static IEnumerable<StructDeclarationSyntax> GetStructs(
            this StructDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.StructDeclaration)
                .Cast<StructDeclarationSyntax>();
        }

        # endregion Inner Stucts

        # region • Inner Enums •

        public static IEnumerable<EnumDeclarationSyntax> GetEnums(
            this StructDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.EnumDeclaration)
                .Cast<EnumDeclarationSyntax>();
        }

        # endregion Inner Enums

        public static IEnumerable<MemberDeclarationSyntax> GetMembers(
            this StructDeclarationSyntax @this)
        {
            return @this.Members;
        }

        # endregion Members

        # region • Helpers •

        public static Boolean IsPartial(this StructDeclarationSyntax @this)
        {
            return @this.Modifiers.Contains(
                SyntaxFactory.Token(
                    SyntaxKind.PartialKeyword));
        }

        public static Boolean HasBase(this StructDeclarationSyntax @this)
        {
            return @this.BaseList != null && @this.BaseList.Types.Any();
        }

        # endregion Helpers
    }
}

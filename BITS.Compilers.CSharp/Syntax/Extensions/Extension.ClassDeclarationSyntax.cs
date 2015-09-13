using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static class ExtensionClassDeclarationSyntax
    {
        # region • Attributes •

        public static ClassDeclarationSyntax AddAttribute(this ClassDeclarationSyntax @this,
           String @name)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name));
        }

        public static ClassDeclarationSyntax AddAttribute(this ClassDeclarationSyntax @this,
            String @name, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @expression));
        }

        public static ClassDeclarationSyntax AddAttribute(this ClassDeclarationSyntax @this,
            String @name, String @argumentName, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @argumentName, @expression));
        }

        public static IEnumerable<AttributeListSyntax> GetAttributes(
            this ClassDeclarationSyntax @this)
        {
            return @this.AttributeLists;
        }

        # endregion Attributes

        # region • Modifiers •

        public static ClassDeclarationSyntax AddModifiers(this ClassDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.AddModifiers(
                @modifier.GetSyntaxTokens().ToArray());
        }

        public static ClassDeclarationSyntax WithModifiers(this ClassDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.WithModifiers(
                SyntaxFactory.TokenList(@modifier.GetSyntaxTokens()));
        }

        # endregion Modifiers

        # region • Identifier •

        public static ClassDeclarationSyntax WithIdentifier(this ClassDeclarationSyntax @this,
            String @identifier)
        {
            return @this.WithIdentifier(
                SyntaxFactory.Identifier(identifier));
        }

        # endregion Identifier

        # region • TypeParameters •

        public static ClassDeclarationSyntax AddTypeParameter<TType>(this ClassDeclarationSyntax @this,
            Boolean @withFullName = false)
        {
            var type = typeof(TType);

            return @this.AddTypeParameter(
                @withFullName
                    ? type.GetFullName()
                    : type.GetName());
        }

        public static ClassDeclarationSyntax AddTypeParameter(this ClassDeclarationSyntax @this,
            String @typeIdentifier)
        {
            return @this.AddTypeParameterListParameters(
                SyntaxFactory.TypeParameter(
                    SyntaxFactory.Identifier(@typeIdentifier)));
        }

        public static ClassDeclarationSyntax AddTypeParameter(this ClassDeclarationSyntax @this, 
            BaseTypeDeclarationSyntax @baseType)
        {
            return @this.AddTypeParameterListParameters(
                SyntaxFactory.TypeParameter(
                    @baseType.Identifier));
        }

        # endregion TypeParameters

        # region • BaseList •

        private static ClassDeclarationSyntax AddBaseClass(this ClassDeclarationSyntax @this,
            String @classTypeName)
        {
            return @this.AddBaseClass(
                SyntaxFactory.SimpleBaseType(
                    SyntaxFactory.ParseTypeName(
                        SyntaxFactory.Identifier(@classTypeName).ToFullString())));
        }

        private static ClassDeclarationSyntax AddInterface(this ClassDeclarationSyntax @this,
            String @interfaceTypeName)
        {
            return @this.AddInterface(
                SyntaxFactory.SimpleBaseType(
                    SyntaxFactory.ParseTypeName(
                        SyntaxFactory.Identifier(@interfaceTypeName).ToFullString())));
        }

        # endregion BaseList

        # region • ConstraintClauses •

        private static ClassDeclarationSyntax AddConstraints(this ClassDeclarationSyntax @this,
            String @typeParameter, params TypeParameterConstraintSyntax[] @typeParameterConstraintSyntaxs)
        {
            var clause = @this.ConstraintClauses
                .FirstOrDefault(x => x.Name == SyntaxFactory.ParseName(@typeParameter));

            if (clause == null)
            {
                return @this.AddConstraintClauses(
                    SyntaxFactory.TypeParameterConstraintClause(@typeParameter)
                        .AddConstraints(@typeParameterConstraintSyntaxs));
            }

            return @this.AddConstraintClauses(
                clause.AddConstraints(@typeParameterConstraintSyntaxs));
        }

        private static ClassDeclarationSyntax WithConstraints(this ClassDeclarationSyntax @this,
           String @typeParameter, params TypeParameterConstraintSyntax[] @typeParameterConstraintSyntaxs)
        {
            return @this.WithConstraintClauses(SyntaxFactory.List<TypeParameterConstraintClauseSyntax>()
                .Add(SyntaxFactory.TypeParameterConstraintClause(@typeParameter)
                    .AddConstraints(@typeParameterConstraintSyntaxs)));
        }

        public static ClassDeclarationSyntax AddNewConstraint(this ClassDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.ConstructorConstraint());
        }

        public static ClassDeclarationSyntax AddClassConstraint(this ClassDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.ClassKeyword));
        }

        public static ClassDeclarationSyntax AddStructConstraint(this ClassDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.StructKeyword));
        }

        public static ClassDeclarationSyntax AddTypeConstraint(this ClassDeclarationSyntax @this,
            String @typeParameter, String @typeName)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(SyntaxFactory.ParseTypeName(@typeName)));
        }

        public static ClassDeclarationSyntax AddTypeConstraint(this ClassDeclarationSyntax @this,
            String @typeParameter, TypeSyntax @typeSyntax)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(@typeSyntax));
        }

        public static ClassDeclarationSyntax WithNewConstraints(this ClassDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.ConstructorConstraint());
        }

        public static ClassDeclarationSyntax WithClassConstraint(this ClassDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.ClassKeyword));
        }

        public static ClassDeclarationSyntax WithStructConstraint(this ClassDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.StructKeyword));
        }

        public static ClassDeclarationSyntax WithTypeConstraint(this ClassDeclarationSyntax @this,
            String @typeParameter, String @typeName)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(SyntaxFactory.ParseTypeName(@typeName)));
        }

        public static ClassDeclarationSyntax WithTypeConstraint(this ClassDeclarationSyntax @this,
            String @typeParameter, TypeSyntax @typeSyntax)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(@typeSyntax));
        }

        # endregion ConstraintClauses

        # region • BaseList •

        private static ClassDeclarationSyntax AddBaseClass(this ClassDeclarationSyntax @this,
            BaseTypeSyntax @classTypeSyntax)
        {
            return @this.AddBaseListTypes(@classTypeSyntax);
        }

        public static ClassDeclarationSyntax WithBaseClass(this ClassDeclarationSyntax @this,
            String @typeName)
        {
            return @this.WithBaseList(
                SyntaxFactory.BaseList())
                .AddBaseClass(@typeName);
        }

        public static ClassDeclarationSyntax WithBaseClass(this ClassDeclarationSyntax @this,
            BaseTypeSyntax @classTypeSyntax)
        {
            return @this.WithBaseList(
                SyntaxFactory.BaseList())
                .AddBaseClass(@classTypeSyntax);
        }

        private static ClassDeclarationSyntax AddInterface(this ClassDeclarationSyntax @this,
            BaseTypeSyntax @interfaceTypeSyntax)
        {
            return @this.AddBaseListTypes(@interfaceTypeSyntax);
        }

        public static ClassDeclarationSyntax WithInterface(this ClassDeclarationSyntax @this,
            String @interfaceTypeName)
        {
            return @this.WithBaseList(
                SyntaxFactory.BaseList())
                .AddInterface(@interfaceTypeName);
        }

        public static ClassDeclarationSyntax WithInterface(this ClassDeclarationSyntax @this,
            BaseTypeSyntax @interfaceTypeSyntax)
        {
            return @this.WithBaseList(
                SyntaxFactory.BaseList())
                .AddInterface(@interfaceTypeSyntax);
        }

        # endregion BaseList

        # region • Members •

        # region • Delegates •

        public static ClassDeclarationSyntax AddDelegates(this ClassDeclarationSyntax @this,
            params DelegateDeclarationSyntax[] @delegatesSyntax)
        {
            return @this.AddMembers(@delegatesSyntax);
        }

        public static IEnumerable<DelegateDeclarationSyntax> GetDelegates(
            this ClassDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.DelegateDeclaration)
                .Cast<DelegateDeclarationSyntax>();
        }

        # endregion Delegates

        # region • Events •

        public static ClassDeclarationSyntax AddEvents(this ClassDeclarationSyntax @this,
            params EventDeclarationSyntax[] @eventsSyntax)
        {
            return @this.AddMembers(@eventsSyntax);
        }

        public static IEnumerable<EventDeclarationSyntax> GetEvents(
            this ClassDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.EventDeclaration)
                .Cast<EventDeclarationSyntax>();
        }

        # endregion Events

        # region • Operators •

        public static ClassDeclarationSyntax AddOperators(this ClassDeclarationSyntax @this,
            params OperatorDeclarationSyntax[] @operatorsSyntax)
        {
            return @this.AddMembers(@operatorsSyntax);
        }

        public static IEnumerable<OperatorDeclarationSyntax> GetOperators(
            this ClassDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.OperatorDeclaration)
                .Cast<OperatorDeclarationSyntax>();
        }

        public static ClassDeclarationSyntax AddConversionOperators(this ClassDeclarationSyntax @this,
            params ConversionOperatorDeclarationSyntax[] @conversionOperatorsSyntax)
        {
            return @this.AddMembers(@conversionOperatorsSyntax);
        }

        public static IEnumerable<ConversionOperatorDeclarationSyntax> GetConversionOperators(
            this ClassDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.ConversionOperatorDeclaration)
                .Cast<ConversionOperatorDeclarationSyntax>();
        }

        # endregion Operators

        # region • Fields •

        public static ClassDeclarationSyntax AddFields(this ClassDeclarationSyntax @this,
            params FieldDeclarationSyntax[] @fieldsSyntax)
        {
            return @this.AddMembers(@fieldsSyntax);
        }

        public static IEnumerable<FieldDeclarationSyntax> GetFields(
            this ClassDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.FieldDeclaration)
                .Cast<FieldDeclarationSyntax>();
        }

        # endregion Fields

        # region • Indexers •

        public static ClassDeclarationSyntax AddIndexers(this ClassDeclarationSyntax @this,
            params IndexerDeclarationSyntax[] @indexersSyntax)
        {
            return @this.AddMembers(@indexersSyntax);
        }

        public static IEnumerable<IndexerDeclarationSyntax> GetIndexers(
            this ClassDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.IndexerDeclaration)
                .Cast<IndexerDeclarationSyntax>();
        }

        # endregion Indexers

        # region • Properties •

        public static ClassDeclarationSyntax AddProperties(this ClassDeclarationSyntax @this,
            params PropertyDeclarationSyntax[] @propertiesSyntax)
        {
            return @this.AddMembers(@propertiesSyntax);
        }

        public static IEnumerable<PropertyDeclarationSyntax> GetProperties(
            this ClassDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.PropertyDeclaration)
                .Cast<PropertyDeclarationSyntax>();
        }

        # endregion Properties

        # region • Constructors •

        public static ClassDeclarationSyntax AddConstructors(this ClassDeclarationSyntax @this,
            params ConstructorDeclarationSyntax[] @constructorsSyntax)
        {
            return @this.AddMembers(@constructorsSyntax);
        }

        public static IEnumerable<ConstructorDeclarationSyntax> GetConstructors(
            this ClassDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.ConstructorDeclaration)
                .Cast<ConstructorDeclarationSyntax>();
        }

        # endregion Constructors

        # region • Methods •

        public static ClassDeclarationSyntax AddMethods(this ClassDeclarationSyntax @this,
            params MethodDeclarationSyntax[] @methodsSyntax)
        {
            return @this.AddMembers(@methodsSyntax);
        }

        public static IEnumerable<MethodDeclarationSyntax> GetMethods(
            this ClassDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.MethodDeclaration)
                .Cast<MethodDeclarationSyntax>();
        }

        # endregion Methods

        # region • Inner Interfaces •

        public static ClassDeclarationSyntax AddInterfaces(this ClassDeclarationSyntax @this,
            params InterfaceDeclarationSyntax[] @interfacesSyntax)
        {
            return @this.AddMembers(@interfacesSyntax);
        }

        public static IEnumerable<InterfaceDeclarationSyntax> GetInterfaces(
            this ClassDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.InterfaceDeclaration)
                .Cast<InterfaceDeclarationSyntax>();
        }

        # endregion Inner Interfaces

        # region • Inner Classes •

        public static ClassDeclarationSyntax AddClasses(this ClassDeclarationSyntax @this,
            params ClassDeclarationSyntax[] @clssesSyntax)
        {
            return @this.AddMembers(@clssesSyntax);
        }

        public static IEnumerable<ClassDeclarationSyntax> GetClasses(
            this ClassDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.ClassDeclaration)
                .Cast<ClassDeclarationSyntax>();
        }

        # endregion Inner Classes

        # region • Inner Stucts •

        public static ClassDeclarationSyntax AddStructs(this ClassDeclarationSyntax @this,
            params StructDeclarationSyntax[] @structsSyntax)
        {
            return @this.AddMembers(@structsSyntax);
        }

        public static IEnumerable<StructDeclarationSyntax> GetStructs(
            this ClassDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.StructDeclaration)
                .Cast<StructDeclarationSyntax>();
        }

        # endregion Inner Stucts

        # region • Inner Enums •

        public static ClassDeclarationSyntax AddEnums(this ClassDeclarationSyntax @this,
            params EnumDeclarationSyntax[] @enumsSyntax)
        {
            return @this.AddMembers(@enumsSyntax);
        }

        public static IEnumerable<EnumDeclarationSyntax> GetEnums(
            this ClassDeclarationSyntax @this)
        {
            return @this.Members
                .Where(x => x.Kind() == SyntaxKind.EnumDeclaration)
                .Cast<EnumDeclarationSyntax>();
        }

        # endregion Inner Enums

        public static IEnumerable<MemberDeclarationSyntax> GetMembers(
            this ClassDeclarationSyntax @this)
        {
            return @this.Members;
        }

        # endregion Members

        # region • Helpers •

        public static Boolean IsPartial(this ClassDeclarationSyntax @this)
        {
            return @this.Modifiers.Contains(
                SyntaxFactory.Token(
                    SyntaxKind.PartialKeyword));
        }

        public static Boolean HasBase(this ClassDeclarationSyntax @this)
        {
            return @this.BaseList != null && @this.BaseList.Types.Any();
        }

        # endregion Helpers
    }
}

using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionTypeParameterConstraintClauseSyntax
    {
        # region • Constraints •

        public static TypeParameterConstraintClauseSyntax AddNewConstraint(
            this TypeParameterConstraintClauseSyntax @this)
        {
            return @this.AddConstraint(
                SyntaxFactory.ConstructorConstraint());
        }

        public static TypeParameterConstraintClauseSyntax AddClassConstraint(
            this TypeParameterConstraintClauseSyntax @this)
        {
            return @this.AddConstraint(
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.ClassKeyword));
        }

        public static TypeParameterConstraintClauseSyntax AddStructConstraint(
            this TypeParameterConstraintClauseSyntax @this)
        {
            return @this.AddConstraint(
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.StructKeyword));
        }

        public static TypeParameterConstraintClauseSyntax AddTypeConstraint(
            this TypeParameterConstraintClauseSyntax @this, String @typeName)
        {
            return @this.AddConstraint(
                SyntaxFactory.TypeConstraint(SyntaxFactory.ParseTypeName(@typeName)));
        }

        public static TypeParameterConstraintClauseSyntax AddTypeConstraint(
            this TypeParameterConstraintClauseSyntax @this, TypeSyntax @typeSyntax)
        {
            return @this.AddConstraint(
                SyntaxFactory.TypeConstraint(@typeSyntax));
        }

        private static TypeParameterConstraintClauseSyntax AddConstraint(
            this TypeParameterConstraintClauseSyntax @this,
            TypeParameterConstraintSyntax @typeParameterConstraintSyntax)
        {
            var result = @this.Constraints
                .Any(x => x == @typeParameterConstraintSyntax);

            if (result)
                return @this;

            return @this.AddConstraints(
                @typeParameterConstraintSyntax);
        }

        public static TypeParameterConstraintClauseSyntax WithNewConstraints(
            this TypeParameterConstraintClauseSyntax @this)
        {
            return @this.WithConstraints(
                SyntaxFactory.ConstructorConstraint());
        }

        public static TypeParameterConstraintClauseSyntax WithClassConstraint(
            this TypeParameterConstraintClauseSyntax @this)
        {
            return @this.WithConstraints(
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.ClassKeyword));
        }

        public static TypeParameterConstraintClauseSyntax WithStructConstraint(
            this TypeParameterConstraintClauseSyntax @this)
        {
            return @this.WithConstraints(
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.StructKeyword));
        }

        public static TypeParameterConstraintClauseSyntax WithTypeConstraint(
            this TypeParameterConstraintClauseSyntax @this, String @typeName)
        {
            return @this.WithConstraints(
                SyntaxFactory.TypeConstraint(SyntaxFactory.ParseTypeName(@typeName)));
        }

        public static TypeParameterConstraintClauseSyntax WithTypeConstraint(
            this TypeParameterConstraintClauseSyntax @this, TypeSyntax @typeSyntax)
        {
            return @this.WithConstraints(
                SyntaxFactory.TypeConstraint(@typeSyntax));
        }

        private static TypeParameterConstraintClauseSyntax WithConstraints(
            this TypeParameterConstraintClauseSyntax @this,
            params TypeParameterConstraintSyntax[] @typeParameterConstraintSyntaxs)
        {
            return @this.WithConstraints(
                SyntaxFactory.SeparatedList(
                    @typeParameterConstraintSyntaxs,
                    Enumerable.Repeat(
                        SyntaxFactory.Token(SyntaxKind.CommaToken),
                        @typeParameterConstraintSyntaxs.Count() - 1)));
        }

        # endregion Constraints

        # region • Name •

        public static TypeParameterConstraintClauseSyntax WithName(
            this TypeParameterConstraintClauseSyntax @this, String @typeName)
        {
            return @this.WithName(
                SyntaxFactory.IdentifierName(@typeName));
        }

        # endregion Name
    }
}

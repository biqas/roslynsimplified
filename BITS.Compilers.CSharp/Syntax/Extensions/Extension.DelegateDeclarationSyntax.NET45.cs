﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionDelegateDeclarationSyntax
    {
        # region • Attributes •

        public static DelegateDeclarationSyntax AddAttribute(this DelegateDeclarationSyntax @this,
           String @name)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name));
        }

        public static DelegateDeclarationSyntax AddAttribute(this DelegateDeclarationSyntax @this,
            String @name, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @expression));
        }

        public static DelegateDeclarationSyntax AddAttribute(this DelegateDeclarationSyntax @this,
            String @name, String @argumentName, String @expression)
        {
            return @this.AddAttributeLists(
                SyntaxFactory.AttributeList()
                    .AddAttribute(@name, @argumentName, @expression));
        }

        public static IEnumerable<AttributeListSyntax> GetAttributes(
            this DelegateDeclarationSyntax @this)
        {
            return @this.AttributeLists;
        }

        # endregion Attributes

        # region • ConstraintClauses •

        private static DelegateDeclarationSyntax AddConstraints(this DelegateDeclarationSyntax @this,
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

        private static DelegateDeclarationSyntax WithConstraints(this DelegateDeclarationSyntax @this,
           String @typeParameter, params TypeParameterConstraintSyntax[] @typeParameterConstraintSyntaxs)
        {
            return @this.WithConstraintClauses(SyntaxFactory.List<TypeParameterConstraintClauseSyntax>()
                .Add(SyntaxFactory.TypeParameterConstraintClause(@typeParameter)
                    .AddConstraints(@typeParameterConstraintSyntaxs)));
        }

        # endregion ConstraintClauses
    }
}

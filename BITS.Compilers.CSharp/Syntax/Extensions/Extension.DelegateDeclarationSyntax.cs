using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionDelegateDeclarationSyntax
    {
        # region • Modifiers •

        public static DelegateDeclarationSyntax AddModifiers(this DelegateDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.AddModifiers(
                @modifier.GetSyntaxTokens().ToArray());
        }

        public static DelegateDeclarationSyntax WithModifiers(this DelegateDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.WithModifiers(
                SyntaxFactory.TokenList(@modifier.GetSyntaxTokens()));
        }

        # endregion Modifiers

        # region • Identifier •

        public static DelegateDeclarationSyntax WithIdentifier(this DelegateDeclarationSyntax @this,
            String @identifier)
        {
            return @this.WithIdentifier(
                SyntaxFactory.Identifier(@identifier));
        }

        # endregion Identifier

        # region • ReturnType •

        public static DelegateDeclarationSyntax WithReturnVoid(this DelegateDeclarationSyntax @this)
        {
            return @this.WithReturnType(
                SyntaxFactory.ParseTypeName("void"));
        }

        public static DelegateDeclarationSyntax WithReturnType<TType>(this DelegateDeclarationSyntax @this,
            Boolean @withFullName = false)
        {
            return @this.WithReturnType(
                typeof(TType), @withFullName);
        }

        public static DelegateDeclarationSyntax WithReturnType(this DelegateDeclarationSyntax @this,
            System.Type @type, Boolean @withFullName = false)
        {
            return @this.WithReturnType(@withFullName
                ? @type.GetFullName()
                : @type.GetName());
        }

        public static DelegateDeclarationSyntax WithReturnType(this DelegateDeclarationSyntax @this,
            String @typeName)
        {
            return @this.WithReturnType(
                SyntaxFactory.ParseTypeName(@typeName));
        }

        # endregion ReturnType

        # region • TypeParameters •

        public static DelegateDeclarationSyntax AddTypeParameter(this DelegateDeclarationSyntax @this,
            String @typeParameterName, String @parameterName)
        {
            return @this.AddTypeParameter(@typeParameterName)
                .AddParameter(@typeParameterName, @parameterName);
        }

        public static DelegateDeclarationSyntax AddTypeParameter(this DelegateDeclarationSyntax @this,
            String @typeParameterName)
        {
            return @this.AddTypeParameterListParameters(
                SyntaxFactory.TypeParameter(
                    @typeParameterName));
        }

        public static DelegateDeclarationSyntax WithTypeParameters(this DelegateDeclarationSyntax @this,
            params String[] @typeParameterNames)
        {
            return @this.WithTypeParameterList(
                SyntaxFactory.TypeParameterList()
                    .AddParameters(
                        @typeParameterNames.Select(
                            SyntaxFactory.TypeParameter).ToArray()));
        }

        # endregion TypeParameters

        # region • Parameters •

        public static DelegateDeclarationSyntax AddParameter<TType>(this DelegateDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                typeof(TType), @parameterName, @withFullName);
        }

        public static DelegateDeclarationSyntax AddParameter(this DelegateDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(@withFullName
                ? @type.GetFullName()
                : @type.GetName(), @parameterName);
        }

        public static DelegateDeclarationSyntax AddParameter(this DelegateDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameterListParameters(
                SyntaxFactory.Parameter(SyntaxFactory.Identifier(@parameterName))
                    .WithType(@typeName));
        }

        public static DelegateDeclarationSyntax AddInParameter<TType>(this DelegateDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.IN, @parameterName, @withFullName);
        }

        public static DelegateDeclarationSyntax AddInParameter(this DelegateDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.IN, @type, @parameterName, @withFullName);
        }

        public static DelegateDeclarationSyntax AddInParameter(this DelegateDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.IN, @typeName, @parameterName);
        }

        public static DelegateDeclarationSyntax AddOutParameter<TType>(this DelegateDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.OUT, @parameterName, @withFullName);
        }

        public static DelegateDeclarationSyntax AddOutParameter(this DelegateDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.OUT, @type, @parameterName, @withFullName);
        }

        public static DelegateDeclarationSyntax AddOutParameter(this DelegateDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.OUT, @typeName, @parameterName);
        }

        public static DelegateDeclarationSyntax AddRefParameter<TType>(this DelegateDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.REF, @parameterName, @withFullName);
        }

        public static DelegateDeclarationSyntax AddRefParameter(this DelegateDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.REF, @type, @parameterName, @withFullName);
        }

        public static DelegateDeclarationSyntax AddRefParameter(this DelegateDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.REF, @typeName, @parameterName);
        }

        public static DelegateDeclarationSyntax AddParamsParameter<TType>(this DelegateDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.PARAMS, @parameterName, @withFullName);
        }

        public static DelegateDeclarationSyntax AddParamsParameter(this DelegateDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.PARAMS, @type, @parameterName, @withFullName);
        }

        public static DelegateDeclarationSyntax AddParamsParameter(this DelegateDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.PARAMS, @typeName, @parameterName);
        }

        public static DelegateDeclarationSyntax AddParameter<TType>(this DelegateDeclarationSyntax @this,
            PARAMETER_TYPE @modifier, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(@modifier,
                typeof(TType), @parameterName, @withFullName);
        }

        public static DelegateDeclarationSyntax AddParameter(this DelegateDeclarationSyntax @this,
            PARAMETER_TYPE @modifier, System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                @modifier, @withFullName
                    ? @type.GetFullName()
                    : @type.GetName(), @parameterName);
        }

        public static DelegateDeclarationSyntax AddParameter(this DelegateDeclarationSyntax @this,
            PARAMETER_TYPE @modifier, String @typeName, String @parameterName)
        {
            if (@modifier == PARAMETER_TYPE.PARAMS)
            {
                if (@typeName.LastIndexOf("[]", StringComparison.Ordinal) <= 0 && @parameterName.LastIndexOf("[]", StringComparison.Ordinal) <= 0)
                    @typeName += "[]";
            }

            return @this.AddParameterListParameters(
                SyntaxFactory.Parameter(SyntaxFactory.Identifier(@parameterName))
                    .WithModifiers(@modifier)
                    .WithType(@typeName));
        }

        # endregion Parameters

        # region • ConstraintClauses •

        public static DelegateDeclarationSyntax AddNewConstraint(this DelegateDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.ConstructorConstraint());
        }

        public static DelegateDeclarationSyntax AddClassConstraint(this DelegateDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.ClassKeyword));
        }

        public static DelegateDeclarationSyntax AddStructConstraint(this DelegateDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.StructKeyword));
        }

        public static DelegateDeclarationSyntax AddTypeConstraint(this DelegateDeclarationSyntax @this,
            String @typeParameter, String @typeName)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(SyntaxFactory.ParseTypeName(@typeName)));
        }

        public static DelegateDeclarationSyntax AddTypeConstraint(this DelegateDeclarationSyntax @this,
            String @typeParameter, TypeSyntax @typeSyntax)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(@typeSyntax));
        }

        public static DelegateDeclarationSyntax WithNewConstraints(this DelegateDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.ConstructorConstraint());
        }

        public static DelegateDeclarationSyntax WithClassConstraint(this DelegateDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.ClassKeyword));
        }

        public static DelegateDeclarationSyntax WithStructConstraint(this DelegateDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.StructKeyword));
        }

        public static DelegateDeclarationSyntax WithTypeConstraint(this DelegateDeclarationSyntax @this,
            String @typeParameter, String @typeName)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(SyntaxFactory.ParseTypeName(@typeName)));
        }

        public static DelegateDeclarationSyntax WithTypeConstraint(this DelegateDeclarationSyntax @this,
            String @typeParameter, TypeSyntax @typeSyntax)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(@typeSyntax));
        }

        # endregion ConstraintClauses
    }
}

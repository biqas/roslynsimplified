using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionMethodDeclarationSyntax
    {
        # region • Modifiers •

        public static MethodDeclarationSyntax AddModifiers(this MethodDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.AddModifiers(
                @modifier.GetSyntaxTokens().ToArray());
        }

        public static MethodDeclarationSyntax WithModifiers(this MethodDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.WithModifiers(
                SyntaxFactory.TokenList(@modifier.GetSyntaxTokens()));
        }

        # endregion Modifiers

        # region • ReturnType •

        public static MethodDeclarationSyntax WithReturnVoid(this MethodDeclarationSyntax @this)
        {
            return @this.WithReturnType(
                SyntaxFactory.ParseTypeName("void"));
        }

        public static MethodDeclarationSyntax WithReturnType<TType>(this MethodDeclarationSyntax @this,
            Boolean @withFullName = false)
        {
            return @this.WithReturnType(
                typeof(TType), @withFullName);
        }

        public static MethodDeclarationSyntax WithReturnType(this MethodDeclarationSyntax @this,
            System.Type @type, Boolean @withFullName = false)
        {
            return @this.WithReturnType(@withFullName
                ? @type.GetFullName()
                : @type.GetName());
        }

        public static MethodDeclarationSyntax WithReturnType(this MethodDeclarationSyntax @this,
            String @typeName)
        {
            return @this.WithReturnType(
                SyntaxFactory.ParseTypeName(@typeName));
        }

        # endregion ReturnType

        # region • ExplicitInterface •

        public static MethodDeclarationSyntax WithExplicitInterface(
            this MethodDeclarationSyntax @this, String @interfaceTypeName)
        {
            return @this.WithExplicitInterfaceSpecifier(
                SyntaxFactory.ExplicitInterfaceSpecifier(
                    SyntaxFactory.ParseName(@interfaceTypeName)));
        }

        public static MethodDeclarationSyntax WithExplicitInterface(this MethodDeclarationSyntax @this,
            TypeSyntax @interfaceTypeSyntax)
        {
            return @this.WithExplicitInterfaceSpecifier(
                SyntaxFactory.ExplicitInterfaceSpecifier(
                    SyntaxFactory.ParseName(@interfaceTypeSyntax.ToString())));
        }

        public static MethodDeclarationSyntax WithExplicitInterface(this MethodDeclarationSyntax @this,
            InterfaceDeclarationSyntax @interfaceDeclarationSyntax)
        {
            return @this.WithExplicitInterface(
                @interfaceDeclarationSyntax.GetTypeSyntax());
        }

        # endregion ExplicitInterface

        # region • Identifier •

        public static MethodDeclarationSyntax WithIdentifier(this MethodDeclarationSyntax @this,
            String @identifier)
        {
            return @this.WithIdentifier(
                SyntaxFactory.Identifier(@identifier));
        }

        # endregion Identifier

        # region • TypeParameters •

        public static MethodDeclarationSyntax AddTypeParameter(this MethodDeclarationSyntax @this,
            String @typeParameterName, String @parameterName)
        {
            return @this.AddTypeParameter(@typeParameterName)
                .AddParameter(@typeParameterName, @parameterName);
        }

        public static MethodDeclarationSyntax AddTypeParameter(this MethodDeclarationSyntax @this,
            String @typeParameterName)
        {
            return @this.AddTypeParameterListParameters(
                SyntaxFactory.TypeParameter(
                    @typeParameterName));
        }

        public static MethodDeclarationSyntax WithTypeParameters(this MethodDeclarationSyntax @this,
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

        public static MethodDeclarationSyntax AddParameter<TType>(this MethodDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                typeof(TType), @parameterName, @withFullName);
        }

        public static MethodDeclarationSyntax AddParameter(this MethodDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(@withFullName
                ? @type.GetFullName()
                : @type.GetName(), @parameterName);
        }

        public static MethodDeclarationSyntax AddParameter(this MethodDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameterListParameters(
                SyntaxFactory.Parameter(SyntaxFactory.Identifier(@parameterName))
                    .WithType(@typeName));
        }

        public static MethodDeclarationSyntax AddInParameter<TType>(this MethodDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.IN, @parameterName, @withFullName);
        }

        public static MethodDeclarationSyntax AddInParameter(this MethodDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.IN, @type, @parameterName, @withFullName);
        }

        public static MethodDeclarationSyntax AddInParameter(this MethodDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.IN, @typeName, @parameterName);
        }

        public static MethodDeclarationSyntax AddOutParameter<TType>(this MethodDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.OUT, @parameterName, @withFullName);
        }

        public static MethodDeclarationSyntax AddOutParameter(this MethodDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.OUT, @type, @parameterName, @withFullName);
        }

        public static MethodDeclarationSyntax AddOutParameter(this MethodDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.OUT, @typeName, @parameterName);
        }

        public static MethodDeclarationSyntax AddRefParameter<TType>(this MethodDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.REF, @parameterName, @withFullName);
        }

        public static MethodDeclarationSyntax AddRefParameter(this MethodDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.REF, @type, @parameterName, @withFullName);
        }

        public static MethodDeclarationSyntax AddRefParameter(this MethodDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.REF, @typeName, @parameterName);
        }

        public static MethodDeclarationSyntax AddParamsParameter<TType>(this MethodDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.PARAMS, @parameterName, @withFullName);
        }

        public static MethodDeclarationSyntax AddParamsParameter(this MethodDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.PARAMS, @type, @parameterName, @withFullName);
        }

        public static MethodDeclarationSyntax AddParamsParameter(this MethodDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.PARAMS, @typeName, @parameterName);
        }

        public static MethodDeclarationSyntax AddParameter<TType>(this MethodDeclarationSyntax @this,
            PARAMETER_TYPE @parameterType, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(@parameterType,
                typeof(TType), @parameterName, @withFullName);
        }

        public static MethodDeclarationSyntax AddParameter(this MethodDeclarationSyntax @this,
            PARAMETER_TYPE @parameterType, System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                @parameterType, @withFullName
                    ? @type.GetFullName()
                    : @type.GetName(), @parameterName);
        }

        public static MethodDeclarationSyntax AddParameter(this MethodDeclarationSyntax @this,
            PARAMETER_TYPE @parameterType, String @typeName, String @parameterName)
        {
            if (@parameterType == PARAMETER_TYPE.PARAMS)
            {
                var x1 = @typeName.LastIndexOf("[]", StringComparison.Ordinal)      <= 0;
                var x2 = @parameterName.LastIndexOf("[]", StringComparison.Ordinal) <= 0;

                if (x1 && x2)
                    @typeName += "[]";
            }

            return @this.AddParameterListParameters(
                SyntaxFactory.Parameter(SyntaxFactory.Identifier(@parameterName))
                    .WithModifiers(@parameterType)
                    .WithType(@typeName));
        }

        # endregion Parameters

        # region • ConstraintClauses •

        public static MethodDeclarationSyntax AddNewConstraint(this MethodDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.ConstructorConstraint());
        }

        public static MethodDeclarationSyntax AddClassConstraint(this MethodDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.ClassKeyword));
        }

        public static MethodDeclarationSyntax AddStructConstraint(this MethodDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.StructKeyword));
        }

        public static MethodDeclarationSyntax AddTypeConstraint(this MethodDeclarationSyntax @this,
            String @typeParameter, String @typeName)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(SyntaxFactory.ParseTypeName(@typeName)));
        }

        public static MethodDeclarationSyntax AddTypeConstraint(this MethodDeclarationSyntax @this,
            String @typeParameter, TypeSyntax @typeSyntax)
        {
            return @this.AddConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(@typeSyntax));
        }

        public static MethodDeclarationSyntax WithNewConstraints(this MethodDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.ConstructorConstraint());
        }

        public static MethodDeclarationSyntax WithClassConstraint(this MethodDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.ClassKeyword));
        }

        public static MethodDeclarationSyntax WithStructConstraint(this MethodDeclarationSyntax @this,
            String @typeParameter)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.ClassOrStructConstraint(SyntaxKind.StructKeyword));
        }

        public static MethodDeclarationSyntax WithTypeConstraint(this MethodDeclarationSyntax @this,
            String @typeParameter, String @typeName)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(SyntaxFactory.ParseTypeName(@typeName)));
        }

        public static MethodDeclarationSyntax WithTypeConstraint(this MethodDeclarationSyntax @this,
            String @typeParameter, TypeSyntax @typeSyntax)
        {
            return @this.WithConstraints(
                @typeParameter,
                SyntaxFactory.TypeConstraint(@typeSyntax));
        }

        # endregion ConstraintClauses

        # region • Body •

        public static MethodDeclarationSyntax WithBody(this MethodDeclarationSyntax @this,
            params String[] @statements)
        {
            if (@statements == null || !@statements.Any())
                return @this;

            return @this
                .WithSemicolonToken(default(SyntaxToken))
                .WithBody(Block.Factory(@statements));
        }

        # endregion Body

        # region • Statements •

        public static MethodDeclarationSyntax AddStatements(this MethodDeclarationSyntax @this,
            params String[] @statements)
        {
            if (@this.Body == null)
                @this = @this.WithBody(SyntaxFactory.Block());

            return @this.WithBody(
                @this.Body.AddStatements(@statements))
                .WithSemicolonToken(default(SyntaxToken));
        }

        public static MethodDeclarationSyntax AddStatements(this MethodDeclarationSyntax @this,
            params Expression<Action>[] @statements)
        {
            if (@this.Body == null)
                @this = @this.WithBody(SyntaxFactory.Block());

            return @this.WithBody(
                @this.Body.AddStatements(@statements))
                .WithSemicolonToken(default(SyntaxToken));
        }

        public static MethodDeclarationSyntax WithStatements(this MethodDeclarationSyntax @this,
            params String[] @statements)
        {
            return @this.WithBody(
                SyntaxFactory.Block()
                    .WithStatements(@statements))
                .WithSemicolonToken(default(SyntaxToken));
        }

        # endregion Statements
    }
}

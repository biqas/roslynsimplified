using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionIndexerDeclarationSyntax
    {
        # region • Modifiers •

        public static IndexerDeclarationSyntax AddModifiers(this IndexerDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.AddModifiers(
                @modifier.GetSyntaxTokens().ToArray());
        }

        public static IndexerDeclarationSyntax WithModifiers(this IndexerDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.WithModifiers(
                SyntaxFactory.TokenList(@modifier.GetSyntaxTokens()));
        }

        # endregion Modifiers

        # region • Type •

        public static IndexerDeclarationSyntax WithType<TType>(this IndexerDeclarationSyntax @this,
            Boolean @withfullName = true)
        {
            return @this.WithType(typeof(TType), @withfullName);
        }

        public static IndexerDeclarationSyntax WithType(this IndexerDeclarationSyntax @this,
            System.Type @type, Boolean @withFullName = true)
        {
            return @this.WithType(@withFullName
                ? @type.GetFullName()
                : @type.GetName());
        }

        public static IndexerDeclarationSyntax WithType(this IndexerDeclarationSyntax @this,
            String @typeName)
        {
            return @this.WithType(
                SyntaxFactory.ParseTypeName(@typeName));
        }

        # endregion Type

        # region • Parameters •

        public static IndexerDeclarationSyntax AddParameter<TType>(this IndexerDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                typeof(TType), @parameterName, @withFullName);
        }

        public static IndexerDeclarationSyntax AddParameter(this IndexerDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(@withFullName
                ? @type.GetFullName()
                : @type.GetName(), @parameterName);
        }

        public static IndexerDeclarationSyntax AddParameter(this IndexerDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameterListParameters(
                SyntaxFactory.Parameter(SyntaxFactory.Identifier(@parameterName))
                    .WithType(@typeName));
        }

        public static IndexerDeclarationSyntax AddRefParameter<TType>(this IndexerDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.REF, @parameterName, @withFullName);
        }

        public static IndexerDeclarationSyntax AddRefParameter(this IndexerDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.REF, @type, @parameterName, @withFullName);
        }

        public static IndexerDeclarationSyntax AddRefParameter(this IndexerDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.REF, @typeName, @parameterName);
        }

        public static IndexerDeclarationSyntax AddParamsParameter<TType>(this IndexerDeclarationSyntax @this,
            String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter<TType>(
                PARAMETER_TYPE.PARAMS, @parameterName, @withFullName);
        }

        public static IndexerDeclarationSyntax AddParamsParameter(this IndexerDeclarationSyntax @this,
            System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.PARAMS, @type, @parameterName, @withFullName);
        }

        public static IndexerDeclarationSyntax AddParamsParameter(this IndexerDeclarationSyntax @this,
            String @typeName, String @parameterName)
        {
            return @this.AddParameter(
                PARAMETER_TYPE.PARAMS, @typeName, @parameterName);
        }

        public static IndexerDeclarationSyntax AddParameter<TType>(this IndexerDeclarationSyntax @this,
            PARAMETER_TYPE @parameterType, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(@parameterType,
                typeof(TType), @parameterName, @withFullName);
        }

        public static IndexerDeclarationSyntax AddParameter(this IndexerDeclarationSyntax @this,
            PARAMETER_TYPE @parameterType, System.Type @type, String @parameterName, Boolean @withFullName = false)
        {
            return @this.AddParameter(
                @parameterType, @withFullName
                    ? @type.GetFullName()
                    : @type.GetName(), @parameterName);
        }

        public static IndexerDeclarationSyntax AddParameter(this IndexerDeclarationSyntax @this,
            PARAMETER_TYPE @parameterType, String @typeName, String @parameterName)
        {
            if (@parameterType == PARAMETER_TYPE.PARAMS)
            {
                var x1 = @typeName.LastIndexOf("[]", StringComparison.Ordinal) <= 0;
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

        # region • Getter •

        public static IndexerDeclarationSyntax WithGetter(this IndexerDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            @this = @this.WithGetter();

            var getter = @this.AccessorList.Accessors.Single(
                x => x.Kind() == SyntaxKind.GetAccessorDeclaration);

            return @this.WithGetter(
                getter.WithModifiers(@modifier));
        }

        public static IndexerDeclarationSyntax WithGetter(this IndexerDeclarationSyntax @this,
            params String[] @statements)
        {
            var getter = @this.AccessorList.Accessors.SingleOrDefault(
                x => x.Kind() == SyntaxKind.GetAccessorDeclaration);

            if (getter == default(AccessorDeclarationSyntax))
            {
                getter = SyntaxFactory.AccessorDeclaration(
                    SyntaxKind.GetAccessorDeclaration);
            }

            return @this.WithGetter(getter, @statements);
        }

        public static IndexerDeclarationSyntax WithGetter(this IndexerDeclarationSyntax @this,
            AccessorDeclarationSyntax @getter, params String[] @statements)
        {
            if (@getter.Kind() != SyntaxKind.GetAccessorDeclaration)
            {
                throw new Exception(String.Format(
                    "Given parameter:'{0}' is not a getter", @getter.Kind()));
            }

            @getter = @getter.IsAuto();

            var setter = @this.AccessorList.Accessors.SingleOrDefault(
                x => x.Kind() == SyntaxKind.SetAccessorDeclaration);

            var list = SyntaxFactory.List<AccessorDeclarationSyntax>()
                .Add(@getter.WithBody(@statements));

            if (setter != default(AccessorDeclarationSyntax))
                list = list.Add(setter);

            return @this.WithAccessorList(
                SyntaxFactory.AccessorList(list));
        }

        # endregion Getter

        # region • Setter •

        public static IndexerDeclarationSyntax WithSetter(this IndexerDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            @this = @this.WithSetter();

            var setter = @this.AccessorList.Accessors.Single(
                x => x.Kind() == SyntaxKind.SetAccessorDeclaration);

            return @this.WithSetter(
                setter.WithModifiers(@modifier));
        }

        public static IndexerDeclarationSyntax WithSetter(this IndexerDeclarationSyntax @this,
            params String[] @statements)
        {
            var setter = @this.AccessorList.Accessors.SingleOrDefault(
                x => x.Kind() == SyntaxKind.SetAccessorDeclaration);

            if (setter == default(AccessorDeclarationSyntax))
            {
                setter = SyntaxFactory.AccessorDeclaration(
                    SyntaxKind.SetAccessorDeclaration);
            }

            return @this.WithSetter(setter, @statements);
        }

        public static IndexerDeclarationSyntax WithSetter(this IndexerDeclarationSyntax @this,
            AccessorDeclarationSyntax @setter, params String[] @statements)
        {
            if (@setter.Kind() != SyntaxKind.SetAccessorDeclaration)
            {
                throw new Exception(String.Format(
                    "Given parameter:'{0}' is not a setter", @setter.Kind()));
            }

            @setter = @setter.IsAuto();

            var getter = @this.AccessorList.Accessors.SingleOrDefault(
                x => x.Kind() == SyntaxKind.GetAccessorDeclaration);

            var list = SyntaxFactory.List<AccessorDeclarationSyntax>()
                .Add(@setter.WithBody(@statements));

            if (getter != default(AccessorDeclarationSyntax))
                list = list.Insert(0, getter);

            return @this.WithAccessorList(
                SyntaxFactory.AccessorList(list));
        }

        # endregion Setter
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionPropertyDeclarationSyntax
    {
        # region • Modifiers •

        public static PropertyDeclarationSyntax AddModifiers(this PropertyDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.AddModifiers(
                @modifier.GetSyntaxTokens().ToArray());
        }

        public static PropertyDeclarationSyntax WithModifiers(this PropertyDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            return @this.WithModifiers(
                SyntaxFactory.TokenList(@modifier.GetSyntaxTokens()));
        }

        # endregion Modifiers

        # region • Type •

        public static PropertyDeclarationSyntax WithType<TType>(this PropertyDeclarationSyntax @this,
            Boolean @withfullName = true)
        {
            return @this.WithType(typeof(TType));
        }

        public static PropertyDeclarationSyntax WithType(this PropertyDeclarationSyntax @this,
            System.Type @type, Boolean @withFullName = true)
        {
            return @this.WithType(@withFullName
                ? @type.GetFullName()
                : @type.GetName());
        }

        public static PropertyDeclarationSyntax WithType(this PropertyDeclarationSyntax @this,
            String @typeName)
        {
            return @this.WithType(
                SyntaxFactory.ParseTypeName(@typeName));
        }

        # endregion Type

        # region • Identifier •

        public static PropertyDeclarationSyntax WithIdentifier(this PropertyDeclarationSyntax @this,
            String @identifier)
        {
            return @this.WithIdentifier(
                SyntaxFactory.Identifier(@identifier));
        }

        # endregion Identifier

        # region • Accessors •

        public static PropertyDeclarationSyntax WithAutoAccessors(this PropertyDeclarationSyntax @this)
        {
            return @this.WithGetter().WithSetter();
        }

        public static IEnumerable<AccessorDeclarationSyntax> GetAccessors(
            this PropertyDeclarationSyntax @this)
        {
            return @this.AccessorList.Accessors;
        }

        # endregion Accessors

        # region • Getter •

        public static PropertyDeclarationSyntax WithGetter(this PropertyDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            @this = @this.WithGetter();

            var getter = @this.AccessorList.Accessors.Single(
                x => x.Kind() == SyntaxKind.GetAccessorDeclaration);

            return @this.WithGetter(
                getter.WithModifiers(@modifier));
        }

        public static PropertyDeclarationSyntax WithGetter(this PropertyDeclarationSyntax @this,
            params String[] @statements)
        {
            var getter = @this.AccessorList?.Accessors.SingleOrDefault(
                x => x.Kind() == SyntaxKind.GetAccessorDeclaration);

            if (getter == default(AccessorDeclarationSyntax))
            {
                getter = SyntaxFactory.AccessorDeclaration(
                    SyntaxKind.GetAccessorDeclaration);
            }

            return @this.WithGetter(getter, @statements);
        }

        public static PropertyDeclarationSyntax WithGetter(this PropertyDeclarationSyntax @this,
            AccessorDeclarationSyntax @getter, params String[] @statements)
        {
            if (@getter.Kind() != SyntaxKind.GetAccessorDeclaration)
            {
                throw new Exception($"Given parameter:'{@getter.Kind()}' is not a getter");
            }

            @getter = @getter.IsAuto();

            var setter = @this.AccessorList?.Accessors.SingleOrDefault(
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

        public static PropertyDeclarationSyntax WithSetter(this PropertyDeclarationSyntax @this,
            MODIFIER @modifier)
        {
            @this = @this.WithSetter();

            var setter = @this.AccessorList?.Accessors.Single(
                x => x.Kind() == SyntaxKind.SetAccessorDeclaration);

            return @this.WithSetter(
                setter.WithModifiers(@modifier));
        }

        public static PropertyDeclarationSyntax WithSetter(this PropertyDeclarationSyntax @this,
            params String[] @statements)
        {
            var setter = @this.AccessorList?.Accessors.SingleOrDefault(
                x => x.Kind() == SyntaxKind.SetAccessorDeclaration);

            if (setter == default(AccessorDeclarationSyntax))
            {
                setter = SyntaxFactory.AccessorDeclaration(
                    SyntaxKind.SetAccessorDeclaration);
            }

            return @this.WithSetter(setter, @statements);
        }

        public static PropertyDeclarationSyntax WithSetter(this PropertyDeclarationSyntax @this,
            AccessorDeclarationSyntax @setter, params String[] @statements)
        {
            if (@setter.Kind() != SyntaxKind.SetAccessorDeclaration)
            {
                throw new Exception($"Given parameter:'{@setter.Kind()}' is not a setter");
            }

            @setter = @setter.IsAuto();

            var getter = @this.AccessorList?.Accessors.SingleOrDefault(
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

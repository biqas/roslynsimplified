using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    /// <summary>
    /// Extension methods for attribute decleration nodes.
    /// </summary>
    public static class ExtensionAttributeDecleration
    {
        public static AttributeListSyntax WithTarget(this AttributeListSyntax @this,
            AttributeTargets @targets)
        {
            var list = new List<String>();

            if (@targets.HasFlag(AttributeTargets.Assembly) || @targets.HasFlag(AttributeTargets.All))
                list.Add(AttributeTargets.Assembly.ToString());

            if (@targets.HasFlag(AttributeTargets.Module) || @targets.HasFlag(AttributeTargets.All))
                list.Add(AttributeTargets.Module.ToString());

            if (@targets.HasFlag(AttributeTargets.Class) || @targets.HasFlag(AttributeTargets.All))
                list.Add(AttributeTargets.Class.ToString());

            if (@targets.HasFlag(AttributeTargets.Struct) || @targets.HasFlag(AttributeTargets.All))
                list.Add(AttributeTargets.Struct.ToString());

            if (@targets.HasFlag(AttributeTargets.Enum) || @targets.HasFlag(AttributeTargets.All))
                list.Add(AttributeTargets.Enum.ToString());

            if (@targets.HasFlag(AttributeTargets.Constructor) || @targets.HasFlag(AttributeTargets.All))
                list.Add(AttributeTargets.Constructor.ToString());

            if (@targets.HasFlag(AttributeTargets.Method) || @targets.HasFlag(AttributeTargets.All))
                list.Add(AttributeTargets.Method.ToString());

            if (@targets.HasFlag(AttributeTargets.Property) || @targets.HasFlag(AttributeTargets.All))
                list.Add(AttributeTargets.Property.ToString());

            if (@targets.HasFlag(AttributeTargets.Field) || @targets.HasFlag(AttributeTargets.All))
                list.Add(AttributeTargets.Field.ToString());

            if (@targets.HasFlag(AttributeTargets.Event) || @targets.HasFlag(AttributeTargets.All))
                list.Add(AttributeTargets.Event.ToString());

            if (@targets.HasFlag(AttributeTargets.Interface) || @targets.HasFlag(AttributeTargets.All))
                list.Add(AttributeTargets.Interface.ToString());

            if (@targets.HasFlag(AttributeTargets.Parameter) || @targets.HasFlag(AttributeTargets.All))
                list.Add(AttributeTargets.Parameter.ToString());

            if (@targets.HasFlag(AttributeTargets.Delegate) || @targets.HasFlag(AttributeTargets.All))
                list.Add(AttributeTargets.Delegate.ToString());

            if (@targets.HasFlag(AttributeTargets.ReturnValue) || @targets.HasFlag(AttributeTargets.All))
                list.Add(AttributeTargets.ReturnValue.ToString());

            if (@targets.HasFlag(AttributeTargets.GenericParameter) || @targets.HasFlag(AttributeTargets.All))
                list.Add(AttributeTargets.GenericParameter.ToString());

            foreach (var target in list)
            {
                @this = @this.WithTarget(
                    SyntaxFactory.AttributeTargetSpecifier(
                        SyntaxFactory.ParseToken(target)));
            }

            return @this;
        }

        public static AttributeListSyntax WithAttributes(this AttributeListSyntax @this,
            params AttributeSyntax[] @attributes)
        {
            return @this.WithAttributes(
                SyntaxFactory.SeparatedList(@attributes,
                    Enumerable.Repeat(
                        SyntaxFactory.Token(SyntaxKind.CommaToken), @attributes.Count() - 1)));
        }

        public static AttributeListSyntax AddAttribute(this AttributeListSyntax @this,
            AttributeSyntax @attribute)
        {
            return @this.WithAttributes(
                @this.Attributes.Add(attribute).ToArray());
        }

        public static AttributeListSyntax AddAttribute(this AttributeListSyntax @this,
            String @name)
        {
            return @this.AddAttribute(
                Attribute.Factory(@name));
        }

        public static AttributeListSyntax AddAttribute(this AttributeListSyntax @this,
            String @name, String @expression)
        {
            return @this.AddAttribute(
                Attribute.Factory(@name)
                    .WithArgument(@expression));
        }

        public static AttributeListSyntax AddAttribute(this AttributeListSyntax @this,
            String @name, String @argumentName, String @expression)
        {
            return @this.AddAttribute(
                Attribute.Factory(@name)
                    .WithArgument(@argumentName, @expression));
        }
    }
}
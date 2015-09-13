using System;
using System.Collections.Generic;
using System.Linq;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class Parameter : Parameter<Parameter>
    {
        # region • Ctor's •

        public Parameter(System.Type @type,
            String @identifier, Boolean @withFullName = true)
            : base(@type, @identifier, @withFullName) {}

        public Parameter(String @typeName, String @identifier)
            : base(@typeName, @identifier) {}

        internal Parameter(ParameterSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        protected override Parameter New(ParameterSyntax @syntaxNode)
        {
            return new Parameter(@syntaxNode);
        }

        # endregion Methods
    }

    public sealed class InParameter : Parameter<InParameter>
    {
        # region • Ctor's •

        public InParameter(System.Type @type,
            String @identifier, Boolean @withFullName = true)
            : base(@type, @identifier, @withFullName)
        {
            this.Init(this.Syntax.AsIn());
        }

        public InParameter(String @typeName, String @identifier)
            : base(@typeName, @identifier)
        {
            this.Init(this.Syntax.AsIn());
        }

        internal InParameter(ParameterSyntax @syntaxNode)
            : base(@syntaxNode)
        {
            this.Init(this.Syntax.AsIn());
        }

        # endregion Ctor's

        # region • Methods •

        protected override InParameter New(ParameterSyntax @syntaxNode)
        {
            return new InParameter(@syntaxNode);
        }

        # endregion Methods
    }

    public sealed class OutParameter : Parameter<OutParameter>
    {
        # region • Ctor's •

        public OutParameter(System.Type @type,
            String @identifier, Boolean @withFullName = true)
            : base(@type, @identifier, @withFullName)
        {
            this.Init(this.Syntax.AsOut());
        }

        public OutParameter(String @typeName, String @identifier)
            : base(@typeName, @identifier)
        {
            this.Init(this.Syntax.AsOut());
        }

        internal OutParameter(ParameterSyntax @syntaxNode)
            : base(@syntaxNode)
        {
            this.Init(this.Syntax.AsOut());
        }

        # endregion Ctor's

        # region • Methods •

        protected override OutParameter New(ParameterSyntax @syntaxNode)
        {
            return new OutParameter(@syntaxNode);
        }

        # endregion Methods
    }

    public sealed class RefParameter : Parameter<RefParameter>
    {
        # region • Ctor's •

        public RefParameter(System.Type @type,
            String @identifier, Boolean @withFullName = true)
            : base(@type, @identifier, @withFullName)
        {
            this.Init(this.Syntax.AsRef());
        }

        public RefParameter(String @typeName, String @identifier)
            : base(@typeName, @identifier)
        {
            this.Init(this.Syntax.AsRef());
        }

        internal RefParameter(ParameterSyntax @syntaxNode)
            : base(@syntaxNode)
        {
            this.Init(this.Syntax.AsRef());
        }

        # endregion Ctor's

        # region • Methods •

        protected override RefParameter New(ParameterSyntax @syntaxNode)
        {
            return new RefParameter(@syntaxNode);
        }

        # endregion Methods
    }

    public sealed class ParamsParameter : Parameter<ParamsParameter>
    {
        # region • Ctor's •

        public ParamsParameter(System.Type @type,
            String @identifier, Boolean @withFullName = true)
            : base(@type, @identifier, @withFullName)
        {
            this.Init(this.Syntax.AsParams());
        }

        public ParamsParameter(String @typeName, String @identifier)
            : base(@typeName, @identifier)
        {
            this.Init(this.Syntax.AsParams());
        }

        internal ParamsParameter(ParameterSyntax @syntaxNode)
            : base(@syntaxNode)
        {
            this.Init(this.Syntax.AsParams());
        }

        # endregion Ctor's

        # region • Methods •

        protected override ParamsParameter New(ParameterSyntax @syntaxNode)
        {
            return new ParamsParameter(@syntaxNode);
        }

        # endregion Methods
    }

    public abstract class Parameter<TSelf> : CSharpSyntaxNode<TSelf, ParameterSyntax>
        where TSelf : Parameter<TSelf>
    {
        # region • Ctor's •

        protected Parameter(System.Type @type,
            String @identifier, Boolean @withFullName = true)
        {
            this.Init(Factory(@type, @identifier, @withFullName));
        }

        protected Parameter(String @typeName, String @identifier)
        {
            this.Init(Factory(@typeName, @identifier));
        }

        internal protected Parameter(ParameterSyntax @syntaxNode)
            : base(@syntaxNode) { }

        # endregion Ctor's

        # region • Methods •

        # region • Initializations •

        public virtual TSelf Init<TType>(String @identifier,
            Boolean @withFullName = true)
        {
            return this.Init(
                Factory<TType>(@identifier, @withFullName));
        }

        public virtual TSelf Init(System.Type @type,
            String @identifier, Boolean @withFullName = true)
        {
            return this.Init(
                Factory(@type, @identifier, @withFullName));
        }

        public virtual TSelf Init(String @typeName, String @identifier)
        {
            return this.Init(
                Factory(@typeName, @identifier));
        }

        # endregion Initializations

        # region • Attributes •

        public virtual TSelf AddAttribute(String @name)
        {
            return Self(this.Syntax
                .AddAttribute(@name));
        }

        public virtual TSelf AddAttribute(String @name, String @expression)
        {
            return Self(this.Syntax
                .AddAttribute(@name, @expression));
        }

        public virtual TSelf AddAttribute(String @name, String @argumentName,
            String @expression)
        {
            return Self(this.Syntax
                .AddAttribute(@name, @argumentName, @expression));
        }

        public virtual IEnumerable<Attributes> GetAttributes()
        {
            return this.Syntax.GetAttributes()
                .Select(x => new Attributes(x));
        }

        # endregion Attributes

        # region • Modifiers •

        /// <summary>
        /// Add modifiers to class decleration syntax.
        /// </summary>
        /// <param name="modifier"></param>
        /// <returns></returns>
        protected virtual TSelf AddModifiers(PARAMETER_TYPE @modifier)
        {
            return Self(this.Syntax
                .AddModifiers(@modifier));
        }

        /// <summary>
        /// Sets the modifiers to class decleration.
        /// </summary>
        /// <param name="modifier"></param>
        /// <returns></returns>
        protected virtual TSelf WithModifiers(PARAMETER_TYPE @modifier)
        {
            return Self(this.Syntax
                .WithModifiers(@modifier));
        }

        protected virtual TSelf AsIn()
        {
            return this.WithModifiers(PARAMETER_TYPE.IN);
        }

        protected virtual TSelf AsOut()
        {
            return this.WithModifiers(PARAMETER_TYPE.OUT);
        }

        protected virtual TSelf AsRef()
        {
            return this.WithModifiers(PARAMETER_TYPE.REF);
        }

        protected virtual TSelf AsParams()
        {
            return this.WithModifiers(PARAMETER_TYPE.PARAMS);
        }

        # endregion Modifiers

        # region • Type •

        protected virtual TSelf WithType<TType>(Boolean @withfullName = true)
        {
            return Self(this.Syntax
                .WithType(typeof(TType), @withfullName));
        }

        protected virtual TSelf WithType(System.Type @type, Boolean @withfullName = true)
        {
            return Self(this.Syntax
                .WithType(@type, @withfullName));
        }

        protected virtual TSelf WithType(String @typeName)
        {
            return Self(this.Syntax
                .WithType(@typeName));
        }

        # endregion Type

        # region • Identifier •

        protected virtual TSelf WithIdentifier(String @identifier)
        {
            return Self(this.Syntax
                .WithIdentifier(@identifier));
        }

        # endregion Identifier

        # region • Factories •

        public static ParameterSyntax Factory<TType>(String @identifier,
            Boolean @withFullName = true)
        {
            return SyntaxFactory.Parameter(
                SyntaxFactory.Identifier(@identifier))
                .WithType<TType>(@withFullName);
        }

        public static ParameterSyntax Factory(System.Type @type,
            String @identifier, Boolean @withFullName = true)
        {
            return SyntaxFactory.Parameter(
                SyntaxFactory.Identifier(@identifier))
                .WithType(@type, @withFullName);
        }

        public static ParameterSyntax Factory(String @typeName,
            String @identifier)
        {
            return SyntaxFactory.Parameter(
                SyntaxFactory.Identifier(@identifier))
                .WithType(@typeName);
        }

        # endregion Factories

        # endregion Methods
    }
}

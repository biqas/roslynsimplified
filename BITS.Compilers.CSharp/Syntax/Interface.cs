using System;
using System.Collections.Generic;
using System.Linq;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class Interface : Interface<Interface>
    {
        # region • Ctor's •

        public Interface(String @identifier)
            : base(@identifier) {}

        internal Interface(InterfaceDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        protected override Interface New(InterfaceDeclarationSyntax @syntaxNode)
        {
            return new Interface(@syntaxNode);
        }

        # endregion Methods
    }

    public abstract partial class Interface<TSelf> : Type<TSelf, InterfaceDeclarationSyntax>
        where TSelf : Interface<TSelf>
    {
        # region • Ctor's •

        protected Interface(String @identifier)
        {
            this.Init(Factory(@identifier));
        }

        internal protected Interface(InterfaceDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) { }

        # endregion Ctor's

        # region • Methods •

        # region • Initializations •

        public virtual TSelf Init(String @identifier)
        {
            return this.Init(Factory(@identifier));
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
        public virtual TSelf AddModifiers(MODIFIER @modifier)
        {
            return Self(this.Syntax
                .AddModifiers(@modifier));
        }

        /// <summary>
        /// Sets the modifiers to class decleration.
        /// </summary>
        /// <param name="modifier"></param>
        /// <returns></returns>
        public virtual TSelf WithModifiers(MODIFIER @modifier)
        {
            return Self(this.Syntax
                .WithModifiers(@modifier));
        }

        # endregion Modifiers

        # region • Identifier •

        public virtual TSelf WithIdentifier(String @identifier)
        {
            return Self(this.Syntax
                .WithIdentifier(@identifier));
        }

        # endregion Identifier

        # region • TypeParameters •

        public override TSelf AddTypeParameter<TType>(Boolean @withFullName = false)
        {
            return Self(this.Syntax
                .AddTypeParameter<TType>(@withFullName));
        }

        public override TSelf AddTypeParameter(String @typeIdentifier)
        {
            return Self(this.Syntax
                .AddTypeParameter(@typeIdentifier));
        }

        public override TSelf AddTypeParameter(BaseTypeDeclarationSyntax @classType)
        {
            return Self(this.Syntax
                .AddTypeParameter(@classType));
        }

        public override TSelf AddTypeParameter<T>(BaseType<T, BaseTypeDeclarationSyntax> @baseType)
        {
            return Self(this.Syntax
                .AddTypeParameter(@baseType.Syntax));
        }

        # endregion TypeParameters

        # region • ConstraintClauses •

        public override TSelf AddNewConstraint(String @typeParameter)
        {
            return Self(this.Syntax
                .AddNewConstraint(@typeParameter));
        }

        public override TSelf AddClassConstraint(String @typeParameter)
        {
            return Self(this.Syntax
                .AddClassConstraint(@typeParameter));
        }

        public override TSelf AddStructConstraint(String @typeParameter)
        {
            return Self(this.Syntax
                .AddStructConstraint(@typeParameter));
        }

        public override TSelf AddTypeConstraint(String @typeParameter, String @typeName)
        {
            return Self(this.Syntax
                .AddTypeConstraint(@typeParameter, @typeName));
        }

        public override TSelf AddTypeConstraint<T>(String @typeParameter,
            BaseType<T, BaseTypeDeclarationSyntax> @baseType)
        {
            return Self(this.Syntax
                .AddTypeConstraint(
                    @typeParameter,
                    @baseType.Syntax.GetTypeSyntax()));
        }

        # endregion ConstraintClauses

        # region • BaseList •

        public virtual TSelf WithInterface(String @interfaceTypeName, params Object[] @params)
        {
            if (@params != null)
                @interfaceTypeName = String.Format(@interfaceTypeName, @params);

            return Self(this.Syntax
                .WithInterface(@interfaceTypeName));
        }

        public virtual TSelf WithInterface(BaseTypeSyntax @interfaceTypeSyntax)
        {
            return Self(this.Syntax
                .WithInterface(@interfaceTypeSyntax));
        }

        public virtual TSelf WithInterface<T>(Interface<T> @class)
            where T : Interface<T>
        {
            return Self(this.Syntax
                .WithInterface(@class.Syntax.GetSimpleBaseType()));
        }

        # endregion BaseList

        # region • Members •

        public virtual TSelf AddMembers(IEnumerable<Member> @members)
        {
            return this.AddMembers(@members.ToArray());
        }

        public virtual TSelf AddMembers(params Member[] @members)
        {
            return this.AddMembers(@members
                    .Select(x => x.Syntax)
                    .ToArray());
        }

        public virtual TSelf AddMembers(params MemberDeclarationSyntax[] @membersDeclarationSyntax)
        {
            return Self(this.Syntax
                .AddMembers(@membersDeclarationSyntax));
        }

        public virtual IEnumerable<Member> GetMembers()
        {
            return this.Syntax.GetMembers()
                .Select(x => new Member(x));
        }

        # region • Events •

        public virtual TSelf AddEvents(
            params EventDeclarationSyntax[] @eventsSyntax)
        {
            return Self(this.Syntax
                .AddEvents(@eventsSyntax));
        }

        public virtual IEnumerable<Event> GetEvents()
        {
            return this.Syntax.GetEvents()
                .Select(x => new Event(x));
        }

        # endregion Events

        # region • Indexers •

        public virtual TSelf AddIndexers(
            params IndexerDeclarationSyntax[] @indexersSyntax)
        {
            return Self(this.Syntax
                .AddIndexers(@indexersSyntax));
        }

        public virtual IEnumerable<Indexer> GetIndexers()
        {
            return this.Syntax.GetIndexers()
                .Select(x => new Indexer(x));
        }

        # endregion Indexers

        # region • Properties •

        public virtual TSelf AddProperties(
            params PropertyDeclarationSyntax[] @propertiesSyntax)
        {
            return Self(this.Syntax
                .AddProperties(@propertiesSyntax));
        }

        public virtual IEnumerable<Property> GetProperties()
        {
            return this.Syntax.GetProperties()
                .Select(x => new Property(x));
        }

        # endregion Properties

        # region • Methods •

        public virtual TSelf AddMethods(
            params MethodDeclarationSyntax[] @methodsSyntax)
        {
            return Self(this.Syntax
                .AddMethods(@methodsSyntax));
        }

        public virtual IEnumerable<Method> GetMethods()
        {
            return this.Syntax.GetMethods()
                .Select(x => new Method(x));
        }

        # endregion Methods

        # endregion Members

        # region • Helpers •

        public virtual Boolean IsPartial()
        {
            return this.Syntax
                .IsPartial();
        }

        public virtual Boolean HasBase()
        {
            return this.Syntax
                .HasBase();
        }

        # endregion Helpers

        # region • Factories •

        private static InterfaceDeclarationSyntax Factory(String @identifier)
        {
            return SyntaxFactory.InterfaceDeclaration(@identifier);
        }

        # endregion Factories

        # endregion Methods
    }
}
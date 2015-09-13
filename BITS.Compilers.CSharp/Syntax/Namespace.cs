using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class Namespace : Namespace<Namespace>
    {
        # region • Ctor's •

        public Namespace(String @identifier)
            : base(@identifier) {}

        internal Namespace(NamespaceDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        protected override Namespace New(NamespaceDeclarationSyntax @syntaxNode)
        {
            return new Namespace(@syntaxNode);
        }

        # endregion Methods
    }

    public abstract class Namespace<TSelf>
        : Member<TSelf, NamespaceDeclarationSyntax>
        , IEnumerable<Class>
        where TSelf : Namespace<TSelf>
    {
        # region • Ctor's •

        protected Namespace(String @identifier)
        {
            this.Init(Factory(@identifier));
        }

        internal protected Namespace(NamespaceDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) { }

        # endregion Ctor's

        # region • Methods •

        # region • Initializations •

        public virtual TSelf Init(String @identifier)
        {
            return this.Init(
                Factory(@identifier));
        }

        # endregion Initializations

        # region • Name •

        public virtual TSelf WithName(String @identifier)
        {
            return Self(this.Syntax
                .WithName(@identifier));
        }

        # endregion Name

        # region • Usings •

        public virtual TSelf AddUsings(IEnumerable<Using> @usings)
        {
            return this.AddUsings(@usings.ToArray());
        }

        public virtual TSelf AddUsings(params Using[] @usings)
        {
            return this.AddUsings(@usings
                .Select(x => x.Syntax)
                .ToArray());
        }

        public virtual TSelf AddUsings(params UsingDirectiveSyntax[] @usingsSyntax)
        {
            return Self(this.Syntax
                .AddUsings(@usingsSyntax));
        }

        public virtual TSelf WithUsings(params UsingDirectiveSyntax[] @usings)
        {
            return Self(this.Syntax
                .WithUsings(@usings));
        }

        public virtual TSelf WithUsings(params String[] @namespaces)
        {
            return Self(this.Syntax
                .WithUsings(@namespaces));
        }

        public virtual IEnumerable<Using> GetUsings()
        {
            return this.Syntax.GetUsings()
                .Select(x => new Using(x));
        }

        # endregion Usings

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

        # region • Namespaces •

        public virtual TSelf AddNamespaces(IEnumerable<Namespace> @namespaces)
        {
            return this.AddNamespaces(@namespaces.ToArray());
        }

        public virtual TSelf AddNamespaces(params Namespace[] @namespaces)
        {
            return this.AddNamespaces(@namespaces
                .Select(x => x.Syntax)
                .ToArray());
        }

        public virtual TSelf AddNamespaces(params NamespaceDeclarationSyntax[] @namespacesSyntax)
        {
            return Self(this.Syntax
                .AddNamespaces(@namespacesSyntax));
        }

        public virtual TSelf WithNamespaces(params NamespaceDeclarationSyntax[] @namespacesSyntax)
        {
            return Self(this.Syntax
                .WithNamespaces(@namespacesSyntax));
        }

        public virtual IEnumerable<Namespace> GetNamespaces()
        {
            return this.Syntax.GetNamespaces()
                .Select(x => new Namespace(x));
        }

        # endregion Namespaces

        # region • Delegates •

        public virtual TSelf AddDelegates(
            params DelegateDeclarationSyntax[] @delegatesSyntax)
        {
            return Self(this.Syntax
                .AddDelegates(@delegatesSyntax));
        }

        public virtual IEnumerable<Delegate> GetDelegates()
        {
            return this.Syntax.GetDelegates()
                .Select(x => new Delegate(x));
        }

        # endregion Delegates

        # region • Interfaces •

        public virtual TSelf AddInterfaces(
            params InterfaceDeclarationSyntax[] @interfacesSyntax)
        {
            return Self(this.Syntax
                .AddInterfaces(@interfacesSyntax));
        }

        public virtual IEnumerable<Interface> GetInterfaces()
        {
            return this.Syntax.GetInterfaces()
                .Select(x => new Interface(x));
        }

        # endregion Interfaces

        # region • Classes •

        public virtual TSelf Add(Class @class)
        {
            return this.AddClasses(@class.Syntax);
        }

        public virtual TSelf AddClasses(
            params ClassDeclarationSyntax[] @clssesSyntax)
        {
            return Self(this.Syntax
                .AddClasses(@clssesSyntax));
        }

        public virtual IEnumerable<Class> GetClasses()
        {
            return this.Syntax.GetClasses()
                .Select(x => new Class(x));
        }

        # endregion Classes

        # region • Structs •

        public virtual TSelf AddStructs(
            params StructDeclarationSyntax[] @structsSyntax)
        {
            return Self(this.Syntax
                .AddStructs(@structsSyntax));
        }

        public virtual IEnumerable<Struct> GetStructs()
        {
            return this.Syntax.GetStructs()
                .Select(x => new Struct(x));
        }

        # endregion Structs

        # region • Enums •

        public virtual TSelf AddEnums(
            params EnumDeclarationSyntax[] @enumsSyntax)
        {
            return Self(this.Syntax
                .AddEnums(@enumsSyntax));
        }

        public virtual IEnumerable<Enum> GetEnums()
        {
            return this.Syntax.GetEnums()
                .Select(x => new Enum(x));
        }

        # endregion Enums

        # endregion Members

        # region • Helper •

        public virtual String GetName()
        {
            return this.Syntax.GetName();
        }

        public virtual String GetFullName()
        {
            return this.Syntax.GetFullName();
        }

        public override TSelf GetPartial()
        {
            return this.New(Factory(this.GetName()))
                .AddMembers(this.GetMembers()
                    .Where(x => x.GetPartial() != null)
                    .Select(x => x.GetPartial()));
        }

        public override IEnumerable<TSelf> AsPartial()
        {
            yield return (TSelf)this;
            yield return this.GetPartial();
        }

        # endregion Helper

        public TSelf Add(TSelf @namespace)
        {
            return @namespace == null
                ? Self(this.Syntax)
                : this.Add(@namespace.Syntax);
        }

        public TSelf Add(NamespaceDeclarationSyntax @namespace)
        {
            if (@namespace == null)
                return Self(this.Syntax);

            return Self(this.Syntax.WithMembers(@namespace));
        }

        # region • Methods - IEnumerable •

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var @using in this.Syntax.Usings)
                yield return @using;

            foreach (var memeber in this.Syntax.Members)
                yield return memeber;
        }

        IEnumerator<Class> IEnumerable<Class>.GetEnumerator()
        {
            return this.GetClasses().GetEnumerator();
        }

        # endregion Methods - IEnumerable

        # region • Factories •

        public static NamespaceDeclarationSyntax Factory(String @identifier)
        {
            return SyntaxFactory.NamespaceDeclaration(
                SyntaxFactory.IdentifierName(@identifier));
        }

        # endregion Factories

        # endregion Methods
    }
}

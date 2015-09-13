using System;
using System.Collections.Generic;
using System.Linq;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

// Generall Documentation
//-----------------------
// All With... methods reset the previous state and set it to default and then set to given value(s).



namespace BITS.Compilers.CSharp.Syntax
{
    public sealed class Struct : Struct<Struct>
    {
        # region • Ctor's •

        public Struct(String @identifier)
            : base(@identifier) {}

        internal Struct(StructDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        protected override Struct New(StructDeclarationSyntax @syntaxNode)
        {
            return new Struct(@syntaxNode);
        }

        # endregion Methods
    }

    public abstract class Struct<TSelf> : Type<TSelf, StructDeclarationSyntax>
        where TSelf : Struct<TSelf>
    {
        # region • Ctor's •

        protected Struct(String @identifier)
        {
            this.Init(Factory(@identifier));
        }

        internal protected Struct(StructDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

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

        public virtual IEnumerable<Member> GetMembers()
        {
            return this.Syntax.GetMembers()
                .Select(x => new Member(x));
        }

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

        # region • Operators •

        public virtual TSelf AddOperators(
            params OperatorDeclarationSyntax[] @operatorsSyntax)
        {
            return Self(this.Syntax
                .AddOperators(@operatorsSyntax));
        }

        public virtual TSelf AddConversionOperators(
            params ConversionOperatorDeclarationSyntax[] @conversionOperatorsSyntax)
        {
            return Self(this.Syntax
                .AddConversionOperators(@conversionOperatorsSyntax));
        }

        public virtual IEnumerable<Operator> GetOperators()
        {
            return this.Syntax.GetOperators()
                .Select(x => new Operator(x));
        }

        public virtual IEnumerable<ConversionOperator> GetConversionOperators()
        {
            return this.Syntax.GetConversionOperators()
                .Select(x => new ConversionOperator(x));
        }

        # endregion Operators

        # region • Fields •

        public virtual TSelf AddFields(
            params FieldDeclarationSyntax[] @fieldsSyntax)
        {
            return Self(this.Syntax
                .AddFields(@fieldsSyntax));
        }

        public virtual IEnumerable<Field> GetFields()
        {
            return this.Syntax.GetFields()
                .Select(x => new Field(x));
        }

        # endregion Fields

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

        # region • Constructors •

        public virtual TSelf AddConstructors(
            params ConstructorDeclarationSyntax[] @constructorsSyntax)
        {
            return Self(this.Syntax
                .AddConstructors(@constructorsSyntax));
        }

        public virtual IEnumerable<Constructor> GetConstructors()
        {
            return this.Syntax.GetConstructors()
                .Select(x => new Constructor(x));
        }

        # endregion Constructors

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

        # region • Inner Interfaces •

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

        # endregion Inner Interfaces

        # region • Inner Classes •

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

        # endregion Inner Classes

        # region • Inner Structs •

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

        # endregion Inner Structs

        # region • Inner Enums •

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

        # endregion Inner Enums

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

        private static StructDeclarationSyntax Factory(String @identifier)
        {
            return SyntaxFactory.StructDeclaration(@identifier);
        }

        # endregion Factories

        # endregion Methods
    }
}

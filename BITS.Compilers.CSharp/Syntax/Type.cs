using System;
using BITS.Compilers.CSharp.Syntax.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax
{
    public abstract class Type : Type<Type>
    {
        # region • Ctor's •

        internal protected Type() {}

        internal protected Type(TypeDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's
    }

    public abstract class Type<TSelf> : Type<TSelf, TypeDeclarationSyntax>
        where TSelf : Type<TSelf>
    {
        # region • Ctor's •

        internal protected Type() {}

        internal protected Type(TypeDeclarationSyntax @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's
    }

    public abstract class Type<TSelf, TSyntaxNode> : BaseType<TSelf, TSyntaxNode>
        where TSelf : Type<TSelf, TSyntaxNode>
        where TSyntaxNode : TypeDeclarationSyntax
    {
        # region • Ctor's •

        internal protected Type() {}

        internal protected Type(TSyntaxNode @syntaxNode)
            : base(@syntaxNode) {}

        # endregion Ctor's

        # region • Methods •

        # region • Generic •

        public GenericNameSyntax GetGenericName()
        {
            return this.Syntax.GetGenericName();
        }

        # endregion Generic

        # region • Type •

        public TypeSyntax GetTypeSyntax()
        {
            return this.Syntax.GetTypeSyntax();
        }

        # endregion Type

        # region • TypeParameters •

        public abstract TSelf AddTypeParameter<TType>(Boolean @withFullName = false);

        public abstract TSelf AddTypeParameter(String @typeIdentifier);

        public abstract TSelf AddTypeParameter(BaseTypeDeclarationSyntax @classType);

        public abstract TSelf AddTypeParameter<T>(BaseType<T, BaseTypeDeclarationSyntax> @baseType)
            where T : BaseType<T, BaseTypeDeclarationSyntax>;

        # endregion TypeParameters

        # region • ConstraintClauses •

        public abstract TSelf AddNewConstraint(String @typeParameter);

        public abstract TSelf AddClassConstraint(String @typeParameter);

        public abstract TSelf AddStructConstraint(String @typeParameter);

        public abstract TSelf AddTypeConstraint(String @typeParameter, String @typeName);

        public abstract TSelf AddTypeConstraint<T>(String @typeParameter,
            BaseType<T, BaseTypeDeclarationSyntax> @baseType)
            where T : BaseType<T, BaseTypeDeclarationSyntax>;

        # endregion ConstraintClauses

        # endregion Methods
    }
}
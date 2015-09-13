using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionTypeDeclarationSyntax
    {
        public static GenericNameSyntax GetGenericName(this TypeDeclarationSyntax @this)
        {
            return SyntaxFactory.GenericName(@this.Identifier)
                .WithTypeArgumentList(SyntaxFactory.TypeArgumentList(
                    SyntaxFactory.SeparatedList(
                        @this.TypeParameterList.Parameters.Select(x => SyntaxFactory.ParseTypeName(x.Identifier.ToString())),
                        Enumerable.Repeat(SyntaxFactory.Token(SyntaxKind.CommaToken), @this.TypeParameterList.Parameters.Count() - 1))));
        }

        public static TypeSyntax GetTypeSyntax(this TypeDeclarationSyntax @this)
        {
            return @this.TypeParameterList == null
                ? SyntaxFactory.ParseTypeName(@this.ToFullString())
                : @this.GetGenericName();
        }

        public static BaseTypeSyntax GetSimpleBaseType(this TypeDeclarationSyntax @this)
        {
            return SyntaxFactory.SimpleBaseType(
                @this.GetTypeSyntax());
        }
    }
}

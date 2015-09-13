using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static partial class ExtensionSyntaxTokenList
    {
        /// <summary>
        /// Gets the modifers.
        /// </summary>
        /// <param name="this">The modifiers.</param>
        /// <returns></returns>
        public static MODIFIER GetModifer(this SyntaxTokenList @this)
        {
            var modifier = MODIFIER.NONE;

            foreach (var syntaxToken in @this)
            {
                if (syntaxToken.Kind() == SyntaxKind.PrivateKeyword)
                    modifier |= MODIFIER.PRIVATE;

                if (syntaxToken.Kind() == SyntaxKind.ProtectedKeyword)
                    modifier |= MODIFIER.PROTECTED;

                if (syntaxToken.Kind() == SyntaxKind.InternalKeyword)
                    modifier |= MODIFIER.INTERNAL;

                if (syntaxToken.Kind() == SyntaxKind.PublicKeyword)
                    modifier |= MODIFIER.PUBLIC;

                if (syntaxToken.Kind() == SyntaxKind.PartialKeyword)
                    modifier |= MODIFIER.PARTIAL;

                if (syntaxToken.Kind() == SyntaxKind.SealedKeyword)
                    modifier |= MODIFIER.SEALED;

                if (syntaxToken.Kind() == SyntaxKind.VirtualKeyword)
                    modifier |= MODIFIER.VIRTUAL;

                if (syntaxToken.Kind() == SyntaxKind.AbstractKeyword)
                    modifier |= MODIFIER.ABSTRACT;

                if (syntaxToken.Kind() == SyntaxKind.StaticKeyword)
                    modifier |= MODIFIER.STATIC;

                if (syntaxToken.Kind() == SyntaxKind.ReadOnlyKeyword)
                    modifier |= MODIFIER.READ_ONLY;

                if (syntaxToken.Kind() == SyntaxKind.ConstKeyword)
                    modifier |= MODIFIER.CONST;

                if (syntaxToken.Kind() == SyntaxKind.FixedKeyword)
                    modifier |= MODIFIER.FIXED;

                if (syntaxToken.Kind() == SyntaxKind.ParamsKeyword)
                    modifier |= MODIFIER.PARAMS;

                if (syntaxToken.Kind() == SyntaxKind.VolatileKeyword)
                    modifier |= MODIFIER.VOLATILE;

                if (syntaxToken.Kind() == SyntaxKind.InKeyword)
                    modifier |= MODIFIER.IN;

                if (syntaxToken.Kind() == SyntaxKind.OutKeyword)
                    modifier |= MODIFIER.OUT;

                if (syntaxToken.Kind() == SyntaxKind.RefKeyword)
                    modifier |= MODIFIER.REF;

                if (syntaxToken.Kind() == SyntaxKind.ExternKeyword)
                    modifier |= MODIFIER.EXTERN;

                if (syntaxToken.Kind() == SyntaxKind.OverrideKeyword)
                    modifier |= MODIFIER.OVERRIDE;

                if (syntaxToken.Kind() == SyntaxKind.NewKeyword)
                    modifier |= MODIFIER.NEW;
            }

            return modifier;
        }
    }
}

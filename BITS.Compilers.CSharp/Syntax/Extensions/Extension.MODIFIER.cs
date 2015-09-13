using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static class ExtensionModifier
    {
        /// <summary>
        /// Gets the modifers.
        /// </summary>
        /// <param name="this">The modifier.</param>
        /// <returns></returns>
        public static IEnumerable<SyntaxToken> GetSyntaxTokens(this MODIFIER @this)
        {
            if (@this.HasFlag(MODIFIER.PRIVATE))
                yield return SyntaxFactory.Token(SyntaxKind.PrivateKeyword);

            if (@this.HasFlag(MODIFIER.PROTECTED))
                yield return SyntaxFactory.Token(SyntaxKind.ProtectedKeyword);

            if (@this.HasFlag(MODIFIER.INTERNAL))
                yield return SyntaxFactory.Token(SyntaxKind.InternalKeyword);

            if (@this.HasFlag(MODIFIER.PUBLIC))
                yield return SyntaxFactory.Token(SyntaxKind.PublicKeyword);

            if (@this.HasFlag(MODIFIER.PARTIAL))
                yield return SyntaxFactory.Token(SyntaxKind.PartialKeyword);

            if (@this.HasFlag(MODIFIER.SEALED))
                yield return SyntaxFactory.Token(SyntaxKind.SealedKeyword);

            if (@this.HasFlag(MODIFIER.VIRTUAL))
                yield return SyntaxFactory.Token(SyntaxKind.VirtualKeyword);

            if (@this.HasFlag(MODIFIER.ABSTRACT))
                yield return SyntaxFactory.Token(SyntaxKind.AbstractKeyword);

            if (@this.HasFlag(MODIFIER.STATIC))
                yield return SyntaxFactory.Token(SyntaxKind.StaticKeyword);

            if (@this.HasFlag(MODIFIER.READ_ONLY))
                yield return SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword);

            if (@this.HasFlag(MODIFIER.CONST))
                yield return SyntaxFactory.Token(SyntaxKind.ConstKeyword);

            if (@this.HasFlag(MODIFIER.FIXED))
                yield return SyntaxFactory.Token(SyntaxKind.FixedKeyword);

            if (@this.HasFlag(MODIFIER.PARAMS))
                yield return SyntaxFactory.Token(SyntaxKind.ParamsKeyword);

            if (@this.HasFlag(MODIFIER.VOLATILE))
                yield return SyntaxFactory.Token(SyntaxKind.VolatileKeyword);

            if (@this.HasFlag(MODIFIER.IN))
                yield return SyntaxFactory.Token(SyntaxKind.InKeyword);

            if (@this.HasFlag(MODIFIER.OUT))
                yield return SyntaxFactory.Token(SyntaxKind.OutKeyword);

            if (@this.HasFlag(MODIFIER.REF))
                yield return SyntaxFactory.Token(SyntaxKind.RefKeyword);

            if (@this.HasFlag(MODIFIER.EXTERN))
                yield return SyntaxFactory.Token(SyntaxKind.ExternKeyword);

            if (@this.HasFlag(MODIFIER.OVERRIDE))
                yield return SyntaxFactory.Token(SyntaxKind.OverrideKeyword);

            if (@this.HasFlag(MODIFIER.NEW))
                yield return SyntaxFactory.Token(SyntaxKind.NewKeyword);
        }

        public static MODIFIER GetModifiers(this IEnumerable<SyntaxToken> @this)
        {
            var modifiers = MODIFIER.NONE;

            var syntaxTokens = @this as IList<SyntaxToken> ?? @this.ToList();

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.PrivateKeyword)))
                modifiers |= MODIFIER.PRIVATE;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword)))
                modifiers |= MODIFIER.PROTECTED;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.InternalKeyword)))
                modifiers |= MODIFIER.INTERNAL;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                modifiers |= MODIFIER.PUBLIC;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.PartialKeyword)))
                modifiers |= MODIFIER.PARTIAL;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.SealedKeyword)))
                modifiers |= MODIFIER.SEALED;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.VirtualKeyword)))
                modifiers |= MODIFIER.VIRTUAL;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.AbstractKeyword)))
                modifiers |= MODIFIER.ABSTRACT;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.StaticKeyword)))
                modifiers |= MODIFIER.STATIC;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword)))
                modifiers |= MODIFIER.READ_ONLY;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.ConstKeyword)))
                modifiers |= MODIFIER.CONST;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.FixedKeyword)))
                modifiers |= MODIFIER.FIXED;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.ParamsKeyword)))
                modifiers |= MODIFIER.PARAMS;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.VolatileKeyword)))
                modifiers |= MODIFIER.VOLATILE;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.InKeyword)))
                modifiers |= MODIFIER.IN;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.OutKeyword)))
                modifiers |= MODIFIER.OUT;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.RefKeyword)))
                modifiers |= MODIFIER.REF;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.ExternKeyword)))
                modifiers |= MODIFIER.EXTERN;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.OverrideKeyword)))
                modifiers |= MODIFIER.OVERRIDE;

            if (syntaxTokens.Contains(SyntaxFactory.Token(SyntaxKind.NewKeyword)))
                modifiers |= MODIFIER.NEW;

            return modifiers;
        }
    }
}

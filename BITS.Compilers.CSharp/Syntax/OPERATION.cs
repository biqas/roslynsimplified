using Microsoft.CodeAnalysis.CSharp;

namespace BITS.Compilers.CSharp.Syntax
{
    public enum OPERATION
    {
        NONE               = 0,

        PLUS               = SyntaxKind.PlusToken,

        MINUS              = SyntaxKind.MinusToken,

        NEGATION           = SyntaxKind.ExclamationToken,

        TILDE              = SyntaxKind.TildeToken,

        PLUS_PLUS          = SyntaxKind.PlusPlusToken,

        MINUS_MINUS        = SyntaxKind.MinusMinusToken,

        TRUE               = SyntaxKind.TrueKeyword,

        FALSE              = SyntaxKind.FalseKeyword,

        MULTIPLICATION     = SyntaxKind.AsteriskToken,

        DIVISION           = SyntaxKind.SlashToken,

        MODULO             = SyntaxKind.PercentToken,

        AND                = SyntaxKind.AmpersandToken,

        OR                 = SyntaxKind.BarToken,

        XOR                = SyntaxKind.CaretToken,

        SHIFT_LEFT         = SyntaxKind.LessThanLessThanToken,

        SHIFT_RIGHT        = SyntaxKind.GreaterThanGreaterThanToken,

        EQUALITY           = SyntaxKind.EqualsEqualsToken,

        INEQUALITY         = SyntaxKind.BarEqualsToken,

        LESS_THEN          = SyntaxKind.LessThanToken,

        GREATER_THEN       = SyntaxKind.GreaterThanToken,

        LESS_THEN_EQUAL    = SyntaxKind.LessThanEqualsToken,

        GREATER_THEN_EQUAL = SyntaxKind.GreaterThanEqualsToken,
    }
}

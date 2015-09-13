using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using BITS.Compilers.CSharp.Syntax.Extensions;

namespace BITS.Compilers.CSharp.Syntax
{
    public class Block
    {
        public static BlockSyntax Factory(params String[] @statements)
        {
            if (@statements == null || !@statements.Any())
                return SyntaxFactory.Block();

            return SyntaxFactory.Block()
                .WithStatements(@statements);
        }
    }
}

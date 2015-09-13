using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static class ExtensionBlockSyntax
    {
        public static BlockSyntax AddStatements(this BlockSyntax @this,
            IEnumerable<String> @statements)
        {
            return @this.AddStatements(@statements.ToArray());
        }

        public static BlockSyntax AddStatements(this BlockSyntax @this,
            params String[] @statements)
        {
            if (@statements == null || !@statements.Any())
                return @this;

            var syntaxList = @this.Statements;

            foreach (var statement in @statements)
            {
                syntaxList = syntaxList.Add(
                    SyntaxFactory.ParseStatement(statement));
            }

            return @this.WithStatements(syntaxList);
        }

        public static BlockSyntax AddStatements(this BlockSyntax @this,
            params Expression<Action>[] @expressions)
        {
            return @this.AddStatements(
                @expressions.Select(
                    x => x.Body.ToString()));
        }

        public static BlockSyntax AddStatements(this BlockSyntax @this,
            params Expression<Action<dynamic>>[] @expressions)
        {
            return @this.AddStatements(
                @expressions.Select(
                    x => x.Body.ToString()));
        }

        //public static BlockSyntax AddStatements<T2>(this BlockSyntax @this, T2 t2, params Expression<Action<dynamic, T2>>[] @expressions)
        //{
        //    var statement = @expression.Body.ToString();

        //    var t2Name = @expression.Parameters.Last().Name;
        //    statement = statement.Replace(t2Name, t2.ToString());

        //    return @this.AddStatements(statement);
        //}

        public static BlockSyntax AddStatements<TReturn>(this BlockSyntax @this,
            params Expression<Func<TReturn>>[] @expressions)
        {
            return @this.AddStatements(
                @expressions.Select(
                    x => x.Body.ToString()));
        }

        public static BlockSyntax AddStatements<TReturn>(this BlockSyntax @this,
            params Expression<Func<dynamic, TReturn>>[] @expressions)
        {
            return @this.AddStatements(
                @expressions.Select(
                    x => x.Body.ToString()));
        }

        //public static BlockSyntax AddStatements<T2, TReturn>(this BlockSyntax @this, T2 t2, params Expression<Func<dynamic, T2, TReturn>>[] @expressions)
        //{
        //    var statement = @expression.Body.ToString();

        //    var t2Name = @expression.Parameters.Last().Name;
        //    statement = statement.Replace(t2Name, t2.ToString());

        //    return @this.AddStatements(statement);
        //}

        public static BlockSyntax WithStatements(this BlockSyntax @this,
            params String[] @statements)
        {
            if (@statements == null || !@statements.Any())
                return @this;

            return @this
                .WithStatements(SyntaxFactory.List<StatementSyntax>())
                .AddStatements(@statements);
        }

        public static BlockSyntax WithStatements(this BlockSyntax @this,
            params StatementSyntax[] @statements)
        {
            return @this.WithStatements(
                SyntaxFactory.List(@statements));
        }

        # region • Factories •

        public static BlockSyntax Factory(
            params String[] @statements)
        {
            return SyntaxFactory.Block()
                .WithStatements(@statements);
        }

        public static BlockSyntax Factory(
           params StatementSyntax[] @statements)
        {
            return SyntaxFactory.Block()
                .WithStatements(@statements);
        }

        # endregion Factories
    }
}
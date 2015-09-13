using System;
using BITS.Compilers.CSharp.Visitors;
using Microsoft.CodeAnalysis;

namespace BITS.Compilers.CSharp.Syntax
{
    public abstract class SyntaxNode<TSelf, TSyntaxNode> : IVisitable<TSelf>
        where TSelf : SyntaxNode<TSelf, TSyntaxNode>
        where TSyntaxNode : SyntaxNode
    {
        # region • Fields & Properties •

        public TSyntaxNode Syntax { get; private set; }

        # endregion Fields & Properties

        # region • Ctor's •

        internal protected SyntaxNode() { }

        internal protected SyntaxNode(TSyntaxNode @syntaxNode)
        {
            this.Init(@syntaxNode);
        }

        # endregion Ctor's

        # region • Methods •

        protected abstract TSelf New(TSyntaxNode @syntaxNode);

        protected TSelf Init(TSyntaxNode @syntaxNode)
        {
            this.Syntax = @syntaxNode;

            return this as TSelf;
        }

        protected TSelf Self(TSyntaxNode @syntaxNode)
        {
            if (!SyntaxConfiguration.Immutable)
            {
                this.Syntax = @syntaxNode;

                return this as TSelf;
            }

            if (this.Syntax == @syntaxNode)
                return this as TSelf;

            return this.New(@syntaxNode);
        }

        public TSelf Accept(ISyntaxVisitor<TSelf> visitor)
        {
            return visitor.Visit((TSelf)this);
        }

        public override String ToString()
        {
            return this.Syntax.NormalizeWhitespace()
                .ToFullString();
        }

        # endregion Methods
    }
}
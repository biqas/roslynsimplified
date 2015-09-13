using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    public static class ExtensionSyntaxNode
    {
        /// <summary>
        /// Removes region directives from syntax node.
        /// </summary>
        /// <returns></returns>
        public static T RemoveRegions<T>(this T @this)
            where T : SyntaxNode
        {
            var nodesWithRegionDirectives =
              from node in @this.DescendantNodesAndTokens()
              where node.HasLeadingTrivia
              from leadingTrivia in node.GetLeadingTrivia()
              where (leadingTrivia.Kind() == SyntaxKind.RegionDirectiveTrivia || leadingTrivia.Kind() == SyntaxKind.EndRegionDirectiveTrivia)
              select node;

            var triviaToRemove = new List<SyntaxTrivia>();

            foreach (var nodeWithRegionDirective in nodesWithRegionDirectives)
            {
                var triviaList = nodeWithRegionDirective.GetLeadingTrivia();

                for (var i = 0; i < triviaList.Count; i++)
                {
                    var currentTrivia = triviaList[i];

                    if (currentTrivia.Kind() != SyntaxKind.RegionDirectiveTrivia && currentTrivia.Kind() != SyntaxKind.EndRegionDirectiveTrivia)
                        continue;

                    triviaToRemove.Add(currentTrivia);

                    //if (i <= 0)
                    //    continue;

                    //var previousTrivia = triviaList[i - 1];

                    //if (previousTrivia.Kind == SyntaxKind.WhitespaceTrivia)
                    //    triviaToRemove.Add(previousTrivia);
                }
            }

            return triviaToRemove.Count > 0
                ? @this.ReplaceTrivia(triviaToRemove, (x, y) => default(SyntaxTrivia))
                : @this;
        }
    }
}

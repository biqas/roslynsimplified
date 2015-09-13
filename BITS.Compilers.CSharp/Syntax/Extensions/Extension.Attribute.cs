using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BITS.Compilers.CSharp.Syntax.Extensions
{
    /// <summary>
    /// Extension methods for attribute nodes.
    /// </summary>
    public static class ExtensionAttribute
    {
        /// <summary>
        /// Attributeses the specified attribute decleration nodes.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="attributeDeclerationNodes">The attribute decleration nodes.</param>
        /// <returns></returns>
        public static IEnumerable<AttributeSyntax> Attributes<TAttribute>(this IEnumerable<AttributeListSyntax> attributeDeclerationNodes)
        {
            return attributeDeclerationNodes.SelectMany(a => a.ChildNodes().OfType<AttributeSyntax>())
                .Where(a => a.Name.ToString() == typeof(TAttribute).Name);
        }

        /// <summary>
        /// Attributeses the specified attribute nodes.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="attributeNodes">The attribute nodes.</param>
        /// <returns></returns>
        public static IEnumerable<AttributeSyntax> Attributes<TAttribute>(this IEnumerable<AttributeSyntax> attributeNodes)
        {
            return attributeNodes.Where(a => a.Name.ToString() == typeof(TAttribute).Name);
        }

        /// <summary>
        /// Determines whether the specified attribute decleration nodes has attributes.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="attributeDeclerationNodes">The attribute decleration nodes.</param>
        /// <returns>
        ///   <c>true</c> if the specified attribute decleration nodes has attributes; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean HasAttributes<TAttribute>(this IEnumerable<AttributeListSyntax> attributeDeclerationNodes)
        {
            return attributeDeclerationNodes.Attributes<TAttribute>().Any();
        }

        /// <summary>
        /// Determines whether the specified attribute nodes has attributes.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="attributeNodes">The attribute nodes.</param>
        /// <returns>
        ///   <c>true</c> if the specified attribute nodes has attributes; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean HasAttributes<TAttribute>(this IEnumerable<AttributeSyntax> attributeNodes)
        {
            return attributeNodes.Attributes<TAttribute>().Any();
        }
    }
}
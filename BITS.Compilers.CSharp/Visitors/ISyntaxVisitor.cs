using System;

namespace BITS.Compilers.CSharp.Visitors
{
    public interface ISyntaxVisitor<T>
        where T : IVisitable<T>
    {
        # region • Fields & Properties •

        Action<T> Visiting { get; set; }

        Action<T> Visited { get; set; }

        # endregion Fields & Properties

        # region • Methods •

        T Visit(T node);

        # endregion Methods
    }
}
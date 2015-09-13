namespace BITS.Compilers.CSharp.Visitors
{
    public interface IVisitable<TSelf>
        where TSelf : IVisitable<TSelf>
    {
        TSelf Accept(ISyntaxVisitor<TSelf> visitor);
    }
}

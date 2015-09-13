using System;
using BITS.Compilers.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BITS.Compilers.CSharp.Test
{
    [TestClass]
    public class TestUsing
    {
        [TestMethod]
        public void Create_Using()
        {
            var @using = new Using("BITS.Compilers.CSharp.Test");

            var expectet = Comparer.Create_Using();
            var actual = @using.ToString();

            Assert.AreEqual(expectet, actual);
            Console.WriteLine(actual);
        }

        [TestMethod]
        public void Create_Using_With_Given_Namespace()
        {
            var @namespace = new Namespace("BITS.Compilers.CSharp.Test");

            var @using = new Using(@namespace);

            var expectet = Comparer.Create_Using_With_Given_Namespace();
            var actual = @using.ToString();

            Assert.AreEqual(expectet, actual);
            Console.WriteLine(actual);
        }


        public static class Comparer
        {
            public static String Create_Using()
            {
                return
@"using BITS.Compilers.CSharp.Test;";
            }

            public static String Create_Using_With_Given_Namespace()
            {
                return
@"using BITS.Compilers.CSharp.Test;";
            }
        }
    }
}
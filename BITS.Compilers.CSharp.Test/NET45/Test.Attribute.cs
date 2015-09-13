using System;
using BITS.Compilers.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Attribute = BITS.Compilers.CSharp.Syntax.Attribute;

namespace BITS.Compilers.CSharp.Test
{
    [TestClass]
    public class TestAttribute
    {
        [TestMethod]
        public void Create_Attribute_Simple()
        {
            var attribute = new Attribute("Create_Attribute_Simple");

            var expectet = Comparer.Create_Attribute_Simple();
            var actual = attribute.ToString();

            Assert.AreEqual(expectet, actual);
            Console.WriteLine(actual);
        }

        [TestMethod]
        public void Create_Attribute_With_Arguments()
        {
            var attribute = new Attribute("Create_Attribute_With_Arguments")
                .AddArgument("1")
                .AddArgument("X", "2")
                .AddArgument("X", "4 + 2");

            var expectet = Comparer.Create_Attribute_With_Arguments();
            var actual = attribute.ToString();

            Assert.AreEqual(expectet, actual);
            Console.WriteLine(actual);
        }

        [TestMethod]
        public void Create_Attributes_Single()
        {
            var attributes = new Attributes("Create_Attributes_Single");

            var expectet = Comparer.Create_Attributes_Single();
            var actual = attributes.ToString();

            Assert.AreEqual(expectet, actual);
            Console.WriteLine(actual);
        }

        [TestMethod]
        public void Create_Attributes_List()
        {
            var attributes = new Attributes("Create_Attributes_1")
                .AddAttribute("Create_Attributes_2", "X", "42 + 42");

            var expectet = Comparer.Create_Attributes_List();
            var actual = attributes.ToString();

            Assert.AreEqual(expectet, actual);
            Console.WriteLine(actual);
        }

        public static class Comparer
        {
            public static String Create_Attribute_Simple()
            {
                return
@"Create_Attribute_Simple";
            }

            public static String Create_Attribute_With_Arguments()
            {
                return
@"Create_Attribute_With_Arguments(1, X = 2, X = 4 + 2)";
            }

            public static String Create_Attributes_Single()
            {
                return
@"[Create_Attributes_Single]";
            }

            public static String Create_Attributes_List()
            {
                return
@"[Create_Attributes_1, Create_Attributes_2(X = 42 + 42)]";
            }
        }
    }
}

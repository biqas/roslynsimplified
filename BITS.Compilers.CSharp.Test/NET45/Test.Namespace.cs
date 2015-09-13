using System;
using BITS.Compilers.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BITS.Compilers.CSharp.Test
{
    [TestClass]
    public class TestNamespace
    {
        [TestMethod]
        public void Create_Namespace()
        {
            var @namespace = new Namespace("Create_Namespace");

            var expectet = Comparer.Create_Namespace();
            var actual = @namespace.ToString();

            Assert.AreEqual(expectet, actual);
            Console.WriteLine(actual);
        }

        [TestMethod]
        public void Create_Nested_Namespaces()
        {
            var @namespace = new Namespace("Create_Nested_Namespaces")
            {
                new Namespace("Nested_Create_Nested_Namespaces"),  
            };

            var expectet = Comparer.Create_Nested_Namespaces();
            var actual = @namespace.ToString();
            Assert.AreEqual(expectet, actual);
            Console.WriteLine(actual);
        }

        [TestMethod]
        public void Create_Namespace_Long()
        {
            var @namespace = new Namespace("Create.Namespace.Long");

            var expectet = Comparer.Create_Namespace_Long();
            var actual = @namespace.ToString();

            Assert.AreEqual(expectet, actual);
            Console.WriteLine(actual);
        }


        public static class Comparer
        {
            public static String Create_Namespace()
            {
                return
@"namespace Create_Namespace
{
}";
            }

            public static String Create_Nested_Namespaces()
            {
                return
@"namespace Create_Nested_Namespaces
{
    namespace Nested_Create_Nested_Namespaces
    {
    }
}";
            }

            public static String Create_Namespace_Long()
            {
                return
@"namespace Create.Namespace.Long
{
}";
            }
        }
    }
}
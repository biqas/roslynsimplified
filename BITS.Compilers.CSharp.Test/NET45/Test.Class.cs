using System;
using BITS.Compilers.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BITS.Compilers.CSharp.Test
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void Create_Class()
        {
            var @class = new Class("Create_Class");

            var expected = Comparer.Create_Class();
            var actual   = @class.ToString();

            Assert.AreEqual(expected, actual);
            Console.WriteLine(actual);
        }

        [TestMethod]
        public void Create_Class_With_Fields()
        {
            var @class = new Class("Create_Class_With_Fields")
                .AddMembers(new Field("Field_1"))
                .AddMembers(new Field("Field_2"));

            var expected = Comparer.Create_Class_With_Fields();
            var actual   = @class.ToString();

            Assert.AreEqual(expected, actual);
            Console.WriteLine(actual);
        }

        [TestMethod]
        public void Create_Class_With_Properties()
        {
            var @class = new Class("Create_Class_With_Properties")
                .AddMembers(new Property("Boolean", "Property_1"))
                .AddMembers(new Property(typeof(Int32), "Property_2"));

            var expected = Comparer.Create_Class_With_Properties();
            var actual   = @class.ToString();

            Assert.AreEqual(expected, actual);
            Console.WriteLine(actual);
        }

        [TestMethod]
        public void Create_Class_With_Methods()
        {
            var @class = new Class("Create_Class_With_Methods")
               .AddMembers(new Method("Boolean", "Method_1"))
               .AddMembers(new Method(typeof(Int32), "Method_2"))
               .AddMembers(new Method("Method_3"));

            var expected = Comparer.Create_Class_With_Methods();
            var actual = @class.ToString();

            Assert.AreEqual(expected, actual);
            Console.WriteLine(actual);
        }


        [TestMethod]
        public void Create_Class_With_Method_Block()
        {
            var @class = new Class("Create_Class_With_Methods")
                .AddMembers(new Field("Field_1"))
                .AddMembers(new Method(nameof(Int32), "Method_2"));

            var expected = Comparer.Create_Class_With_Methods();
            var actual = @class.ToString();

            Assert.AreEqual(expected, actual);
            Console.WriteLine(actual);
        }


        public static class Comparer
        {
            public static String Create_Class()
            {
                return
@"class Create_Class
{
}";
            }

            public static String Create_Class_With_Fields()
            {
                return
@"class Create_Class_With_Fields
{
    Object Field_1;
    Object Field_2;
}";
            }
            public static String Create_Class_With_Properties()
            {
                return
@"class Create_Class_With_Properties
{
    Boolean Property_1
    {
        get;
        set;
    }

    Int32 Property_2
    {
        get;
        set;
    }
}";
            }

            public static String Create_Class_With_Methods()
            {
                return
@"class Create_Class_With_Methods
{
    Boolean Method_1()
    {
    }

    Int32 Method_2()
    {
    }

    void Method_3()
    {
    }
}";
            }
        }
    }
}
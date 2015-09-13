using System;
using BITS.Compilers.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BITS.Compilers.CSharp.Test
{
    [TestClass]
    public class TestField
    {
        [TestMethod]
        public void Create_Field()
        {
            var field = new Field("Create_Field");

            var expected = Comparer.Create_Field();
            var actual = field.ToString();

            Assert.AreEqual(expected, actual);
            Console.WriteLine(actual);
        }

        [TestMethod]
        public void Create_Field_With_Attribute()
        {
            var field = new Field("Create_Field_With_Attribute")
                .AddAttribute("Field_With_Attribute");

            var expected = Comparer.Create_Field_With_Attribute();
            var actual = field.ToString();

            Assert.AreEqual(expected, actual);
            Console.WriteLine(actual);
        }

        [TestMethod]
        public void Create_Field_ReadOnly()
        {
            var field = new Field("Create_Field_ReadOnly")
                .AddModifiers(MODIFIER.READ_ONLY);

            var expected = Comparer.Create_Field_ReadOnly();
            var actual = field.ToString();

            Assert.AreEqual(expected, actual);
            Console.WriteLine(actual);
        }

        [TestMethod]
        public void Create_Field_With_Modifier_Type_And_Value()
        {
            var field = new Field("Create_Field_With_Modifier_Type_And_Value")
                .WithModifiers(MODIFIER.PROTECTED)
                .WithType<Int32>()
                .WithInitializer("42");

            var expected = Comparer.Create_Field_With_Modifier_Type_And_Value();
            var actual = field.ToString();

            Assert.AreEqual(expected, actual);
            Console.WriteLine(actual);
        }


        public static class Comparer
        {
            public static String Create_Field()
            {
                return
@"Object Create_Field;";
            }

            public static String Create_Field_ReadOnly()
            {
                return
@"readonly Object Create_Field_ReadOnly;";
            }

            public static String Create_Field_With_Attribute()
            {
                return
@"[Field_With_Attribute]
Object Create_Field_With_Attribute;";
            }

            public static String Create_Field_With_Modifier_Type_And_Value()
            {
                return
@"protected Int32 Create_Field_With_Modifier_Type_And_Value = 42;";
            }
        }
    }
}
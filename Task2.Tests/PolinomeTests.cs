using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;

namespace Task1.Tests
{
    [TestFixture]
    public class PolinomeTests
    {
        [Test]
        public void Polinome_AdditionTest()
        {
            Polinome firstPolinom = new Polinome(10, 20, 30);
            Polinome secondPolinom = new Polinome(1, 2, 3, 4);

            Polinome expected = new Polinome(11, 22, 33, 4);

            Polinome result = firstPolinom+secondPolinom;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Polinome_SubstractionTest()
        {
            Polinome firstPolinom = new Polinome(10, 20, 30);
            Polinome secondPolinom = new Polinome(1, 2, 3, 4);

            Polinome expected = new Polinome(9, 18, 27, -4);

            Polinome result = firstPolinom - secondPolinom;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Polinome_MultipleTest()
        {
            Polinome firstPolinom = new Polinome(1, 2, 3);
            Polinome secondPolinom = new Polinome(1, 2, 3, 4);

            Polinome expected = new Polinome(1, 5, 14, 14, 13, 9);

            Polinome result = firstPolinom * secondPolinom;

            Assert.AreEqual(expected, result);
        }


        [Test]
        public void Polinome_StringTest()
        {
            Polinome polinom = new Polinome(10, 20, 30);

            string expected = "+30x^2 +20x^1 +10x^0";

            string result = polinom.ToString();

            Assert.AreEqual(expected, result);
        }
  

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransformWords;

namespace TransformWordsTests
{
    [TestFixture]
    public class TransDigToWordsTest
    {
        [TestCase(new double[] {12, 513}, ExpectedResult = new string[] {"one two", "five one three"})]
        [TestCase(new double[] {20.17, 0}, ExpectedResult = new string[]
        {
            "two zero point one seven", "zero"
        })]
        [TestCase(new double[] {-4578.164537, 39}, ExpectedResult = new string[]
        {
            "minus four five seven eight point one six four five three seven", "three nine"
        })]
        public string[] FilterDigitTest_TakesArrayDoublNumbers_ReturnArrayStringWords(double[] numb)
        {
            var tdw = new TransNumbsToWords();
            return tdw.TransformToWords(numb, new TransformDoubleToWord());
        }

        [TestCase(new double[] { 12, 513 }, ExpectedResult = new string[] { "one two", "five one three" })]
        [TestCase(new double[] { 20.17, 0 }, ExpectedResult = new string[]
{
            "two zero point one seven", "zero"
})]
        [TestCase(new double[] { -4578.164537, 39 }, ExpectedResult = new string[]
{
            "minus four five seven eight point one six four five three seven", "three nine"
})]
        public string[] FilterDigitTest_TakeArrDoublNumbersAndLogicTransform_ReturnArrayStringWords(double[] numb)
        {
            var tdw = new TransNumbsToWords();
            DelTransformer dt = new TransformDoubleToWord().Transform;
            return tdw.TransformToWords(numb, dt);
        }


        [Test]
        public void FilterDigitTest_With_IncommingArrayIsNull_ThrowsArgumentNullException()
        {
            var tdw = new TransNumbsToWords();
            Assert.That(() => tdw.TransformToWords(null, new TransformDoubleToWord()), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Teststr()
        {
        double[] aktual = new [] 
              { -255.255, 255.255, 4294967295.0, double.MinValue, double.MaxValue, double.Epsilon,
                  double.NaN, double.NegativeInfinity, double.PositiveInfinity, -0.0, 0.0, -3576987145.45114756314,
                  0.1245721451781456484, 1451.244457851E-12
              };

        string[] expected = new []
            {
                "1100000001101111111010000010100011110101110000101000111101011100",
                "0100000001101111111010000010100011110101110000101000111101011100",
                "0100000111101111111111111111111111111111111000000000000000000000",
                "1111111111101111111111111111111111111111111111111111111111111111",
                "0111111111101111111111111111111111111111111111111111111111111111",
                "0000000000000000000000000000000000000000000000000000000000000001",
                "1111111111111000000000000000000000000000000000000000000000000000",
                "1111111111110000000000000000000000000000000000000000000000000000",
                "0111111111110000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000",
                "0000000000000000000000000000000000000000000000000000000000000000",
                "1100000111101010101001101000111111000001001011100110111111001101",
                "0011111110111111111000111111010111001001100010000101111100000001",
                "0011111000011000111011101010001111111111111110010111011110010001"
            };

            var tdw = new TransNumbsToWords();
            Assert.That(() => tdw.DoubleToIEEE754(aktual), Is.EqualTo(expected));
        }
        
    }
}

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
            return TransDigToWords.FilterDigit(numb);
        }

        [Test]
        public void FilterDigitTest_With_IncommingArrayIsNull_ThrowsArgumentNullException()
        {
            Assert.That(() => TransDigToWords.FilterDigit(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }
    }
}

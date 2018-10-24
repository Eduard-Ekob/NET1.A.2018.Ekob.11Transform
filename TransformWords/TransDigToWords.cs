using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformWords
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// This class transform numbers to words
    /// </summary>
    public class TransDigToWords
    {
        private string[] destStrArr;

        /// <summary>
        /// This method take array with numbers and convert digits to words
        /// </summary>
        /// <param name="numbers">source array of numbers</param>
        /// <returns>destination array of words</returns>
        /// <exception cref="ArgumentNullException">If source array is null throw exception</exception>
        public string[] FilterDigit(double[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException();

            destStrArr = new string[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                string collectStr = DoubleToStringWords(numbers[i]).Trim();
                destStrArr[i] = collectStr;
            }

            return destStrArr;
        }

        private string DoubleToStringWords(double sourceValue)
        {
            char[] chArr = sourceValue.ToString().ToCharArray();

            string collectStr = string.Empty;
            for (int i = 0; i < chArr.Length; i++)
            {
                switch (chArr[i])
                {
                    case '0':
                        collectStr += "zero ";
                        break;
                    case '1':
                        collectStr += "one ";
                        break;
                    case '2':
                        collectStr += "two ";
                        break;
                    case '3':
                        collectStr += "three ";
                        break;
                    case '4':
                        collectStr += "four ";
                        break;
                    case '5':
                        collectStr += "five ";
                        break;
                    case '6':
                        collectStr += "six ";
                        break;
                    case '7':
                        collectStr += "seven ";
                        break;
                    case '8':
                        collectStr += "eight ";
                        break;
                    case '9':
                        collectStr += "nine ";
                        break;
                    case ',':
                        collectStr += "point ";
                        break;
                    case '-':
                        collectStr += "minus ";
                        break;
                    case '+':
                        collectStr += "plus ";
                        break;
                    case 'E':
                        collectStr += "exp ";
                        break;
                }
            }
            return collectStr;
        }
    }

    public static class FilterDigitExtension
    {        
        /// <summary>
        /// This method convert double to binary IEEE754 string  format
        /// </summary>
        /// <param name="sourceD">Is incomming argument</param>
        /// <returns>Resulting value</returns>
        public static string[] DoubleToIEEE754(this TransDigToWords tdwToWords, params double[] sourceD)
        {
            string[] outputStr = new string[sourceD.Length];
            for (int i = 0; i < sourceD.Length; i++)
            {
                DoubleToLongUnion unionDL = new DoubleToLongUnion { sourceDouble = sourceD[i] };
                outputStr[i] = LongToString(unionDL.destLong);
            }            
            return outputStr;
        }

        private  static string LongToString(long sourceL)
        {
            string destStr = string.Empty;
            int szLong = sizeof(long) << 3; //multiply 8
            for (int i = 0; i < szLong; i++)
            {
                if ((sourceL & 1) == 1)
                {
                    destStr += '1';
                }
                else
                {
                    destStr += '0';
                }

                sourceL = sourceL >> 1;
            }

            return ReverseString(destStr);
        }

        private static string ReverseString(string destStr)
        {
            StringBuilder sb = new StringBuilder(destStr.Length);
            for (int i = destStr.Length - 1; i >= 0; i--)
            {
                sb.Append(destStr[i]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// This structure give long value from double by long value
        /// take access to memory area from double value.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct DoubleToLongUnion
        {
            [FieldOffset(0)]
            public double sourceDouble;

            [FieldOffset(0)]
            public readonly long destLong;
        }
    }  
}




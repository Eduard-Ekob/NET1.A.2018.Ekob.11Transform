using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TransformWords
{
    using System.Runtime.InteropServices;
    
    /// <summary>
    /// This class transform numbers to words
    /// </summary>
    public class TransNumbsToWords
    {
        private string[] destStrArr;

        /// <summary>
        /// This method take array with numbers, logic of transformation
        /// and transform digits to words
        /// </summary>
        /// <param name="numbers">source array of numbers</param>
        /// <param name="transformer">logic transformation which implements ITransformer interface</param>
        /// <returns>destination array of words</returns>
        /// <exception cref="ArgumentNullException">If source array is null throw exception</exception>                
        public string[] TransformToWords(double[] numbers, ITransformer transformer)
        {
            if (transformer == null)
            {
                throw new ArgumentNullException(nameof(transformer));
            }

            CheckExceptions(numbers);
            destStrArr = new string[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                string collectStr = transformer.Transform(numbers[i]).Trim();
                destStrArr[i] = collectStr;
            }

            return destStrArr;            
        }
        /// <summary>
        /// This overloaded method take array with numbers, logic of transformation
        /// and transform digits to words
        /// </summary>
        /// <param name="numbers">source array of numbers</param>
        /// <param name="delTransformer">logic transformation take delegate instance</param>
        /// <returns>destination array of words</returns>
        /// <exception cref="ArgumentNullException">If source array is null throw exception</exception>            
        public string[] TransformToWords(double[] numbers, DelTransformer delTransformer)
        {
            if (delTransformer == null)
            {
                throw new ArgumentNullException(nameof(delTransformer));
            }

            CheckExceptions(numbers);
            destStrArr = new string[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                string collectStr = delTransformer(numbers[i]).Trim();
                destStrArr[i] = collectStr;
            }

            return destStrArr;
        }
       
        private void CheckExceptions(double[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }
        }
    }

    public static class FilterDigitExtension
    {
        /// <summary>
        /// This method convert double to binary IEEE754 string  format
        /// </summary>
        /// <param name="sourceD">Is incomming argument</param>
        /// <returns>Resulting value</returns>
        public static string[] DoubleToIEEE754(this TransNumbsToWords tdwToWords, params double[] sourceD)
        {
            string[] outputStr = new string[sourceD.Length];
            for (int i = 0; i < sourceD.Length; i++)
            {
                DoubleToLongUnion unionDL = new DoubleToLongUnion { sourceDouble = sourceD[i] };
                outputStr[i] = LongToString(unionDL.destLong);
            }

            return outputStr;
        }

        private static string LongToString(long sourceL)
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




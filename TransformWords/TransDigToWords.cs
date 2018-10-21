using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TransformWords
{
    /// <summary>
    /// This class transform numbers to words
    /// </summary>
    public class TransDigToWords
    {
        private static string[] destStrArr;
        /// <summary>
        /// This method take array with numbers and convert digits to words
        /// </summary>
        /// <param name="numbers">source array of numbers</param>
        /// <returns>destination array of words</returns>
        /// <exception cref="ArgumentNullException">If source array is null throw exception</exception>
        public static string[] FilterDigit(double[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException();
            
            destStrArr = new string[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                char[] chArr = numbers[i].ToString().ToCharArray();
                string collectStr = string.Empty;
                for (int j = 0; j < chArr.Length; j++)
                {                    
                    switch (chArr[j])
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
                    }                    
                }
                collectStr = collectStr.Trim();
                //destStrArr[i] = "\""+collectStr+"\"";
                destStrArr[i] = collectStr;
            }            
            return destStrArr;
        }
        
    }
}

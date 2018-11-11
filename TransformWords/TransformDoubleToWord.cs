using System.Text;
using System.Threading;

namespace TransformWords
{
    public delegate string DelTransformer(double number);
    public class TransformDoubleToWord : ITransformer
    {
       
        public string Transform(double number)
        {
            string sourceStr = number.ToString();
            StringBuilder collectStr = null;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sourceStr.Length; i++)
            {
                switch (sourceStr[i])
                {
                    case '0':
                        collectStr = sb.Append("zero ");
                        break;
                    case '1':
                        collectStr = sb.Append("one ");
                        break;
                    case '2':
                        collectStr = sb.Append("two ");
                        break;
                    case '3':
                        collectStr = sb.Append("three ");
                        break;
                    case '4':
                        collectStr = sb.Append("four ");
                        break;
                    case '5':
                        collectStr = sb.Append("five ");
                        break;
                    case '6':
                        collectStr = sb.Append("six ");
                        break;
                    case '7':
                        collectStr = sb.Append("seven ");
                        break;
                    case '8':
                        collectStr = sb.Append("eight ");
                        break;
                    case '9':
                        collectStr = sb.Append("nine ");
                        break;
                    case ',':
                        collectStr = sb.Append("point ");
                        break;
                    case '-':
                        collectStr = sb.Append("minus ");
                        break;
                    case '+':
                        collectStr = sb.Append("plus ");
                        break;
                    case 'E':
                        collectStr = sb.Append("exp ");
                        break;
                }
            }

            return collectStr.ToString();
        }
    }
}
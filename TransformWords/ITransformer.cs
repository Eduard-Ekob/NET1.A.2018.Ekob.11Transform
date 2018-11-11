using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformWords
{
    public interface ITransformer
    {
        string Transform(double number);
    }
}

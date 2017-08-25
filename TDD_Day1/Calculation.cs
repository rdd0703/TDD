using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Day1
{
    public class Calculation
    {
        private List<ProductModel> _lstProduct;

        public Calculation(List<ProductModel> lstProduct)
        {
            this._lstProduct = lstProduct;
        }

        public IEnumerable<int> GetGroupSum(int groupCount, Func<ProductModel, int> selector)
        {
            if (groupCount < 0) throw new ArgumentException();
            if (selector == null) throw new ArgumentException();

            var index = 0;
            while (index <= this._lstProduct.Count)
            {
                if (groupCount == 0)
                {
                    yield return  0;
                    yield break;
                }
                else
                {
                    yield return this._lstProduct.Skip(index).Take(groupCount).Sum(selector);
                    index += groupCount;
                }
            }

        }
    }
}

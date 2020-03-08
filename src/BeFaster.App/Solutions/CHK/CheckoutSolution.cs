using BeFaster.Runner.Exceptions;
using System.Collections.Generic;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        static IDictionary<char, int> prices = new Dictionary<char, int>()
        {
            {'A', 50 },
            {'B', 30 },
            {'C', 20},
            {'D', 15 }
        };

        public static int ComputePrice(string skus)
        {
            int sum = 0;
            foreach(var sku in skus)
            {
                if (prices.ContainsKey(sku))
                    sum += prices[sku];
                else
                    return -1;
            }
            return sum;
        }
    }
}





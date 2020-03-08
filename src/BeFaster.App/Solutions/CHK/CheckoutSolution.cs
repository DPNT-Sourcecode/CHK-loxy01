using BeFaster.Runner.Exceptions;
using System.Collections.Generic;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        static IDictionary<string, int> prices = new Dictionary<string, int>()
        {
            {"A", 50 },
            {"B", 30 },
            { "C", 20},
            {"D", 15 }
        };

        public static int ComputePrice(string skus)
        {
            if (prices.ContainsKey(skus))
                return prices[skus];
            else
                return -1;
        }
    }
}




using BeFaster.Runner.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        static IDictionary<char, int> prices = new Dictionary<char, int>()
        {
            {'A', 50 },
            {'B', 30 },
            {'C', 20},
            {'D', 15 },
            {'E', 40 }
        };

        public static int ComputePrice(string skus)
        {
            var items = new Dictionary<char, int>();
            foreach (var sku in skus)
            {
                if (!prices.ContainsKey(sku))
                    return -1;
                else
                {
                    if (!items.ContainsKey(sku))
                        items.Add(sku, 1);
                    else
                        items[sku] += 1;
                }
            }

            var countOfItemE = items['E'];
            var freeBs = countOfItemE / 2;

            items['B'] = (items['B'] - freeBs) > 0 ? items['B'] - freeBs : 0;

            int sum = 0;
            foreach (var item in items)
            {
                if (item.Key == 'A')
                {
                    int count = item.Value;
                    var offerPrice = (count / 3) * 130;
                    var normalPrice = (count % 3) * prices[item.Key];
                    sum += (offerPrice + normalPrice);
                }
                else if (item.Key == 'B')
                {
                    int count = item.Value;
                    var offerPrice = (count / 2) * 45;
                    var normalPrice = (count % 2) * prices[item.Key];
                    sum += (offerPrice + normalPrice);
                }
                else
                    sum += item.Value * prices[item.Key];
            }
            return sum;

        }
    }
}




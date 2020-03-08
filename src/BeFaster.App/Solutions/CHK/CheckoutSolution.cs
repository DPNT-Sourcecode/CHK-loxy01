using BeFaster.Runner.Exceptions;
using System;
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
            {'E', 40 },
            {'F', 10 },
            {'G', 20},
            {'H', 10},
            {'I', 35},
            {'J', 60},
            {'K', 80},
            {'L', 90},
            {'M', 15},
            {'N', 40},
            {'O', 10},
            {'P', 50},
            {'Q', 30},
            {'R', 50},
            {'S', 30},
            {'T', 20},
            {'U', 40},
            {'V', 50},
            {'W', 20},
            {'X', 90},
            {'Y', 10},
            {'Z', 50 }
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

            ApplyOfferE(items);
            ApplyOfferF(items);
            ApplyOfferH(items);

            int sum = 0;
            foreach (var item in items)
            {
                if (item.Key == 'A')
                {
                    int totalA = ApplyOfferA(item);
                    sum += totalA;
                }
                else if (item.Key == 'B')
                {
                    int totalB = ApplyOfferB(item);
                    sum += totalB;
                }
                else if(item.Key == 'H')
                {
                    int totalH = ApplyOfferH(item);
                    sum += totalH;
                }
                else
                    sum += item.Value * prices[item.Key];
            }
            return sum;

        }

        private static int ApplyOfferH(KeyValuePair<char, int> item)
        {
            int count = item.Value;
            var offer1Price = (count / 10) * 80;
            var remaining = count % 10;
            var offer2Price = (remaining / 5) * 45;
            var normalPrice = (remaining % 5) * prices[item.Key];
            var totalH = (offer1Price + offer2Price + normalPrice);
            return totalH;
        }

        private static int ApplyOfferB(KeyValuePair<char, int> item)
        {
            int count = item.Value;
            var offerPrice = (count / 2) * 45;
            var normalPrice = (count % 2) * prices[item.Key];
            var totalB = (offerPrice + normalPrice);
            return totalB;
        }

        private static int ApplyOfferA(KeyValuePair<char, int> item)
        {
            int count = item.Value;
            var offer1Price = (count / 5) * 200;
            var remaining = count % 5;
            var offer2Price = (remaining / 3) * 130;
            var normalPrice = (remaining % 3) * prices[item.Key];
            var totalA = (offer1Price + offer2Price + normalPrice);
            return totalA;
        }

        private static void ApplyOfferH(Dictionary<char, int> items)
        {
            
        }

        private static void ApplyOfferF(Dictionary<char, int> items)
        {
            if (items.ContainsKey('F') && items['F'] >= 3)
            {
                var countOfF = items['F'];
                var freeFs = countOfF / 3;
                items['F'] = items['F'] - freeFs;
            }
        }

        private static void ApplyOfferE(Dictionary<char, int> items)
        {
            if (items.ContainsKey('E') && items.ContainsKey('B'))
            {
                var countOfItemE = items['E'];
                var freeBs = countOfItemE / 2;

                items['B'] = (items['B'] - freeBs) > 0 ? items['B'] - freeBs : 0;
            }
        }

    }
}







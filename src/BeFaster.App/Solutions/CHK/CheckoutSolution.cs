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
            {'K', 70},
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
            ApplyOfferN(items);
            ApplyOfferR(items);
            ApplyOfferU(items);

            int sum = 0;
            foreach (var item in items)
            {
                if (item.Key == 'A')
                {
                    sum += ApplyOfferA(item);
                }
                else if (item.Key == 'B')
                {
                    sum += ApplyOfferB(item);
                }
                else if (item.Key == 'H')
                {
                    sum += ApplyOfferH(item);
                }
                else if (item.Key == 'K')
                {
                    sum += ApplyOfferK(item); ;
                }
                else if (item.Key == 'P')
                {
                    sum += ApplyOfferP(item);
                }
                else if (item.Key == 'Q')
                {
                    sum += ApplyOfferQ(item);
                }
                else if (item.Key == 'V')
                {
                    sum += ApplyOfferV(item);
                }
                else if (item.Key == 'S' || item.Key == 'T' || item.Key == 'X' || item.Key == 'Y' || item.Key == 'Z')
                {

                }
                else
                    sum += item.Value * prices[item.Key];
            }

            sum += AddMultiBuyOffer(items);

            return sum;

        }

        private static int AddMultiBuyOffer(Dictionary<char, int> items)
        {
            var totalItems = items['Z'] + items['S'] + items['T'] + items['Y'] + items['X'];
            var ItemsIn3 = (totalItems / 3) * 45;
            var remaining = totalItems % 3;
            var total = ItemsIn3 * 45;

            int rem = remaining - items['X'];
            if (rem <= 0)
            {
                total += remaining * items['X'];
                remaining = 0;
            }
            


            return total;
        }

        private static int ApplyOfferV(KeyValuePair<char, int> item)
        {
            int count = item.Value;
            var offer1Price = (count / 3) * 130;
            var remaining = count % 3;
            var offer2Price = (remaining / 2) * 90;
            var normalPrice = (remaining % 2) * prices[item.Key];
            return (offer1Price + offer2Price + normalPrice);
        }

        private static void ApplyOfferU(Dictionary<char, int> items)
        {
            if (items.ContainsKey('U') && items['U'] >= 4)
            {
                var countOfF = items['U'];
                var freeItems = countOfF / 4;
                items['U'] = items['U'] - freeItems;
            }
        }

        private static void ApplyOfferR(Dictionary<char, int> items)
        {
            if (items.ContainsKey('R') && items.ContainsKey('Q'))
            {
                var countOfItemE = items['R'];
                var freeItemCount = countOfItemE / 3;
                items['Q'] = (items['Q'] - freeItemCount) > 0 ? items['Q'] - freeItemCount : 0;
            }
        }

        private static int ApplyOfferQ(KeyValuePair<char, int> item)
        {
            int count = item.Value;
            var offerPrice = (count / 3) * 80;
            var normalPrice = (count % 3) * prices[item.Key];
            return (offerPrice + normalPrice);

        }

        private static int ApplyOfferP(KeyValuePair<char, int> item)
        {
            int count = item.Value;
            var offerPrice = (count / 5) * 200;
            var normalPrice = (count % 5) * prices[item.Key];
            return (offerPrice + normalPrice);
        }

        private static void ApplyOfferN(Dictionary<char, int> items)
        {
            if (items.ContainsKey('N') && items.ContainsKey('M'))
            {
                var countOfItemE = items['N'];
                var freeMs = countOfItemE / 3;

                items['M'] = (items['M'] - freeMs) > 0 ? items['M'] - freeMs : 0;
            }
        }

        private static int ApplyOfferK(KeyValuePair<char, int> item)
        {
            int count = item.Value;
            var offerPrice = (count / 2) * 120;
            var normalPrice = (count % 2) * prices[item.Key];
            return (offerPrice + normalPrice);
        }

        private static int ApplyOfferH(KeyValuePair<char, int> item)
        {
            int count = item.Value;
            var offer1Price = (count / 10) * 80;
            var remaining = count % 10;
            var offer2Price = (remaining / 5) * 45;
            var normalPrice = (remaining % 5) * prices[item.Key];
            return (offer1Price + offer2Price + normalPrice);

        }

        private static int ApplyOfferB(KeyValuePair<char, int> item)
        {
            int count = item.Value;
            var offerPrice = (count / 2) * 45;
            var normalPrice = (count % 2) * prices[item.Key];
            return (offerPrice + normalPrice);

        }

        private static int ApplyOfferA(KeyValuePair<char, int> item)
        {
            int count = item.Value;
            var offer1Price = (count / 5) * 200;
            var remaining = count % 5;
            var offer2Price = (remaining / 3) * 130;
            var normalPrice = (remaining % 3) * prices[item.Key];
            return (offer1Price + offer2Price + normalPrice);

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





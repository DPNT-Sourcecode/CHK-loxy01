using BeFaster.App.Solutions.CHK;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public class CheckoutSolutionTest
    {
        [TestCase("Z", ExpectedResult = -1)]
        [TestCase("A", ExpectedResult =50)]
        [TestCase("B", ExpectedResult = 30)]
        [TestCase("C", ExpectedResult = 20)]
        [TestCase("D", ExpectedResult = 15)]
        [TestCase("E", ExpectedResult = 40)]
        [TestCase("F", ExpectedResult = 10)]
        [TestCase("AB", ExpectedResult = 80)]
        [TestCase("AAA", ExpectedResult = 130)]
        [TestCase("BB", ExpectedResult = 45)]
        [TestCase("AAAABBBCD", ExpectedResult = 290)]
        [TestCase("EEBB", ExpectedResult = 110)]
        [TestCase("EEA", ExpectedResult = 130)]
        [TestCase("AAAAAAAAABBBCD", ExpectedResult = 490)]
        [TestCase("FFF", ExpectedResult = 20)]
        public int ComputePrice(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }
    }
}






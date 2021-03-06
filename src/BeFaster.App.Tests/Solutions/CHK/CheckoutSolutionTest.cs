﻿using BeFaster.App.Solutions.CHK;
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
        [TestCase("1", ExpectedResult = -1)]
        [TestCase("Z", ExpectedResult = 21)]
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
        [TestCase("FFFF", ExpectedResult = 30)]
        [TestCase("FFFFFF", ExpectedResult = 40)]
        [TestCase("H", ExpectedResult = 10)]
        [TestCase("KKK", ExpectedResult = 190)]
        [TestCase("NNNMM", ExpectedResult = 135)]
        [TestCase("HHHHHH", ExpectedResult = 55)]
        [TestCase("HHHHHHHHHHHHHHHH", ExpectedResult = 135)]
        [TestCase("PPPPPP", ExpectedResult = 250)]
        [TestCase("QQQQ", ExpectedResult = 110)]
        [TestCase("RRRQQ", ExpectedResult = 180)]
        [TestCase("UUUUUUUU", ExpectedResult = 240)]
        [TestCase("VVVVV", ExpectedResult = 220)]
        [TestCase("V", ExpectedResult = 50)]
        [TestCase("STXYZ", ExpectedResult = 82)]
        [TestCase("S", ExpectedResult = 20)]
        [TestCase("SSSZ", ExpectedResult = 65)]
        public int ComputePrice(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }
    }
}



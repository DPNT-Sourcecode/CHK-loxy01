using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            if (skus == "A")
                return 50;
            else if (skus == "B")
                return 30;
            else
                return -1;
        }
    }
}


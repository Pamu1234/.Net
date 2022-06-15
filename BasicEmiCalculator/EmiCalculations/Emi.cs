namespace EmiCalculations
{
    public class Emi
    {
        public static string EmiCalculatorForTwelveMonths(long totalAmount, long Downpayment)
        {
            long loanAmount = totalAmount - Downpayment;
            long emiAmount = loanAmount/12;
            
            return $"Total EMI amount is {emiAmount}, for yearly";
        }

        public static string EmiCalculatorForSixMonths(long totalAmount, long Downpayment)
        {
            long loanAmount = totalAmount - Downpayment;
            long emiAmount = loanAmount / 6;

            return $"Total EMI amount is {emiAmount}, for 6 months.";
        }

        public static string EmiCalculatorForThreeMonths(long totalAmount, long Downpayment)
        {
            long loanAmount = totalAmount - Downpayment;
            long emiAmount = loanAmount / 3;

            return $"Total EMI amount is {emiAmount}, for 3 months.";
        }

    }
}
using EmiCalculations;

Console.WriteLine("Enter product price:");
long totalAmount = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter down payment:");
long emiAmount = Convert.ToInt32(Console.ReadLine());

Console.WriteLine(Emi.EmiCalculatorForTwelveMonths(totalAmount, emiAmount));
Console.WriteLine(Emi.EmiCalculatorForSixMonths(totalAmount, emiAmount));
Console.WriteLine(Emi.EmiCalculatorForThreeMonths(totalAmount, emiAmount));
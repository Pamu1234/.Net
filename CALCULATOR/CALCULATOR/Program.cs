// See https://aka.ms/new-console-template for more information
using functions;
Console.WriteLine("Enter first number :");
int num1=Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter operator :");
string opr = Console.ReadLine();

Console.WriteLine("Enter second number :");
int num2=Convert.ToInt32(Console.ReadLine());

switch(opr)
{
    case "+":
        var result = Class1.Addition(num1, num2);
        Console.WriteLine(result);
        break;

    case "-":
         result = Class1.Subtraction(num1, num2);
        Console.WriteLine(result);
        break;

    case "*":
        result = Class1.Multiplication(num1, num2);
        Console.WriteLine(result);
        break;

    case "/":
        result = Class1.Division(num1, num2);
        Console.WriteLine(result);
        break;

    case "%":
        result = Class1.Modulus(num1, num2);
        Console.WriteLine(result);
        break;

        default:
        Console.WriteLine("invalid input");
        break;
}

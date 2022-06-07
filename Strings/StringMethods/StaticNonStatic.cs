namespace StringMethods
{
    public class StaticNonStatic
    {

        public static void Stringmethods()
        {
            string greeting = "Hello from static method";
            Console.WriteLine(greeting);
        }

        public  void Stringmethods2()
        {
            string greeting = "Hello from non-static method";
            Console.WriteLine(greeting);
        }

        public static void Concatination()
        {
            string firstName = "Parmeshwar";
            string lastName = "Sawrate";
            string name = $"My full name is: {firstName} {lastName}";
            Console.WriteLine(name);
        }

    }
}
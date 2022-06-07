namespace StringMethodsWithExamples
{
    public class StringOtherMethods
    {
        public static void StringLength()
        {
            string txt = "If we hard work we can acheive any thing.";
            Console.WriteLine("The length of the txt string is: " + txt.Length);
        }

        public static void StringToUpperCase()
        {
            string txt = "Hello World";
            Console.WriteLine("ToUpper() method changes whole string to upper case: " + txt.ToUpper());
        }

        public static void StringToLowerCase()
        {
            string txt = "Hello World";
            Console.WriteLine("ToLower() method changes whole string to lower case: " + txt.ToLower());
        }

        public  void AccessStrings()
        {
            string txt = "Hello World";
            Console.WriteLine("By using AccessStrings() we can access the characters in a string :  " + txt[1]);
        }
    }
}
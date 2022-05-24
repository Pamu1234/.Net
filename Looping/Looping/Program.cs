// See https://aka.ms/new-console-template for more information

//Creating an aaray and acces it's element by using for loop.

string[] bike = { "Jawa", "Bullet", "Splendor", "Ktm" };

for (int i = 0; i < bike.Length ; i++)
{
    Console.WriteLine(bike[i]);

}


// basic program to check even and odd numbers
for (int i = 0; i < 100; i++)
{
    if (i%2==0)
    {
        Console.WriteLine(i + " is a even number ");
    }
    else
    {
        Console.WriteLine(i + " is odd number");
    }
}
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {

        Console.Write("Enter your name: ");
        var name = Console.ReadLine();
        Console.Write("Enter your age: ");
        var age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Your name is {0} and age is {1}", name, age);
        Console.Write("Enter your birthday: ");
        var birthdate = Console.ReadLine();
        Console.WriteLine("Your birthday is {0}", birthdate);

    }


}
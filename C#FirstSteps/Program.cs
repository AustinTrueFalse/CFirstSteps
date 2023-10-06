using System;
using System.Drawing;
using System.Globalization;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        (string name, string lastname, int age, string[] petsArray, string[] colorsArray) User;

        Console.WriteLine("Введите имя");

        User.name = Console.ReadLine();

        Console.WriteLine("Введите фамилию");

        User.lastname = Console.ReadLine();

        User.age = checkCount("Age");

        Console.WriteLine("У вас есть питомец? (Y/N)");

        var hasPet = Console.ReadLine();

        if (hasPet == "Y")
        {
            var tempPet = checkCount("Pet");

            User.petsArray = new string[tempPet];

            Console.WriteLine("Введите имена питомцев");

            for (int i = 0; i < User.petsArray.Length; i++)
            {
                User.petsArray[i] = Console.ReadLine();
            }
        }
        else
        {
            User.petsArray = new string[0];
        }

        var tempColor = checkCount("Color");

        User.colorsArray = new string[tempColor];

        Console.WriteLine("Введите любимые цвета");

        for (int i = 0; i < User.colorsArray.Length; i++)
        {
            User.colorsArray[i] = Console.ReadLine();
        }

        

        



    }

    static int checkCount(string methType)
    {
        int checkedCount = 0;

        while (checkedCount == 0)
        {
            if (methType == "Age")
            {
                Console.WriteLine("Введите возраст");
            }
            if (methType == "Pet")
            {
                Console.WriteLine("Введите кол-во питомцев");
            }
            if (methType == "Color")
            {
                Console.WriteLine("Введите кол-во цветов");
            }

            var temp = Console.ReadLine();

            int checkedNumber;

            checkNum(temp, out checkedNumber);

            checkedCount = checkedNumber;
        }

        return checkedCount;
    }

    
        static bool checkNum(string num, out int checkedNum)
        {

            if (int.TryParse(num, out int intnum))
            {
                if (intnum > 0)
                {
                    checkedNum = intnum;
                    return false;
                }
            }
            {
                Console.WriteLine("Введите число больше 0");
                checkedNum = 0;
                return true;
            }
        }

    }


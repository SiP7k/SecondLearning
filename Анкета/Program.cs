using System;

class Program
{
    static void Main(string[] args)
    {
        ShowInfo(FillUserInfo());
    }
    static (string name, string lastName, int age, string[] namesOfPets, string[] favColors) FillUserInfo()
    {
        (string name, string lastName, int age, bool hasPet, int numberOfPets, string[] namesOfPets, int numberFavColors, string[] favColors) User;
        Console.WriteLine("Введите ваше имя:");
        User.name = Console.ReadLine();
        Console.WriteLine("Введите вашу фамилию:");
        User.lastName = Console.ReadLine();
        Console.WriteLine("Введите ваш возраст:");
        User.age = HandleTheInput();
        Console.WriteLine("У вас есть питомец? Да/Нет");

        if (Console.ReadLine().ToLower() == "да")
        {
            User.hasPet = true;
            Console.WriteLine("Введите количество питомцев:");
            User.numberOfPets = HandleTheInput();
        }
        else
        {
            User.hasPet = false;
            User.numberOfPets = 0;
        }
        User.namesOfPets = GetPetsNames(User.numberOfPets);
        Console.WriteLine("Введите количество ваших любимых цветов:");
        User.numberFavColors = HandleTheInput();
        User.favColors = GetFavColors(User.numberFavColors);
        var result = (User.name, User.lastName, User.age, User.namesOfPets, User.favColors);
        return result;
    }
    static string[] GetPetsNames(int numberOfPets)
    {
        string[] namesOfPets = new string[numberOfPets];

        for (int i = 0; i < numberOfPets; i++)
        {
            Console.WriteLine($"Введите кличку вашего {i+1}-го питомца:");
            namesOfPets[i] = Console.ReadLine();
        }
        return namesOfPets;
    }
    static string[] GetFavColors(int numberFavColors)
    {
        string[] favColors = new string[numberFavColors];

        for (int i = 0; i < numberFavColors; i++)
        {
            Console.WriteLine($"Введите название вашего {i+1}-го любимого цвета:");
            favColors[i] = Console.ReadLine();
        }
        return favColors;
    }
    static bool CheckInput(string input)
    {
        if (Int32.TryParse(input, out int result) && result >= 0 && result <120)
        {
            return true;
        }
        return false;
    }
    static void PrintError()
    {
        Console.WriteLine("Неправильный ввод данных!");
    }
    static int HandleTheInput()
    {
        string userInput = Console.ReadLine();

        while (!CheckInput(userInput))
        {
            PrintError();
            userInput = Console.ReadLine();
        }
        return Convert.ToInt32(userInput);
    }
    static void ShowInfo((string name, string lastName, int age, string[] namesOfPets, string[] favColors) User)
    {
        Console.Clear();
        Console.WriteLine("Данные о пользователе:\n");
        Console.WriteLine("Имя: " + User.name);
        Console.WriteLine("Фамилия: " + User.lastName);
        Console.WriteLine("Возраст: " + User.age);

        if (User.namesOfPets.Length>0)
        {
            Console.WriteLine("\nВаши питомцы:");

            foreach (var name in User.namesOfPets)
            {
                Console.Write(name + " ");
            }
        }
        else
        {
            Console.WriteLine("\nУ вас нет питомцев, СРОЧНО ЗАВЕДИТЕ!");
        }
        Console.WriteLine("\n\nВаши любимые цвета:");

        foreach (var color in User.favColors)
        {
            Console.Write(color + " ");
        }
        Console.WriteLine();
        Console.ReadKey();
    }
}
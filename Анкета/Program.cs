using System;

class MainClass
{
	public static void Main(string[] args)
	{
		Console.Write("Введите ваше имя:");
		string name = Console.ReadLine();
		Console.Write("\nВведите ваш возраст:");
		int age  = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine($"\nВаше имя - {name}, ваш возраст - {age}");
		Console.Write("Введите дату вашего рождения");
		string date = Console.ReadLine();
		Console.WriteLine($"Ваша дата рождения - {date}");
	}
}
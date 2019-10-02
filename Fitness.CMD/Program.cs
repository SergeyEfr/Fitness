using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly );
            Console.WriteLine(resourceManager.GetString("Hello", culture));
             

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

           

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол ");
                var gender = Console.ReadLine();

                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");
                var birthDate = ParseDateTime("дата рождения");
                userController.SetNewUserData(gender, birthDate, weight, height);

                
            }
            Console.WriteLine(userController.CurrentUser);
            while (true)
            {
                
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести приём пищи");
                Console.WriteLine("А - ввести упражнение");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;

                }
                Console.ReadLine();
            }
            
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();

            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("окончание упражнения");
            var energy = ParseDouble("расход энергии в минуту");
            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();

            
            var weight = ParseDouble("вес порции");
            var calories = ParseDouble("калорийность");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");
            var product = new Food(food, calories, prots, fats, carbs);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime ValueDate;
            while (true)
            {

                Console.WriteLine($"Введите {value} (dd.MM.YYYY): ");
                if (DateTime.TryParse(Console.ReadLine(), out ValueDate))
                {
                    break;
                }
                else Console.WriteLine($"Неверный формат {value}");
            }

            return ValueDate;
        }

        private static double ParseDouble(string name) {
            while (true)
            {

                Console.Write($"Введите {name} : ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                
                }
                else Console.WriteLine($"Неверный формат поля {name}");
            }
        }
    }
}

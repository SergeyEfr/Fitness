﻿using Fitness.BL.Controller;
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
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол ");
                var gender = Console.ReadLine();

                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");
                var birthDate = ParseDateTime();
                userController.SetNewUserData(gender, birthDate, weight, height);

                
            }
            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести приём пищи");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
               var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }
            Console.ReadLine();

            
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

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {

                Console.WriteLine("Введите дату рождения (dd.MM.YYYY): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else Console.WriteLine("Неверный формат даты рождения");
            }

            return birthDate;
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

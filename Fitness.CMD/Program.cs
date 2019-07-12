using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение Fitness");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

           

            var userController = new UserController(name);
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
            Console.ReadLine();

            
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
                else Console.WriteLine($"Неверный формат {name}"+"a");
            }
        }
    }
}

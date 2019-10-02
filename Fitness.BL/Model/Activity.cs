using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        //Виды активности выступают в качестве справочника:
        //1.Название вида активности
        public string Name { get; }
        //2.Количество сжигаемых калорий в единицу времени
        public double CaloriesPerMinute { get; }

        public Activity(string name, double caloriesPerMinute)
        {
            //Проверка
             
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }
        public override string ToString()
        {
            return ("Такое упражнение:"+Name);
        }
    }
}

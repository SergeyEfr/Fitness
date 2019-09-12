using System;


namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        public double Proteins { get; }
        public double Fats { get; }
        public double Carbohydrates { get; }
        public double Calories { get; }
        



        public Food(string name) : this(name, 0, 0, 0, 0)
        {
            
        }
        //Вычисляется в расчёте на 1 гр продукта( деление на 100гр)
        public Food(string name, double calories, double proteins, double fats, double cabrohydrates)
        {
            Name = name;
            Proteins = proteins/100.0;
            Fats = fats/100.0;
            Carbohydrates = cabrohydrates/100.0;
            Calories = calories/100.0;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}

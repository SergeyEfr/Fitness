using System;


namespace Fitness.BL.Model
{
   public class Food
    {
        public string Name { get; }
        public double Proteins { get; }
        public double Fats { get; }
        public double Carbohydrates { get; }
        //Калории за 100 гр продукта
        public double Calories { get; }



        public Food(string name) : this(name, 0, 0, 0, 0)
        {
            
        }

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

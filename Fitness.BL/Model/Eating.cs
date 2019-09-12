using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    [Serializable]
    //Приём пищи
    public class Eating
    {
        //Момент приёма пищи
        public DateTime Moment { get; }
        //Список продуктов и количество(вес)
        public Dictionary <Food, double> Foods { get; }
        //Пользователь
        public User User { get; }
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if(product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }

        }
    }
}

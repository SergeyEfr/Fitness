using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        //Время начала упражнения 
        public DateTime Start { get; }
        //Время конца упржанения
        public DateTime Finish { get; }
        //Вид упражнения
        public Activity Activity { get; }
        //Кто делал упражнение
        public User User { get; }
        public Exercise (DateTime start, DateTime finish, Activity activity, User user)
        {
            //Проверка

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}

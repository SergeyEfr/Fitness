using System;


namespace Fitness.BL.Model
{
    [Serializable]
    public class User
    {
        #region Набор свойств
        public string Name { get; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get { return (DateTime.Now.Year - BirthDate.Year); } }
        #endregion
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым", nameof(name));
            }
            
            
             if (gender == null)
              {
                    throw new ArgumentNullException("Пол не может быть null", nameof(gender));
              }  
            
            
                if (birthDate < DateTime.Parse("01.01.1900"))
                {
                    throw new ArgumentNullException("Это фитнесс-приложение не для долгожителей ", nameof(birthDate));
                }
            
            
            if (birthDate >= DateTime.Now)
            {
                throw new ArgumentNullException("Это приложение не для прибывших из будущего",
                    nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentNullException("Вес должен быть больше нуля", nameof(weight));
            }
            if(height <= 0)
            {
                throw new ArgumentNullException("Рост должен быть больше нуля", nameof(height));
            }
           
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public User(string name)
        {
           
            
              if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException("Имя не может быть пустым", nameof(name));
                }
            
            Name = name;
        }
        public override string ToString()
        {
            return Name+ " "+ Age;
         
        }
    }
}

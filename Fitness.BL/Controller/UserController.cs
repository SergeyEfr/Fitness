using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    public class UserController: ControllerBase

    {
        private const string USERS_FILE_NAME = "users.dat";
        public List <User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
       
        public UserController(string userName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName))
                {
                    throw new ArgumentNullException("Сделайте, пожалуйста, имя пользователя не пустым", nameof(userName));
                }
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
            
           
        }
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
            
            
        }
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
    }
}

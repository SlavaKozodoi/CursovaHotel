using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace CursovaFinal
{
    public class UserManager
    {
        private List<User> users;
        private string dataFilePath = "user.json";

        public UserManager()
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                if (File.Exists(dataFilePath))
                {
                    string json = File.ReadAllText(dataFilePath);
                    users = JsonConvert.DeserializeObject<List<User>>(json);
                }
                else
                {
                    users = new List<User>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла users.json: {ex.Message}");
            }
        }

        private void SaveUsers()
        {
            string json = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(dataFilePath, json);
        }

        public bool ValidateUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            User user = users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                return true;
            }

            return false;
        }

        public void AddUser(User newUser)
        {
            users.Add(newUser);
            SaveUsers();
        }
    }
}

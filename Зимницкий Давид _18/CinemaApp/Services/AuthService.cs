using CinemaApp.Models;
using System.IO;
using System.Text.Json;

namespace CinemaApp.Services
{
    public class AuthService
    {
        public List<UserModel> LoadUsers()
        {
            string json =
                File.ReadAllText(
                    "Data/users.json"
                );

            return JsonSerializer.Deserialize
                <List<UserModel>>(json);
        }

        public UserModel Login(
            string login,
            string password)
        {
            var users = LoadUsers();

            return users.FirstOrDefault(
                u =>
                u.Login == login &&
                u.Password == password
            );
        }
    }
}
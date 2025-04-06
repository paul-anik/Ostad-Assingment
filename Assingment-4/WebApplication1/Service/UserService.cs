using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var response = await _httpClient.GetStringAsync("https://dummyjson.com/users");
            var jsonDocument = JsonDocument.Parse(response);
            var users = jsonDocument.RootElement.GetProperty("users");

            var userList = new List<User>();
            foreach (var user in users.EnumerateArray())
            {
                userList.Add(new User
                {
                    Id = user.GetProperty("id").GetInt32(),
                    FirstName = user.GetProperty("firstName").GetString(),
                    LastName = user.GetProperty("lastName").GetString(),
                    Email = user.GetProperty("email").GetString(),
                    Age = user.GetProperty("age").GetInt32()
                });
            }

            return userList;
        }
    }
}

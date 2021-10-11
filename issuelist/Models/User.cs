using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace IssueListKanban.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public UserAddress Address { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public List<User> GetUsers()
        {
            List<User> userList = new List<User>();
            List<User> userListResult = new List<User>();

            using (var client = new HttpClient())
            {
                var usersResponse = client.GetAsync("https://jsonplaceholder.typicode.com/users").Result;

                if (usersResponse.IsSuccessStatusCode)
                {
                    var userResponseContent = usersResponse.Content;
                    string usersResponseString = userResponseContent.ReadAsStringAsync().Result;
                    userList = JsonConvert.DeserializeObject<List<User>>(usersResponseString);
                }
            }

            for (int i = 0; i < userList.Count; i++)
            {
                User user = new User();
                user.Id = userList[i].Id;
                user.Name = userList[i].Name;
                user.UserName = userList[i].UserName;
                user.Address = userList[i].Address;
                user.Phone = userList[i].Phone;
                user.Website = userList[i].Website;
                userListResult.Add(user);
            }

            return userListResult;
        }
    }
}
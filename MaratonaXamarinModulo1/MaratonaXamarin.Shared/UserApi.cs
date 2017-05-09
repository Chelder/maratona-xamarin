using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaratonaXamarin.Shared
{
    public class UserApi
    {
        private readonly MobileServiceClient _client;
        public UserApi()
        {
            _client = new MobileServiceClient("http://hellomonkeys.azurewebsites.net/");            
        }

        public async Task<List<User>> ListAsync(Developer developer)
        {
            var users = await _client.InvokeApiAsync<Developer, List<User>>("monkeys", developer);

            return users;
        }
    }
}

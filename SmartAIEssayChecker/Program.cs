using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SmartAIEssayChecker.Brokers.Storages;
using SmartAIEssayChecker.Models.Essays;
using SmartAIEssayChecker.Models.Users;

namespace MyNamespace;

internal class Program
{
    static async Task Main(string[] args)
    {
        var users = new User()
        {
            Id = Guid.NewGuid(),
            Name = "Sobir"
        };
        
        using (var storageBroker = new StorageBroker())
        {
            IQueryable<User> data = storageBroker.SelectAllUsers();
            foreach (var userData in data)
            {
                Console.WriteLine(userData.Name);
            }
            
        }


    }
}


using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MyNamespace.Services.Users;
using SmartAIEssayChecker.Brokers.Storages;
using SmartAIEssayChecker.Models.Essays;
using SmartAIEssayChecker.Models.Users;
using SmartAIEssayChecker.Models.Users.Exceptions;

namespace MyNamespace;

internal class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            var userService = new UserService();
            User user = null;
            var persistedClient = await userService.AddUserAsync(user);
        }
        catch (NullUserException nullUserException)
        {
            Console.WriteLine(nullUserException.Message);
        }
       
    }
}


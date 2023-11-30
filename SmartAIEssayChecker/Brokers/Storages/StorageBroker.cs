using EFxceptions;
using Microsoft.EntityFrameworkCore;
using SmartAIEssayChecker.Models.Essays;
using SmartAIEssayChecker.Models.Feedbacks;
using SmartAIEssayChecker.Models.Users;

namespace SmartAIEssayChecker.Brokers.Storages;

public class StorageBroker : EFxceptionsContext
{
    private DbSet<User> Users { get; set; }
    private DbSet<Essay> Essays { get; set; }
    private DbSet<Feedback> Feedbacks { get; set; }

    public async Task<User> InsertClientAsync(User user)
    {
        await this.Users.AddAsync(user);
        await this.SaveChangesAsync();
        return user;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Data source = SmartAIChecker.db";
        optionsBuilder.UseSqlite(connectionString);
    }
}
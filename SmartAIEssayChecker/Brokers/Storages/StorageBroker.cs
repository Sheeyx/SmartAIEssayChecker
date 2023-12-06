using EFxceptions;
using Microsoft.EntityFrameworkCore;
using SmartAIEssayChecker.Models.Essays;
using SmartAIEssayChecker.Models.Feedbacks;
using SmartAIEssayChecker.Models.Users;

namespace SmartAIEssayChecker.Brokers.Storages;

 public partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.EnsureCreated();
        }
        private async ValueTask<T> InsertAsync<T>(T @object)
        {
            var broker = new StorageBroker(this.configuration);
            broker.Entry(@object).State = EntityState.Added;
            await broker.SaveChangesAsync();

            return @object;
        }

        private IQueryable<T> SelectAll<T>() where T : class
        {
            var broker = new StorageBroker(this.configuration);

            return broker.Set<T>();
        }

        private async ValueTask<T> SelectAsync<T>(params object[] objectId) where T : class
        {
            var broker = new StorageBroker(this.configuration);

            return await broker.FindAsync<T>(objectId);
        }

        private async ValueTask<T> UpdateAsync<T>(T @object)
        {
            var broker = new StorageBroker(this.configuration);
            broker.Entry(@object).State = EntityState.Modified;
            await broker.SaveChangesAsync();

            return @object;
        }

        private async ValueTask<T> DeleteAsync<T>(T @object)
        {
            var broker = new StorageBroker(this.configuration);
            broker.Entry(@object).State = EntityState.Deleted;
            await broker.SaveChangesAsync();

            return @object;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = this.configuration.GetConnectionString(name: "DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        IQueryable<Feedback> IStorageBroker.SelectAllFeedbackAsync()
        {
            throw new NotImplementedException();
        }

        ValueTask<Feedback> IStorageBroker.SelectFeedbackByIdAsync(Guid feedbackId)
        {
            throw new NotImplementedException();
        }
    }
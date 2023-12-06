using MyNamespace.Brokers.Loggings;
using SmartAIEssayChecker.Brokers.Storages;
using SmartAIEssayChecker.Models.Essays;

namespace MyNamespace.Services.Essays;

public partial class EssayService : IEssayService
{
    private readonly IStorageBroker storageBroker;
    private readonly ILoggingBroker loggingBroker;

    public EssayService(
        IStorageBroker storageBroker,
        ILoggingBroker loggingBroker)
    {
        this.storageBroker = storageBroker;
        this.loggingBroker = loggingBroker;
    }

    public async ValueTask<Essay> AddEssayAsync(Essay essay)
    {
        try
        {
            ValidateEssayNotNull(essay);

            return await this.storageBroker.InsertEssayAsync(essay);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        
            return default(Essay);
        }
    }



    public IQueryable<Essay> RetrieveAllEssays() =>
        this.storageBroker.SelectAllEssays();

    public async ValueTask<Essay> RetrieveEssayByIdAsync(Guid essayId)
    {
        try
        {
            ValidateEssayId(essayId);

            Essay essay = await this.storageBroker.SelectEssayByIdAsync(essayId);

            return essay;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        
            return default(Essay); 
        }
    }

    public async ValueTask<Essay> RemoveEssayAsync(Guid essayId)
    {
        ValidateEssayId(essayId);

        Essay essay = await this.storageBroker.SelectEssayByIdAsync(essayId);


        return await this.storageBroker.DeleteEssayAsync(essay);
    }
}
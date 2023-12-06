using SmartAIEssayChecker.Models.Essays;

namespace SmartAIEssayChecker.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<Essay> InsertEssayAsync(Essay essay);
    IQueryable<Essay> SelectAllEssays();
    ValueTask<Essay> SelectEssayByIdAsync(Guid essayId);
    ValueTask<Essay> DeleteEssayAsync(Essay essay);
}
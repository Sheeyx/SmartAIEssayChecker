using Microsoft.EntityFrameworkCore;
using SmartAIEssayChecker.Models.Essays;

namespace SmartAIEssayChecker.Brokers.Storages;

public partial class StorageBroker
{
    public DbSet<Essay> Essays { get; set; }

    public async ValueTask<Essay> InsertEssayAsync(Essay essay) =>
        await InsertAsync(essay);

    public IQueryable<Essay> SelectAllEssays() =>
        SelectAll<Essay>().AsQueryable();

    public async ValueTask<Essay> SelectEssayByIdAsync(Guid essayId) =>
        await SelectAsync<Essay>(essayId);

    public async ValueTask<Essay> DeleteEssayAsync(Essay essay) =>
        await DeleteAsync(essay);
}
using Microsoft.EntityFrameworkCore;
using SmartAIEssayChecker.Models.Feedbacks;

namespace SmartAIEssayChecker.Brokers.Storages;

public partial class StorageBroker
{
    public DbSet<Feedback> Feedbacks { get; set; }

    public async ValueTask<Feedback> InsertFeedbackAsync(Feedback feedback) =>
        await InsertAsync(feedback);

    public IQueryable<Feedback> SelectAllFeedbacks() =>
        SelectAll<Feedback>().AsQueryable();

    public async ValueTask<Feedback> SelectFeedbackById(Guid feedbackId) =>
        await SelectAsync<Feedback>(feedbackId);

    public async ValueTask<Feedback> DeleteFeedbackAsync(Feedback feedback) =>
        await DeleteAsync(feedback);
}
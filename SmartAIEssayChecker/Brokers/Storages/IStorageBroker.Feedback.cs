using SmartAIEssayChecker.Models.Feedbacks;

namespace SmartAIEssayChecker.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<Feedback> InsertFeedbackAsync(Feedback feedback);
    IQueryable<Feedback> SelectAllFeedbackAsync();
    ValueTask<Feedback> SelectFeedbackByIdAsync(Guid feedbackId);
    ValueTask<Feedback> DeleteFeedbackAsync(Feedback feedback);
}
using SmartAIEssayChecker.Models.Feedbacks;

namespace MyNamespace.Services.Feedbacks;

public interface IFeedbackService
{
    ValueTask<Feedback> AddFeedbackAsync(Feedback feedback); 
    IQueryable<Feedback> RetrieveFeedbacksAsync();
    ValueTask<Feedback> RetrieveFeedbackByIdAsync(Guid feedbackId);
    ValueTask<Feedback> RemoveFeedbackAsync(Guid feedbackId);
}
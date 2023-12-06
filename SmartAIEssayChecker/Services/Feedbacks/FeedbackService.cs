using MyNamespace.Brokers.Loggings;
using SmartAIEssayChecker.Brokers.Storages;
using SmartAIEssayChecker.Models.Feedbacks;

namespace MyNamespace.Services.Feedbacks;

public partial class FeedbackService : IFeedbackService
{
    private readonly IStorageBroker storageBroker;
    private readonly ILoggingBroker loggingBroker;

    public FeedbackService(
        IStorageBroker storageBroker,
        ILoggingBroker loggingBroker)
    {
        this.storageBroker = storageBroker;
        this.loggingBroker = loggingBroker;
    }

    public async ValueTask<Feedback> AddFeedbackAsync(Feedback feedback)
    {
        try
        {
            ValidateFeedbackNotNull(feedback);

            return await this.storageBroker.InsertFeedbackAsync(feedback);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        
            return default(Feedback); 
        }
    }


    public IQueryable<Feedback> RetrieveFeedbacksAsync() =>
        this.storageBroker.SelectAllFeedbackAsync();

    public async ValueTask<Feedback> RetrieveFeedbackByIdAsync(Guid feedbackId)
    {
        try
        {
            ValidateFeedbackId(feedbackId);

            Feedback feedback = await this.storageBroker.SelectFeedbackByIdAsync(feedbackId);

            return feedback;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        
            return default(Feedback); 
        }
    }

    
    public async ValueTask<Feedback> RemoveFeedbackAsync(Guid feedbackId)
    {
        try
        {
            ValidateFeedbackId(feedbackId);

            Feedback feedback = await this.storageBroker.SelectFeedbackByIdAsync(feedbackId);

            return await this.storageBroker.DeleteFeedbackAsync(feedback);
        }
        catch (Exception ex)
        {
            // Handle the exception or log it
            Console.WriteLine($"An error occurred: {ex.Message}");
        
            // Optionally, return a default value or rethrow the exception
            return default(Feedback); // Return a default value (null for reference types)
            // OR
            // throw; // Rethrow the exception to let it propagate further
        }
    }


}
using SmartAIEssayChecker.Models.Feedbacks;
using SmartAIEssayChecker.Models.Users;

namespace SmartAIEssayChecker.Models.Essays;

public class Essay
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Feedback Feedback { get; set; }
}
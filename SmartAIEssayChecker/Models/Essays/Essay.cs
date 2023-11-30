using SmartAIEssayChecker.Models.Users;

namespace SmartAIEssayChecker.Models.Essays;

public class Essay
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid UserId { get; set; }
}
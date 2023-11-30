using SmartAIEssayChecker.Models.Essays;

namespace SmartAIEssayChecker.Models.Users;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Essay> Essays { get; set; }
}
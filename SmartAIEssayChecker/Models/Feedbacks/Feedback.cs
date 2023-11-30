namespace SmartAIEssayChecker.Models.Feedbacks;

public class Feedback
{
    public Guid Id { get; set; }
    public float Mark { get; set; }
    public string Comment { get; set; }
    public Guid EssayId { get; set; }
}
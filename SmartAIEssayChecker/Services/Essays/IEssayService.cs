using SmartAIEssayChecker.Models.Essays;

namespace MyNamespace.Services.Essays;

public interface IEssayService
{
       
    public ValueTask<Essay> AddEssayAsync(Essay essay);   
    public IQueryable<Essay> RetrieveAllEssays();
    public ValueTask<Essay> RetrieveEssayByIdAsync(Guid essayId);
    public ValueTask<Essay> RemoveEssayAsync(Guid essay);
} 
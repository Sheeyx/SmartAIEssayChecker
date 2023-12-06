using SmartAIEssayChecker.Models.Essays;
using SmartAIEssayChecker.Models.Essays.Exceptions;

namespace MyNamespace.Services.Essays;

public partial class EssayService
{
    private void ValidationOnAdd(Essay essay)
    {
        ValidateEssayNotNull(essay);

        Validate(
            (Rule: IsInvalid(essay.Id), Parameter: nameof(essay.Id)),
            (Rule: IsInvalid(essay.Id), Parameter: nameof(essay.Content)));
    }

    private void ValidateEssayId(Guid essayId)
    {
        Validate((Rule: IsInvalid(essayId), Parameter: nameof(essayId)));
    }

    private static dynamic IsInvalid(Guid essayId) => new
    {
        Condition = essayId == default,
        Message = "Id is required"
    };

    private static dynamic IsInvalid(string text) => new
    {
        Condition = String.IsNullOrWhiteSpace(text) == default,
        Message = "Text is required"
    };

    private static void ValidateEssayNotNull(Essay essay)
    {
        if (essay is null)
        {
            throw new NullEssayException();
        }
    }
    private static void Validate(params (dynamic Rule, string Parameter)[] validations)
    {
        var invalidEssayException = new InvalidEssayException();

        foreach ((dynamic rule, string parameter) in validations)
        {
            if (rule.Condition)
            {
                invalidEssayException.UpsertDataList(
                    key: parameter,
                    value: rule.Message);
            }
        }
        invalidEssayException.ThrowIfContainsErrors();
    }
}
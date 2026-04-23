using Causely.Application.LogService.Dtos;
using FluentValidation.Results;
using ValidationException = Causely.Application.Common.Exceptions.ValidationException;

namespace Causely.Application.LogService.Rules;

public class LogBusiness
{
    public void CheckLogsMustExist(ICollection<LogItemDto>? logs)
    {
        if (logs is { Count: > 0 })
            return;

        throw new ValidationException([
            new ValidationFailure("Logs", "Logs must contain at least one log item.")
        ]);
    }
}

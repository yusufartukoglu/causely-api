namespace Causely.Application.LogService.Commands.Ingest;

public class IngestLogValidation : AbstractValidator<IngestLogRequest>
{
    public IngestLogValidation()
    {
        RuleFor(v => v.Logs)
            .NotEmpty();

        RuleForEach(v => v.Logs).ChildRules(log =>
        {
            log.RuleFor(v => v.Timestamp)
                .NotEmpty();

            log.RuleFor(v => v.Service)
                .NotEmpty()
                .MaximumLength(200);

            log.RuleFor(v => v.Environment)
                .NotEmpty()
                .MaximumLength(100);

            log.RuleFor(v => v.Level)
                .NotEmpty()
                .MaximumLength(50);

            log.RuleFor(v => v.Message)
                .NotEmpty()
                .MaximumLength(4000);

            log.RuleFor(v => v.ExceptionType)
                .MaximumLength(500);

            log.RuleFor(v => v.Endpoint)
                .MaximumLength(500);

            log.RuleFor(v => v.TraceId)
                .MaximumLength(200);
        });
    }
}

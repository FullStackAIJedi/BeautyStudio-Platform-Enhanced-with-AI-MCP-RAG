namespace Identity.Application.Common.Behaviours;

using MediatR;
using FluentValidation;

using Identity.Application.Common.Exceptions;

public class RequestValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> validators;

    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        => this.validators = validators;

    public Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!this.validators.Any())
            return next();

        var context = new ValidationContext<TRequest>(request);

        var errors = this.validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        if (errors.Count != 0)
            throw new ModelValidationException(errors);

        return next();
    }
}
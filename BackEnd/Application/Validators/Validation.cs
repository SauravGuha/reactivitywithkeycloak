
using FluentValidation;
using MediatR;

namespace Application.Validators
{
    /// <summary>
    /// Validation middleware for MediatR pipeline
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class Validation<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public Validation(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                foreach (var validator in validators)
                {
                    await validator.ValidateAndThrowAsync(request);
                }
            }

            return await next();
        }
    }
}
using BlogStar.Shared.Wrapper.Abstract;
using FluentValidation;
using MediatR;

namespace BlogStar.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse> where TRequest : IRequest<IResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(
                    _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults
                    .Where(v => v.Errors.Any())
                    .SelectMany(r => r.Errors)
                    .ToList();
            }

            return await next();
        }
    }
}

using BlogStar.Application.Common.Interfaces;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace BlogStar.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest> where TRequest : IRequest
    {
        private readonly ILogger _logger;

        private readonly ICurrentUserService _currentUserService;

        public LoggingBehavior(ILogger logger, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUserService.GetCurrentUser();
            _logger.LogInformation("BlogStar: {Name} {@UserId} {@UserName} {@Request}",
                typeof(TRequest).Name,
                currentUser.Id,
                currentUser.UserName,
                request);
        }
    }
}

using BlogStar.Application.Repositories.Authentication.Queries;
using BlogStar.Shared.Constants;
using BlogStar.Shared.Dtos;
using BlogStar.Shared.Requests.Authentication.Queries;
using BlogStar.Shared.Wrapper.Abstract;
using BlogStar.Shared.Wrapper.Concrete;
using MediatR;

namespace BlogStar.Application.Features.Authentication.Queries.GetProfile
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQueryRequest,IResponse>
    {
        private readonly IAuthQueryRepository _query;
        public GetProfileQueryHandler(IAuthQueryRepository query)
        {
            _query = query;
        }

        public async Task<IResponse> Handle(GetProfileQueryRequest request,CancellationToken cancellationToken)
        {
            var user = await _query.GetUserByEmail(request.Email, cancellationToken);
            if(user == null)
            {
                return new ErrorResponse(ApiStatusCodes.NotFound, Messages.NoDataFound);
            }
            return new DataResponse<UserDTO>(user, ApiStatusCodes.Ok);
        }
    }
}

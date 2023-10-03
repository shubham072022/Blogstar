using BlogStar.Shared.Dtos;

namespace BlogStar.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        //this will be called only after login,register or on refreshtoken
        Task SetCurrentUser(LoggedInUserDTO user);

        //this will be called any time current user needed
        Task<LoggedInUserDTO> GetCurrentUser();
    }
}

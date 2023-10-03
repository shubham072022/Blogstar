using BlogStar.Application.Common.Interfaces;
using BlogStar.Shared.Dtos;

namespace BlogStar.Identity.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private LoggedInUserDTO loggedInUser;

        public CurrentUserService()
        {
        }

        public async Task SetCurrentUser(LoggedInUserDTO loggedInUser)
        {
            if(this.loggedInUser == null)
            {
                this.loggedInUser = new LoggedInUserDTO();
            }
            this.loggedInUser = loggedInUser;
        }

        public async Task<LoggedInUserDTO> GetCurrentUser()
        {
            if (this.loggedInUser == null)
            {
                this.loggedInUser = new LoggedInUserDTO();
            }
            return this.loggedInUser;
        }
    }
}

using Refit;
using Solution.Data.Models.UserModels;

namespace CustomersSite.Services
{
	public class UserApiClient : IUserApiClient
	{
        private readonly IUserApiClient _userApiClient;
        public UserApiClient(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }

        public Task<LiteUserDto> GetCurrentUser([Authorize("Bearer")] string token)
        {
            return _userApiClient.GetCurrentUser(token);
        }

        public async Task<LiteUserDto> Register(RegisterUserDto registerUser)
        {
            return await _userApiClient.Register(registerUser);
        }
    }
}

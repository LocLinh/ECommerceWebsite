using Solution.Data.Models.UserModels;

namespace CustomersSite.Services
{
	public class AuthApiClient : IAuthApiClient
	{
        private readonly IAuthApiClient _authApiClient;
        public AuthApiClient(IAuthApiClient authApiClient)
        {
            _authApiClient = authApiClient;
        }
        public async Task<string> GetToken(LoginUserDto loginUser)
		{
            var response = await _authApiClient.GetToken(loginUser);
            return response;
		}

    }
}

using Refit;
using Solution.Data.Models.UserModels;

namespace CustomersSite.Services
{
	public interface IUserApiClient 
	{
        [Get("/GetCurrentUser")]
        Task<LiteUserDto> GetCurrentUser([Authorize("Bearer")] string token);

        [Post("/Users")]
        Task<LiteUserDto> Register(RegisterUserDto registerUser);
    }
}

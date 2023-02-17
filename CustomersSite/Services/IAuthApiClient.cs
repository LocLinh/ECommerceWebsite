using Refit;
using Solution.Data.Models.UserModels;

namespace CustomersSite.Services
{
	public interface IAuthApiClient
	{
		[Post("/Auth")]
		Task<string> GetToken(LoginUserDto loginUser);
	}
}

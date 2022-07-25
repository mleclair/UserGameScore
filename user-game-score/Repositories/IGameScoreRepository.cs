using UserGameScore.Models;

namespace GameScore.Repositories
{
	public interface IGameScoreRepository : IDisposable
	{
		/// <summary>
		/// Gets a list of <see cref="UserGameScoreRecord"/> for the specified user.
		/// </summary>
		/// <param name="userId">Unique identifier of the user.</param>
		/// <returns>True when delete successful.</returns>
		IEnumerable<UserGameScoreRecord> GetUserGameScores(int userId);

		/// <summary>
		/// Creates a new <see cref="UserGameScoreRecord"/>.
		/// </summary>
		/// <param name="userGameScore"></param>
		/// <returns>True when create successful.</returns>
		bool CreateUserGameScore(int userId, string gameName);

		/// <summary>
		/// Updates and existing <see cref="UserGameScoreRecord"/>.
		/// </summary>
		/// <param name="userGameScore"></param>
		/// <returns>True when update successful.</returns>
		bool UpdateUserGameScore(UserGameScoreRecord userGameScore);

		/// <summary>
		/// Deletes and existing <see cref="UserGameScoreRecord"/>.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="gameName"></param>
		/// <param name="attemptNumber"></param>
		/// <returns>True when delete successful.</returns>
		bool DeleteUserGameScore(int userId, string gameName, int attemptNumber);
	}
}

using UserGameScore.Models;

namespace GameScore.Repositories
{
	/// <summary>
	/// Class <c>GameScoreRepository</c> manages user game score CRUD operations.
	/// </summary>
	public class GameScoreRepository : IGameScoreRepository
	{
		private bool disposedValue;

		/// <inheritdoc/>
		public IEnumerable<UserGameScoreRecord> GetUserGameScores(int userId)
		{
			//throw new NotImplementedException();

			return new List<UserGameScoreRecord>();
		}

		/// <inheritdoc/>
		public bool CreateUserGameScore(int userId, string gameName)
		{
			//throw new NotImplementedException();

			// Note: Since we are creating a new game, use an increment of max game attempt

			return true;
		}

		/// <inheritdoc/>
		public bool UpdateUserGameScore(UserGameScoreRecord userGameScore)
		{
			//throw new NotImplementedException();

			return true;
		}

		/// <inheritdoc/>
		public bool DeleteUserGameScore(int userId, string gameName, int attemptNumber)
		{
			//throw new NotImplementedException();

			return true;
		}

		/// <inheritdoc/>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects)
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ...Would depend on your save-game implementation ...
		// ~GameScoreRepository()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		/// <inheritdoc/>
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}

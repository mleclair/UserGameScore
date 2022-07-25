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
		public bool CreateUserGameScore(UserGameScoreRecord userGameScore)
		{
			//throw new NotImplementedException();

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
		// ~GameScoreRepository()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}

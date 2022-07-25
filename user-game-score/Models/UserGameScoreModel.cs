namespace UserGameScore.Models
{
	/// <summary>
	/// A record used to represent a particular state of a user's progress on a given game type.
	/// </summary>
	/// <param name="UserId">Unique identifier of a particular user.</param>
	/// <param name="GameName">Unique game name.</param>
	/// <param name="GameAttempt">Uniquely identifies a user's game.</param>
	/// <param name="Score">The current game score.</param>
	public record UserGameScoreRecord(int UserId, string GameName, int GameAttempt = 1, int Score = 0)
	{
		/// <summary>
		/// Unique identifier of the user.
		/// </summary>
		public int UserId = UserId;

		/// <summary>
		/// The unique name of the game played.
		/// </summary>
		public string GameName = GameName;

		/// <summary>
		/// The unique identifier of the game being played.
		/// </summary>
		public int GameAttempt = GameAttempt;

		/// <summary>
		/// The user''s current game score.
		/// </summary>
		public int Score = Score;

		/// <summary>
		/// When the record was received, server-side.
		/// </summary>
		public DateTime Timestamp = DateTime.UtcNow;
	}
}

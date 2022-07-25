namespace UserGameScore.Models
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="UserId"></param>
	/// <param name="GameName"></param>
	/// <param name="GameAttempt"></param>
	/// <param name="Score"></param>
	public record UserGameScoreRecord(int UserId, string GameName, int GameAttempt, int Score)
	{
		/// <summary>
		/// 
		/// </summary>
		public int UserId = UserId;

		/// <summary>
		/// 
		/// </summary>
		public string GameName = GameName;

		/// <summary>
		/// 
		/// </summary>
		public int GameAttempt = GameAttempt;

		/// <summary>
		/// 
		/// </summary>
		public int Score = Score;

		/// <summary>
		/// 
		/// </summary>
		public DateTime Timestamp = DateTime.UtcNow;
	}
}

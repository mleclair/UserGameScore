using GameScore.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using UserGameScore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IGameScoreRepository, GameScoreRepository>();
builder.Services.AddSwaggerGen(swagger =>
{
	swagger.EnableAnnotations();
});

var app = builder.Build();

IGameScoreRepository _gameScoreRepository;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var games = new[]
{
	"memory", "space-invaders"
};

using var scope = app.Services.CreateScope();
_gameScoreRepository = scope.ServiceProvider.GetRequiredService<IGameScoreRepository>();

app.MapGet("/usergamescores/{userId}",
	[SwaggerOperation(Summary = "Gets user game scores", Description = "Gets the latest score for all games of the provided user.")]
	(int userId) => {
		// TODO: Add validation
		return _gameScoreRepository.GetUserGameScores(userId);
})
.WithName("GetUserGameScores");

app.MapPost("/usergamescore/{userId}/{gameName}",
	[SwaggerOperation(Summary = "Creates new user game", Description = "Creates the initial game for the provided user and game.")]
	(int userId, string gameName) => {
		// TODO: Add validation
		return _gameScoreRepository.CreateUserGameScore(userId, gameName);
})
.WithName("PostUserGameScore");

app.MapPut("/usergamescore",
	[SwaggerOperation(Summary = "Updates user game score", Description = "Updates the current game score of the provided user and game.")]
	(UserGameScoreRecord userGameScore) => {
		// TODO: Add validation
		return _gameScoreRepository.UpdateUserGameScore(userGameScore);
})
.WithName("UpdateGameScore");

app.MapDelete("/usergamescore/{userId}/{gameName}/{attemptNumber}",
	[SwaggerOperation(Summary = "Delete user game score", Description = "Deletes the game score of the provided user and game.")]
	(int userId, string gameName, int attemptNumber) => {
		// TODO: Add validation
		return _gameScoreRepository.DeleteUserGameScore(userId, gameName, attemptNumber);
})
.WithName("DeleteUserGameScore");

app.Run();

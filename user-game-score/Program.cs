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
	[SwaggerOperation(Summary = "Gets user game scores", Description = "Gets the latest score all games of the provided user.")]
	(int userId) => {
	return _gameScoreRepository.GetUserGameScores(userId);
})
.WithName("GetUserGameScores");

app.MapPost("/usergamescore/{userId}",
	[SwaggerOperation(Summary = "Creates new user game", Description = "Creates the initial score for the provided user and game.")]
	(int userId) => {
	return _gameScoreRepository.CreateUserGameScore(new UserGameScoreRecord(userId, games[1], 1, 0));
})
.WithName("PostUserGameScore");

app.MapPut("/usergamescore/{userId}",
	[SwaggerOperation(Summary = "Updates user game score", Description = "Updates the current game score of the provided user and game.")]
	(int userId) => {
	return _gameScoreRepository.UpdateUserGameScore(new UserGameScoreRecord(userId, games[1], 1, 100));
})
.WithName("UpdateGameScore");

app.MapDelete("/usergamescore/{userId}",
	[SwaggerOperation(Summary = "Delete user game score", Description = "Deletes the game score of the provided user and game.")]
	(int userId) => {
	return _gameScoreRepository.DeleteUserGameScore(userId, games[1], 1);
})
.WithName("DeleteUserGameScore");

app.Run();

using GameScore.Repositories;
using UserGameScore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IGameScoreRepository, GameScoreRepository>();

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

app.MapGet("/usergamescores/{userId}", (int userId) =>
{
	return _gameScoreRepository.GetUserGameScores(userId);
})
.WithName("GetUserGameScores");

app.MapPost("/usergamescore/{userId}", (int userId) =>
{
	return _gameScoreRepository.CreateUserGameScore(new UserGameScoreRecord(userId, games[1], 1, 0));
})
.WithName("PostUserGameScore");

app.MapPut("/usergamescore/{userId}", (int userId) =>
{
	return _gameScoreRepository.UpdateUserGameScore(new UserGameScoreRecord(userId, games[1], 1, 100));
})
.WithName("UpdateGameScore");

app.MapDelete("/usergamescore/{userId}", (int userId) =>
{
	return _gameScoreRepository.DeleteUserGameScore(userId, games[1], 1);
})
.WithName("DeleteUserGameScore");

app.Run();

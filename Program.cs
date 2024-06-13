using GameStore.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetNameById";

List<GameDto> games = [
  new (
    Id: 1,
    Title: "The Legend of Zelda: Breath of the Wild",
    Genre: "Action-adventure",
    Price: 59.99M,
    ReleaseDate: new DateOnly(2017, 3, 3)
  ),
  new (
    Id: 2,
    Title: "Super Mario Odyssey",
    Genre: "Platformer",
    Price: 59.99M,
    ReleaseDate: new DateOnly(2017, 10, 27)
  ),
  new (
    Id: 3,
    Title: "Mario Kart 8 Deluxe",
    Genre: "Racing",
    Price: 59.99M,
    ReleaseDate: new DateOnly(2017, 4, 28)
  ),
];

// GET /games
app.MapGet("games", () => games);

// GET /games/1
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetGameEndpointName);

// POST /games
app.MapPost("games", (CreateGameDto newGame) =>
{
  GameDto game = new(
    games.Count + 1,
    newGame.Title,
    newGame.Genre,
    newGame.Price,
    newGame.ReleaseDate
  );
  games.Add(game);

  return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame) =>
{
  var index = games.FindIndex(game => game.Id == id);

  games[index] = new GameDto(
      id,
      updatedGame.Title,
      updatedGame.Genre,
      updatedGame.Price,
      updatedGame.ReleaseDate
    );

  return Results.NoContent();
});

app.MapDelete("games/{id}", (int id) =>
{
  games.RemoveAll(game => game.Id == id);

  return Results.NoContent();
});

app.Run();

using GameStore.Dtos;

namespace GameStore.Endpoints.InMemory
{
  public static class InMemoryGamesEndpoints
  {
    const string GetGameEndpointName = "GetNameById";

    private static readonly List<GameDto> games = [
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

    public static RouteGroupBuilder InMemoryMapGamesEndpoints(this WebApplication app)
    {
      var group = app.MapGroup("games").WithParameterValidation();

      // GET /games
      group.MapGet("/", () => games);

      // GET /games/1
      group.MapGet("/{id}", (int id) =>
      {
        GameDto? game = games.Find(game => game.Id == id);

        return game is null ? Results.NotFound() : Results.Ok(game);
      }).WithName(GetGameEndpointName);

      // POST /games
      group.MapPost("/", (CreateGameDto newGame) =>
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

      // PUT /games/1
      group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
      {
        var index = games.FindIndex(game => game.Id == id);

        if (index < 0)
        {
          return Results.NotFound();
        }

        games[index] = new GameDto(
            id,
            updatedGame.Title,
            updatedGame.Genre,
            updatedGame.Price,
            updatedGame.ReleaseDate
          );

        return Results.NoContent();
      });

      // DELETE /games/1
      group.MapDelete("/{id}", (int id) =>
      {
        games.RemoveAll(game => game.Id == id);

        return Results.NoContent();
      });

      return group;
    }
  }
}
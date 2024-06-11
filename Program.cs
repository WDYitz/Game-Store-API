using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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

app.MapGet("games", () => games);

app.MapGet("/", () => "Hello World!");

app.Run();

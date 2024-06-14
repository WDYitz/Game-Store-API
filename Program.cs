using GameStore.Endpoints.InMemory;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.InMemoryMapGamesEndpoints();

app.Run();

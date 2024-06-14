using GameStore.Data;
using GameStore.Endpoints.InMemory;

var builder = WebApplication.CreateBuilder(args);

// CONECTION STRING
var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.InMemoryMapGamesEndpoints();

app.MigrateDb();

app.Run();

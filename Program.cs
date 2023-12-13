
using GameRepo.API;
using GameRepo.Data;


var builder = WebApplication.CreateBuilder(args);

//Dependancy injection for the GamesRepository
builder.Services.AddRepositories(builder.Configuration);

WebApplication app = builder.Build();

//Automatization of database migration upon startup
await app.Services.InitializeDB();

app.MapGet("/", () => Results.Redirect("/games"));

app.MapGamesEndpoints();

app.Run();

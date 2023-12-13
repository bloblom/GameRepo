using GameRepo.Dto;
using GameRepo.Model;
using GameRepo.Repositories;

namespace GameRepo.API
{
    public static class GamesEndpoints
    {
        

        public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
        {
            
            var gamesRoute = routes.MapGroup("/games");

            const string getGameByID = "getGame";
            const string getAllGames = "getAllGames";

            //get all games
            gamesRoute.MapGet("/", async (IGamesRepository gamesRepository) => (await gamesRepository.GetAll()).Select(game => game.AsDto())).WithName(getAllGames);

            //get game by id
            gamesRoute.MapGet("/{id}", async (IGamesRepository gamesRepository, int id) => 
                {
                    Game? game = await gamesRepository.Get(id);
                    return (game is null) ? Results.NotFound() : Results.Ok(game.AsDto());
                }
            ).WithName(getGameByID);

            //add game
            gamesRoute.MapPost("/", async (IGamesRepository gamesRepository, CreateGameDto gameDto) => 
                {   
                    Game newGame = new Game()
                    {
                        Name = gameDto.Name,
                        Genre = gameDto.Genre,
                        Price = gameDto.Price,
                        ReleaseDate = gameDto.Release_date,
                        ImageUri = gameDto.Image_uri
                    };

                    await gamesRepository.Create(newGame);
                    return Results.AcceptedAtRoute(getGameByID, new {id = newGame.Id}, newGame);
                }
            );

            //update game
            gamesRoute.MapPut("/{id}", async (IGamesRepository gamesRepository, int id, UpdateGameDto updateGameDto) => 
                {
                    Game? gameToEdit = await gamesRepository.Get(id);
                    if(gameToEdit is null)
                        return Results.NotFound();

                    gameToEdit.Name = updateGameDto.Name;
                    gameToEdit.Genre = updateGameDto.Genre;
                    gameToEdit.Price = updateGameDto.Price;
                    gameToEdit.ReleaseDate = updateGameDto.Release_date;
                    gameToEdit.ImageUri = updateGameDto.Image_uri;

                    await gamesRepository.Update(gameToEdit);

                    return Results.NoContent();
                }
            );

            //delete game
            gamesRoute.MapDelete("/{id}", async (IGamesRepository gamesRepository, int id) =>
                {
                    await gamesRepository.Delete(id);
                    return Results.NoContent();
                }
            );

            return gamesRoute;
        }
    }
}
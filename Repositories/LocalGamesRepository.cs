using GameRepo.Model;

namespace GameRepo.Repositories
{
    //Repository to store some games in memory
    public class LocalGamesRepository : IGamesRepository
    {
        private readonly List <Game> games = new() {
            new ()
            {
                Id = 1,
                Name = "Alan Wake 2", 
                Genre = "Survival Horror",
                Price = 59.99f,
                ReleaseDate = new(2023,10,27),
                ImageUri = new("https://placehold.co/100")
            },
            new ()
            {
                Id = 2,
                Name = "Baldur's Gate III", 
                Genre = "Role-Playing Game",
                Price = 59.99f,
                ReleaseDate = new(2023,8,3),
                ImageUri = new("https://placehold.co/100")
            },
            new ()
            {
                Id = 3,
                Name = "Star Wars Jedi: Survivor", 
                Genre = "Action-Adventure",
                Price = 59.99f,
                ReleaseDate = new(2023,4,28),
                ImageUri = new("https://placehold.co/100")
            }
        };

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await Task.FromResult(games);
        }

        public async Task<Game?> Get(int id)
        {
            return await Task.FromResult(games.Find(game => game.Id == id));
        }

        public async Task Create(Game newGame)
        {
            if (games.Count != 0)
                newGame.Id = games.Max(game => game.Id) + 1;
            else
                newGame.Id = 1;
            games.Add(newGame);

            await Task.CompletedTask;
        }

        public async Task Update(Game updatedGame)
        {
            int index = games.FindIndex(game => game.Id == updatedGame.Id);
            games[index] = updatedGame;

            await Task.CompletedTask;
        }

        public async Task Delete(int id) 
        {
            games.RemoveAll(game => game.Id == id);

            await Task.CompletedTask;
        }
    }
}
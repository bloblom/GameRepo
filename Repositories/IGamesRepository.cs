using GameRepo.Model;

//Interface for dependancy injection
namespace GameRepo.Repositories
{
    public interface IGamesRepository
    {
        Task<IEnumerable<Game>> GetAll();
        Task<Game?> Get(int id);
        Task Create(Game newGame);
        Task Update(Game updatedGame);
        Task Delete(int id);
    }
}
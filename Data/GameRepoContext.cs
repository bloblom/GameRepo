using GameRepo.Model;
using Microsoft.EntityFrameworkCore;

namespace GameRepo.Data
{
    public class GameRepoContext : DbContext
    {
        public GameRepoContext(DbContextOptions<GameRepoContext> options) : base(options)
        {
        }

        public DbSet<Game> Games => Set<Game>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRepo.Data;
using GameRepo.Model;
using Microsoft.EntityFrameworkCore;

namespace GameRepo.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly GameRepoContext DbContext;

        public GamesRepository(GameRepoContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task Create(Game newGame)
        {
            DbContext.Games.Add(newGame);
            await DbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await DbContext.Games.Where(game => game.Id == id)
            .ExecuteDeleteAsync();
        }

        public async Task<Game?> Get(int id)
        {
            return await DbContext.Games.FindAsync(id);
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await DbContext.Games.AsNoTracking().ToListAsync();
        }

        public async Task Update(Game updatedGame)
        {
            DbContext.Update(updatedGame);
            await DbContext.SaveChangesAsync();
        }
    }
}
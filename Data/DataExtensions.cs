using GameRepo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameRepo.Data
{
    public static class DataExtensions
    {
        public static async Task InitializeDB(this IServiceProvider serviceProvider)
        {
            IServiceScope scope = serviceProvider.CreateScope();
            GameRepoContext DbContext = scope.ServiceProvider.GetRequiredService<GameRepoContext>();
            await DbContext.Database.MigrateAsync();
        }

        //This function is used to automatically register our DB repositories
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            

            
            string? DB_conn_params = configuration.GetConnectionString("GameRepoContext");
            serviceCollection.AddSqlServer<GameRepoContext>(DB_conn_params)
            //Since LocalGamesRepository stores data within itself, we need a shared object
            //.AddSingleton<IGamesRepository, LocalGamesRepository>();

            //Or we could use a scoped repository that stores data in a database
            .AddScoped<IGamesRepository, GamesRepository>();

            return serviceCollection;
        }
    }
}
using WebAPI.Repositories.IRepository;
using WebAPI.Repositories.Repository;

namespace WebAPI.SnackShop.Configuration
{
    public static class RepositoryWrapperConfiguration
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}

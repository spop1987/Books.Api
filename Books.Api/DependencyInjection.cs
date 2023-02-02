using Books.DataBase.SqlServer.DataAccess;
using Books.Models.Translators;
using BooksService;

namespace Books.Api
{
    public static class DependencyInjection
    {
        public static void AddDependencyServices(this IServiceCollection services)
        {
            services.AddScoped<IToDtoTranslator, ToDtoTranslator>();
            services.AddTransient<IServices, Services>();
            services.AddScoped<IQueries, Queries>();
        }
    }
}

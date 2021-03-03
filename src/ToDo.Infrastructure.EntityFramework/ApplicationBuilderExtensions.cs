using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ToDo.Infrastructure.EntityFramework
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyDatabaseMigrations(this IApplicationBuilder builder)
        {
            using var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var ctx = scope.ServiceProvider.GetRequiredService<ToDoDbContext>();
            ctx.Database.Migrate();
        }
    }
}

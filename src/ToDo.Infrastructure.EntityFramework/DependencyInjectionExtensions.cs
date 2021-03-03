using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Core.Services;

namespace ToDo.Infrastructure.EntityFramework
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddToDoInfrastructureEntityFramework(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (optionsAction is null)
                throw new ArgumentNullException(nameof(optionsAction));

            services.AddDbContext<ToDoDbContext>(optionsAction);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IToDoRepository, ToDoRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ToDo.Core.Services;

namespace ToDo.Infrastructure.EntityFramework
{
    public class ToDoRepository : Repository<Core.Entities.ToDo>, IToDoRepository
    {
        public ToDoRepository(ToDoDbContext context) : base(context)
        {
        }
    }
}
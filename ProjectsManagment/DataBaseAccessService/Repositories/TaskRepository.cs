using DataBaseAccessService.Data;

namespace DataBaseAccessService.Repositories
{
    public class TaskRepository(DataContext context) : RepositoryBase<Models.Task>(context)
    {
        private protected override Models.Task? SearchEntity(Models.Task entity)
        {
            return context.Set<Models.Task>().Find(entity.Id);
        }
    }
}

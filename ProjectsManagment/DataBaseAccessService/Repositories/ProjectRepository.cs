using DataBaseAccessService.Data;
using DataBaseAccessService.Models;

namespace DataBaseAccessService.Repositories
{
    public class ProjectRepository(DataContext context) : RepositoryBase<Project>(context)
    {
        private protected override Project? SearchEntity(Project entity)
        {
            return context.Set<Project>().Find(entity.Id);
        }
    }
}

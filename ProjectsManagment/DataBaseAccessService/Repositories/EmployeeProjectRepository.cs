using DataBaseAccessService.Data;
using DataBaseAccessService.Models;

namespace DataBaseAccessService.Repositories
{
    public class EmployeeProjectRepository(DataContext context) : RepositoryBase<EmployeeProject>(context)
    {
        private protected override EmployeeProject? SearchEntity(EmployeeProject entity)
        {
            return context.Set<EmployeeProject>().Find(entity.EmployeeId, entity.ProjectId);
        }
    }
}

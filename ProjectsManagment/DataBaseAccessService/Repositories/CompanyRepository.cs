using DataBaseAccessService.Data;
using DataBaseAccessService.Models;

namespace DataBaseAccessService.Repositories
{
    public class CompanyRepository(DataContext context) : RepositoryBase<Company>(context)
    {
        private protected override Company? SearchEntity(Company entity)
        {
            return context.Set<Company>().Find(entity.Id);
        }
    }
}

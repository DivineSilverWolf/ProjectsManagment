using DataBaseAccessService.Data;
using DataBaseAccessService.Models;

namespace DataBaseAccessService.Repositories
{
    public class EmployeeRepository(DataContext context) : RepositoryBase<Employee>(context)
    {
        private protected override Employee? SearchEntity(Employee entity)
        {
            return context.Set<Employee>().Find(entity.Id);
        }
        public IEnumerable<Employee> searchAndGetByWordForItems(string wordSearch)
        {
            HashSet<Employee> employees = new HashSet<Employee>();
            foreach (Employee emp in _context.Set<Employee>().ToList()) {
                string words = emp.Name + " " + emp.Surname + " " + (emp.PatronymicName == null ? "" : emp.PatronymicName + " ") + emp.MailingAddress;
                if (words.Contains(wordSearch)) 
                {
                    employees.Add(emp);
                }
            }
            return employees;
        }
    }
}

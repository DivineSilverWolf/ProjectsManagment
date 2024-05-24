using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace DataBaseAccessService.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DateStart { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? DateEnd { get; set; }
        [ForeignKey("Companies")]
        public int CompanyBuyerId { get; set; }
        public Company? CompanyBuyer { get; set; }
        [ForeignKey("Companies")]
        public int CompanyExecutorId { get; set; }
        public Company? CompanyExecutor { get; set; }
        [ForeignKey("Employees")]
        public int EmployeeId { get; set; }
        public Employee? Leader { get; set; }
        public int ProjectPriority { get; set; }
    }
}

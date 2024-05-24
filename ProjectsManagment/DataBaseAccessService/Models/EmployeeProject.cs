using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccessService.Models
{
    public class EmployeeProject
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Employees")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Projects")]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}

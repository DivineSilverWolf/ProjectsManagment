using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseAccessService.Models
{
    public enum STATUS
    {
        ToDo, InProgress, Done
    }
    [Index(nameof(Name), IsUnique = true)]
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Employees")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        [ForeignKey("Employees")]
        public int AutorId { get; set; }
        public Employee? Autor { get; set; }
        [ForeignKey("Projects")]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        public STATUS Status { get; set; }
        public string? Comment { get; set; }
        public int Priority { get; set; }
    }
}

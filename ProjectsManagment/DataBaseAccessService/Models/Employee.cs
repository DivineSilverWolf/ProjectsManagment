using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DataBaseAccessService.Models
{
    [Index(nameof(MailingAddress), IsUnique = true)]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? PatronymicName { get; set; }
        public string MailingAddress { get; set; }
    }
}

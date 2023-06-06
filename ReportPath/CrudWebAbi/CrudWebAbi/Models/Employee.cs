using System.ComponentModel.DataAnnotations;

namespace CrudWebAbi.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailId { get; set; }

    }
}

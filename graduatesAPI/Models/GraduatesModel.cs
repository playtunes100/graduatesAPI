using System.ComponentModel.DataAnnotations;

namespace graduatesAPI.Models
{
    public class GraduatesModel
    {
        [Key]
        public Guid GraduateId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }
        public decimal Age { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateEdited { get; set; }
        public Boolean IsDeleted { get; set; }
        
    }
}

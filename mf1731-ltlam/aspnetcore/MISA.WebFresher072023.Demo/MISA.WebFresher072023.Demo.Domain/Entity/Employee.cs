using System.ComponentModel.DataAnnotations;
namespace MISA.WebFresher072023.Demo.Domain
{
    public class Employee : BaseEntity,IEntity
    {
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee code is required")]
        public string EmployeeCode { get; set; }

        public string? FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender? Gender { get; set; }

        public Guid GetId()
        {
            return EmployeeId;
        }

        public void SetId(Guid id)
        {
            EmployeeId = id;
        }
    }

}


using Core.Entities.Abstracts;

namespace Entities.DTOs
{
    public class EmployeeForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
}
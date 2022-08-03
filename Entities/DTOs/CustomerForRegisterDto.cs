using Core.Entities.Abstracts;

namespace Entities.DTOs
{
    public class CustomerForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }
    }
}
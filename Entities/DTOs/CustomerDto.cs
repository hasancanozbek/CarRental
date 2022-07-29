
using Core.Entities.Abstracts;

namespace Entities.DTOs
{
    public class CustomerDto : IDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}

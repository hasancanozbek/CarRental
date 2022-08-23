
using Core.Entities.Abstracts;

namespace Entities.DTOs
{
    public class RentInformationDto : IDto
    {
        public int Id { get; set; }
        public string Car { get; set; }
        public decimal Price { get; set; }
        public DateTime RentalDate { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerFullName { get; set; }
    }
}

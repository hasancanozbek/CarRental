using Core.Entities.Abstracts;

namespace Entities.DTOs
{
    public class CarAddDto : IDto
    {
        public int BrandId { get; set; }
        public int GearTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int ColourId { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}

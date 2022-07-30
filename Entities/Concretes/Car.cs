
using Core.Entities.Abstracts;

namespace Entities.Concretes
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int GearTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int ColourId { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }



        public Brand Brand { get; set; }
        public GearType GearType { get; set; }
        public FuelType FuelType { get; set; }
        public Colour Colour { get; set; }

        public List<RentDetail>? RentDetails { get; set; }
        public List<CarImage>? CarImages { get; set; }
    }
}

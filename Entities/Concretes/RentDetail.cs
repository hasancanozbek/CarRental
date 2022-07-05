using Core.Entities;

namespace Entities.Concretes
{
    public class RentDetail : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public decimal Price { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string OriginAddress { get; set; }
        public string? ReturnAddress { get; set; }



        public Customer Customer { get; set; }
        public Car Car { get; set; }
    }
}

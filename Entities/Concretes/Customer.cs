
using Core.Entities;
using Entities.Abstracts;

namespace Entities.Concretes
{
    public class Customer : User, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }



        public List<RentDetail> RentDetails { get; set; }
    }
}

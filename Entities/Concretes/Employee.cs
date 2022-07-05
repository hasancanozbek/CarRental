
using Core.Entities;
using Entities.Abstracts;

namespace Entities.Concretes
{
    public class Employee : User, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
}

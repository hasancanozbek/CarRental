
using Core.Entities.Abstracts;
using Core.Entities.Concretes;

namespace Entities.Concretes
{
    public class Employee : User, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
}

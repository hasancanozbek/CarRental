
using Core.Entities.Abstracts;
using Core.Entities.Concretes;

namespace Entities.Concretes
{
    public class Employee : User, IEntity
    {
        public string Department { get; set; }
    }
}

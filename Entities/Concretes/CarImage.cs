
using Core.Entities.Abstracts;
using System.Text.Json.Serialization;

namespace Entities.Concretes
{
    public class CarImage : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime UploadDate { get; set; }

        [JsonIgnore]
        public Car Car { get; set; }
    }
}


using Businnes.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Businnes.Concretes
{
    public class ColourManager : IColourService
    {
        private readonly IColourRepository colourRepository;

        public ColourManager(IColourRepository colourRepository)
        {
            this.colourRepository = colourRepository;
        }

        public DataResult<Colour> Add(Colour color)
        {
            colourRepository.Add(color);
            return new SuccessDataResult<Colour>(color,"Colour added to database.");
        }

        public Result Delete(Colour color)
        {
            colourRepository.Delete(color);
            return new SuccessResult("Fuel type removed from database.");
        }

        public DataResult<List<Colour>> GetAll()
        {
            var colours = colourRepository.GetAll();
            return new SuccessDataResult<List<Colour>>(colours, "All colours listed.");
        }

        public DataResult<Colour> GetById(int id)
        {
            var colour = colourRepository.Get(c => c.Id == id);
            return new SuccessDataResult<Colour>(colour, "The desired colour is listed according to the id.");
        }

        public DataResult<Colour> Update(Colour color)
        {
            colourRepository.Update(color);
            return new SuccessDataResult<Colour>(color, "Colour information updated.");
        }
    }
}

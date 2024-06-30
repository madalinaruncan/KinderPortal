using API.Data.Repository;
using API.Entities;

namespace API.Data.Service
{
    public class PreschoolerService
    {
        private readonly IRepository<Preschooler> _preschoolerRepository;

        public PreschoolerService(IRepository<Preschooler> preschoolerRepository)
        {
            _preschoolerRepository = preschoolerRepository;
        }

        public async Task CreatePreschoolerAsync(Preschooler preschooler)
        {
            preschooler.IsPresent = false;
            await _preschoolerRepository.CreateEntityAsync(preschooler);
        }

        public async Task DeletePreschoolerAsync(int preschoolerId)
        {
            await _preschoolerRepository.DeleteEntityAsync(preschoolerId);
        }

        public async Task<Preschooler> GetPreschoolerAsync(int prescoolerId)
        {
            return await _preschoolerRepository.GetEntityAsync(prescoolerId);
        }

        public async Task<IEnumerable<Preschooler>> GetPreschoolersAsync()
        {
            return await _preschoolerRepository.GetEntitiesAsync();
        }

        public async Task UpdatePreschoolerAsync(Preschooler preschooler)
        {
            var preschoolerToReplace = await _preschoolerRepository.GetEntityAsync(preschooler.Id);

            if ( preschoolerToReplace == null)
            {
                throw new KeyNotFoundException("Preschooler not found");
            }

            preschoolerToReplace.FirstName = preschooler.FirstName;
            preschoolerToReplace.FatherInitial = preschooler.FatherInitial;
            preschoolerToReplace.LastName = preschooler.LastName;
            preschoolerToReplace.IsPresent = preschooler.IsPresent;
            preschoolerToReplace.GroupId = preschooler.GroupId;

            await _preschoolerRepository.UpdateEntityAsync(preschoolerToReplace);
        }
    }
}

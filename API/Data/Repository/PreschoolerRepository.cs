using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    public class PreschoolerRepository : IRepository<Preschooler>
    {
        private readonly ApplicationDbContext _context;

        public PreschoolerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateEntityAsync(Preschooler preschooler)
        {
            _context.Preschoolers.Add(preschooler);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(int preschoolerId)
        {
            var preschooler = await _context.Preschoolers.FindAsync(preschoolerId);

            if(preschooler == null)
            {
                throw new KeyNotFoundException("Preschooler not found");
            }

            _context.Preschoolers.Remove(preschooler);
            await _context.SaveChangesAsync();
        }

        public async Task<Preschooler> GetEntityAsync(int preschoolerId)
        {
            return await _context.Preschoolers
                .Where(p => p.Id == preschoolerId)
                .Include(p => p.Group)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Preschooler>> GetEntitiesAsync()
        {
            return await _context.Preschoolers
                .Include(p => p.Group)
                .ToListAsync();
        }

        public async Task UpdateEntityAsync(Preschooler preschooler)
        {
            await _context.SaveChangesAsync();
        }
    }
}

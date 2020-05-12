using System.Threading.Tasks;

namespace DependencyInjectionDemo.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DemoDbContext _context;

        public UnitOfWork(DemoDbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

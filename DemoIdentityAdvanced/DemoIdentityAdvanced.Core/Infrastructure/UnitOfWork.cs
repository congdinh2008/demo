using DemoIdentityAdvanced.UI.Models;
using System.Threading.Tasks;

namespace DemoIdentityAdvanced.Core.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private ApplicationDbContext _context;

        public ApplicationDbContext DbContext
        {
            get
            {
                return _context ?? (_context = _dbFactory.Init());
            }
        }

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public int Commit()
        {
            return DbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }
    }
}

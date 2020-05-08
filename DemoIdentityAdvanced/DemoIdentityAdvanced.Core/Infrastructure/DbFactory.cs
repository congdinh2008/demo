using DemoIdentityAdvanced.UI.Models;

namespace DemoIdentityAdvanced.Core.Infrastructure
{
    public class DbFactory: Disposable, IDbFactory
    {
        ApplicationDbContext _dbContext;

        public ApplicationDbContext Init()
        {
            return _dbContext ?? (_dbContext = new ApplicationDbContext());
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}

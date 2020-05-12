using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Core.Repositories
{
    public interface IUnitOfWork
    {
        int Commit();

        Task<int> CommitAsync();
    }
}

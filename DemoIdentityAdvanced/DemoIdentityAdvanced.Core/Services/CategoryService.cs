using DemoIdentityAdvanced.Core.Infrastructure;
using DemoIdentityAdvanced.Core.Repositories;
using DemoIdentityAdvanced.UI.Models;
using System.Transactions;

namespace DemoIdentityAdvanced.Core.BaseServices
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> repository) : base(unitOfWork, repository)
        {
        }
    }
}

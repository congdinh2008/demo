using DependencyInjectionDemo.Core.Repositories;

namespace DependencyInjectionDemo.Core.Services
{
    public class CategoryServices : BaseServices<Category>, ICategoryServices
    {
        public CategoryServices(IGenericRepository<Category> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}

using DependencyInjectionDemo.Core.Repositories;

namespace DependencyInjectionDemo.Core.Services
{
    public class BookServices : BaseServices<Book>, IBookServices
    {
        public BookServices(IGenericRepository<Book> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}

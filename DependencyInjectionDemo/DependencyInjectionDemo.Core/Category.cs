using System.Collections.Generic;

namespace DependencyInjectionDemo.Core
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<Book> Books { get; set; }
    }
}

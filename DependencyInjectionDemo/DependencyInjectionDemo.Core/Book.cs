namespace DependencyInjectionDemo.Core
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public string ImgUrl { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}

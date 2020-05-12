using System.Data.Entity;
using System.Linq;

namespace DependencyInjectionDemo.Core
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DemoDbContext>
    {
        protected override void Seed(DemoDbContext context)
        {
            var categories = new Category[]
            {
                new Category
                {
                    Name = "Category 01",
                },
                new Category
                {
                    Name = "Category 02",
                },
                new Category
                {
                    Name = "Category 03",
                }
            };
            context.Categories.AddRange(categories);
            var books = new Book[]
            {
                new Book
                {
                    Title = "Book 01",
                    ImgUrl = "book-0001.jpg",
                    Category = categories.Single(c=>c.Name == "Category 01")
                },
                new Book
                {
                    Title = "Book 02",
                    ImgUrl = "book-0002.jpg",
                    Category = categories.Single(c=>c.Name == "Category 01")
                },
                new Book
                {
                    Title = "Book 03",
                    ImgUrl = "book-0003.jpg",
                    Category = categories.Single(c=>c.Name == "Category 02")
                },
                new Book
                {
                    Title = "Book 04",
                    ImgUrl = "book-0004.jpg",
                    Category = categories.Single(c=>c.Name == "Category 02")
                },
                new Book
                {
                    Title = "Book 05",
                    ImgUrl = "book-0005.jpg",
                    Category = categories.Single(c=>c.Name == "Category 03")
                }
            };
            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}

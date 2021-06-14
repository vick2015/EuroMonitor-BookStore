using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookStore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace BookStore.Stores
{
    public class BookStore
    {
        public static void AddTestData(IServiceProvider serviceProvider)
        {
            using (var dbContext = new BookDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<BookDBContext>>()))
            {

                if (dbContext.BookEntity.Any())
                {
                    return;
                }

                dbContext.BookEntity.Add(new BookEntity
                {
                    BookId = Guid.Parse("ee2b83be-91db-4de5-8122-35a9e9195976"),
                    BookDescription = "Some Book Description 1",
                    //ImageUrl = "image.png",
                    AuthorName = "Author 1",
                    BookName = "Book 1",
                    Cost = 23
                });

                dbContext.BookEntity.Add(new BookEntity
                {
                    BookId = Guid.Parse("ee2b83be-91db-4de5-8122-35a9e9256987"),
                    BookDescription = "Some Book Description 2",
                    //ImageUrl = "image.png",
                    AuthorName = "Author 2",
                    BookName = "Book 2",
                    Cost = 13
                });

                dbContext.BookEntity.Add(new BookEntity
                {
                    BookId = Guid.Parse("ee2b83be-91db-4de5-8122-35a9e9112343"),
                    BookDescription = "Some Book Description 3",
                    //ImageUrl = "image.png",
                    AuthorName = "Author 3",
                    BookName = "Book 3",
                    Cost = 67
                });

                dbContext.BookEntity.Add(new BookEntity
                {
                    BookId = Guid.Parse("ee2b83be-91db-4de5-8122-35a9e92de432"),
                    BookDescription = "Some Book Description 4",
                    //ImageUrl = "image.png",
                    AuthorName = "Author 4",
                    BookName = "Book 4",
                    Cost = 12.20
                });

                dbContext.BookEntity.Add(new BookEntity
                {
                    BookId = Guid.Parse("ee2b83be-91db-4de5-8122-35a9e91ff643"),
                    BookDescription = "Some Book Description 5",
                    //ImageUrl = "image.png",
                    AuthorName = "Author 5",
                    BookName = "Book 5",
                    Cost = 50.69
                });

                dbContext.BookEntity.Add(new BookEntity
                {
                    BookId = Guid.Parse("ee2b83be-91db-4de5-8122-35a9e9212908"),
                    BookDescription = "Some Book Description 6",
                    //ImageUrl = "image.png",
                    AuthorName = "Author 6",
                    BookName = "Book 6",
                    Cost = 12.56
                });
                dbContext.BookEntity.Add(new BookEntity
                {
                    BookId = Guid.Parse("ee2b83be-91db-4de5-8122-35a9e911212d"),
                    BookDescription = "Some Book Description 7",
                    //ImageUrl = "image.png",
                    AuthorName = "Author 7",
                    BookName = "Book 7",
                    Cost = 45
                });

                dbContext.BookEntity.Add(new BookEntity
                {
                    BookId = Guid.Parse("ee2b83be-91db-4de5-8122-35a9e9267545"),
                    BookDescription = "Some Book Description 8",
                    //ImageUrl = "image.png",
                    AuthorName = "Author 8",
                    BookName = "Book 8",
                    Cost = 23
                });

                dbContext.BookEntity.Add(new BookEntity
                {
                    BookId = Guid.Parse("ee2b83be-91db-4de5-8122-35a9e9212312"),
                    BookDescription = "Some Book Description 9",
                    //ImageUrl = "image.png",
                    AuthorName = "Author 9",
                    BookName = "Book 9",
                    Cost = 12
                });


                dbContext.SaveChanges();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using BookStore.Models;


namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly BookDBContext myDbContext;
        private readonly IConfigurationProvider myConfigurationProvider;

        public BookService(BookDBContext dbContext,IConfigurationProvider configurationProvider)
        {
            myDbContext = dbContext;
            myConfigurationProvider = configurationProvider;
        }

        public Book GetBookById(Guid bookId)
        {
            var book = myDbContext.BookEntity.FirstOrDefault(a => a.BookId == bookId);
            var mapper = myConfigurationProvider.CreateMapper();
            return mapper.Map<Book>(book);
        }

        public IList<Book> GetAllBooks()
        {
            IQueryable<BookEntity> bookEntities = myDbContext.BookEntity;

            var bookList = bookEntities.ProjectTo<Book>(myConfigurationProvider).ToList();

            return bookList;
        }
    }

    public interface IBookService
    {
        Book GetBookById(Guid bookId);

        IList<Book> GetAllBooks();
    }
}

using BookAppServices.Controllers;
using CommonModels;
using System.Collections.Generic;
using Xunit;

namespace BookAppServiceTests
{
    public class GetTests
    {
        [Fact]
        public void Get_empty_list_test()
        {
            //BookRepository bookRepository = new BookRepository();
            BookServices bookServices = new BookServices();
            
            var result = bookServices.GetAllBooks();
            Assert.Equal("Details of all books", result.Message[0]);
            
        }
        [Fact]
        public void Get_all_books_test()
        {
            
            BookServices bookServices = new BookServices();
            List<Book> bookList = new List<Book>();
            bookList.Add(new  Book { Id = 1, Name = "Harry Potter", Price = 300, Author = "J K Rowling", Category = "Fiction" });
            bookServices.Post(bookList[0]);
            Assert.Equal(bookList, bookServices.GetAllBooks().Value);

        }
        [Fact]
        public void Get_book_by_id_test()
        {
            
            BookServices bookServices = new BookServices();
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book { Id = 1, Name = "Harry Potter", Price = 300, Author = "J K Rowling", Category = "Fiction" });
            bookServices.Post(bookList[0]);
            Assert.Equal(bookList[0], bookServices.GetBookById(bookList[0].Id).Value);
        }
        [Theory]
        [InlineData(-1, "Invalid id")]
        [InlineData(1, "Not found")]
        public void Get_book_by_id_invalid_test(int id,string result)
        {
            
            BookServices bookServices = new BookServices();
            Assert.Equal(result, bookServices.GetBookById(id).Message[0]);
        }
        

    }
}

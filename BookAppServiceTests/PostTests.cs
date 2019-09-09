using BookAppServices.Controllers;
using CommonModels;
using System.Collections.Generic;
using Xunit;

namespace BookAppServiceTests
{
    public class PostTests
    {
        [Fact]
        public void Post_book_test()
        {
            BookServices bookServices = new BookServices();
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book { Id = 1, Name = "Harry Potter", Price = 300, Author = "J K Rowling", Category = "Fiction" });

            Assert.Equal("Added Successfully", bookServices.Post(bookList[0]).Message[0]);
            Assert.True(bookServices.Post(bookList[0]).Status);
        }
        [Theory]
        [InlineData(-1, "Invalid Id")]
        public void Post_book_invalid_id_test(int id, string result)
        {
            BookServices bookServices = new BookServices();
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book { Id = id, Name = "Harry Potter", Price = 300, Author = "J K Rowling", Category = "Fiction" });

            Assert.Equal(result, bookServices.Post(bookList[0]).Message[0]);
            Assert.False(bookServices.Post(bookList[0]).Status);
        }
        [Theory]
        [InlineData(-1, "Invalid Price")]
        public void Post_book_invalid_price_test(int price, string result)
        {
            BookServices bookServices = new BookServices();
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book { Id = 1, Name = "Harry Potter", Price = price, Author = "J K Rowling", Category = "Fiction" });

            Assert.Equal(result, bookServices.Post(bookList[0]).Message[0]);
            Assert.False(bookServices.Post(bookList[0]).Status);
        }
        [Theory]
        [InlineData(",", "Author name only contains characters , spaces and .")]
        [InlineData(",.", "Author name only contains characters , spaces and .")]
        [InlineData("123", "Author name only contains characters , spaces and .")]
        [InlineData("vamsi 1", "Author name only contains characters , spaces and .")]

        public void Post_book_invalid_name_test(string name, string result)
        {
            BookServices bookServices = new BookServices();
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book { Id = 1, Name = "Harry Potter", Price = 100, Author = name, Category = "Fiction" });

            Assert.Equal(result, bookServices.Post(bookList[0]).Message[0]);
            Assert.False(bookServices.Post(bookList[0]).Status);
        }
        [Theory]
        [InlineData("Abc", "Added Successfully")]
        public void Post_book_valid_name_test(string name, string result)
        {
            BookServices bookServices = new BookServices();
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book { Id = 1, Name = "Harry Potter", Price = 100, Author = name, Category = "Fiction" });

            Assert.Equal(result, bookServices.Post(bookList[0]).Message[0]);
            Assert.True(bookServices.Post(bookList[0]).Status);
        }

    }
}

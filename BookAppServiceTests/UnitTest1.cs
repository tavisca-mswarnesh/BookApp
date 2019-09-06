using BookAppDataAccessLayer.Controller;
using CommonModels;
using SampleHelloWorld.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace BookAppServiceTests
{
    public class SevicesTest
    {
        [Fact]
        public void get_empty_list_test()
        {
            //BookRepository bookRepository = new BookRepository();
            BookServices bookServices = new BookServices();
            
            var result = bookServices.GetBook();
            Assert.Equal("Details of all books", result.Message);
            
        }
        [Fact]
        public void get_all_books_test()
        {
            
            BookServices bookServices = new BookServices();
            List<Book> bookList = new List<Book>();
            bookList.Add(new  Book { Id = 1, Name = "Harry Potter", Price = 300, Author = "J K Rowling", Category = "Fiction" });
            bookServices.Post(bookList[0]);
            Assert.Equal(bookList, bookServices.GetBook().Value);

        }
        [Fact]
        public void get_book_by_id_test()
        {
            
            BookServices bookServices = new BookServices();
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book { Id = 1, Name = "Harry Potter", Price = 300, Author = "J K Rowling", Category = "Fiction" });
            bookServices.Post(bookList[0]);
            Assert.Equal(bookList[0], bookServices.Get(bookList[0].Id).Value);
        }
        [Theory]
        [InlineData(-1, "Invalid id")]
        [InlineData(1, "Not found")]
        public void get_book_by_id_invalid_test(int id,string result)
        {
            
            BookServices bookServices = new BookServices();
            Assert.Equal(result, bookServices.Get(id).Message);
        }
        [Fact]
        public void post_book_test()
        {
            BookServices bookServices = new BookServices();
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book { Id = 1, Name = "Harry Potter", Price = 300, Author = "J K Rowling", Category = "Fiction" });
            
            Assert.Equal("Added Successfully", bookServices.Post(bookList[0]).Message);
            Assert.True(bookServices.Post(bookList[0]).Status);
        }
        [Theory]
        [InlineData(-1, "Invalid Id")]
        public void post_book_invalid_id_test(int id,string result)
        {
            BookServices bookServices = new BookServices();
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book { Id = id, Name = "Harry Potter", Price = 300, Author = "J K Rowling", Category = "Fiction" });

            Assert.Equal(result, bookServices.Post(bookList[0]).Message);
            Assert.False(bookServices.Post(bookList[0]).Status);
        }
        [Theory]
        [InlineData(-1, "Invalid Price")]
        public void post_book_invalid_price_test(int price, string result)
        {
            BookServices bookServices = new BookServices();
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book { Id = 1, Name = "Harry Potter", Price = price, Author = "J K Rowling", Category = "Fiction" });

            Assert.Equal(result, bookServices.Post(bookList[0]).Message);
            Assert.False(bookServices.Post(bookList[0]).Status);
        }
        [Theory]
        [InlineData(",", "Author name only contains characters , spaces and .")]
        [InlineData(",.", "Author name only contains characters , spaces and .")]
        [InlineData("123", "Author name only contains characters , spaces and .")]
        
        public void post_book_invalid_name_test(string name, string result)
        {
            BookServices bookServices = new BookServices();
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book { Id = 1, Name = "Harry Potter", Price = 100, Author = name, Category = "Fiction" });

            Assert.Equal(result, bookServices.Post(bookList[0]).Message);
            Assert.False(bookServices.Post(bookList[0]).Status);
        }
        [Theory]
        [InlineData("Abc", "Added Successfully")]
        public void post_book_valid_name_test(string name, string result)
        {
            BookServices bookServices = new BookServices();
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book { Id = 1, Name = "Harry Potter", Price = 100, Author = name, Category = "Fiction" });

            Assert.Equal(result, bookServices.Post(bookList[0]).Message);
            Assert.True(bookServices.Post(bookList[0]).Status);
        }

    }
}

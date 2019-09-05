using BookAppDataAccessLayer.Controller;
using CommonModels;
using SampleHelloWorld.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace BookAppServiceTests
{
    public class UnitTest1
    {
        [Fact]
        public void get_test()
        {
            BookRepository bookRepository = new BookRepository();
            BookServices bookServices = new BookServices(bookRepository);
            var result = bookServices.GetBook();
            Assert.Equal("Details of all books", result.Message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAppDataAccessLayer.Controller;
using CommonModels;

namespace SampleHelloWorld.Controllers
{
    
    
    public class BookServices 
    {
        
        private readonly BookRepository _bookRepository;
        public BookServices(BookRepository bookRepository)
        {
            //_bookRepository.PostBookDetails(new Book { Id = 1, Name = "Harry Potter", Price = 300, Author = "J K Rowling", Category = "Fiction" });
            
            _bookRepository = bookRepository;

        }
        
        public BookResponse GetBook()
        {

            BookResponse bookResponse = new BookResponse();
            bookResponse.Status = true;
            bookResponse.Message = "Details of all books";
            bookResponse.Value = _bookRepository.GetAllBookDetails();
            return bookResponse;
        }

               
        public BookResponse Get(int id)
        {
            BookResponse bookResponse = new BookResponse();
            if (id < 1)
            {
                bookResponse.Status = false;
                bookResponse.Message = "Invalid id";
                bookResponse.Value = null;
            }
            
            Book book=_bookRepository.GetBookDetailsById(id);
            
            if (book!=null)
            {
                bookResponse.Status = true;
                bookResponse.Message = "details found";
                bookResponse.Value = book;
            }
            else
            {
                bookResponse.Status = false;
                bookResponse.Message = "Not found";
                bookResponse.Value = null;
            }
            
            return bookResponse;
        }
        
        public BookResponse Post(Book book)
        {
            BookResponse bookResponse = new BookResponse();
            if (!book.Author.All(x => char.IsLetter(x) || x == ' ' || x == '.'))
            {
                bookResponse.Status = false;
                bookResponse.Message = "Author name only contains characters , spaces and .";
                bookResponse.Value = null;
            }
            if (book.Id < 1)
            {
                bookResponse.Status = false;
                bookResponse.Message = "Invalid Id";
                bookResponse.Value = null;
            }
            if(book.Price<0)
            {
                bookResponse.Status = false;
                bookResponse.Message = "Invalid Price";
                bookResponse.Value = null;
            }
            else
            {
                bookResponse.Status = true;
                bookResponse.Message = "Added Successfully";
                bookResponse.Value = _bookRepository.PostBookDetails(book);
            }
            
            return bookResponse;
        }

        // PUT: api/Home/5
        public BookResponse Put(Book book)
        {
            BookResponse bookResponse = new BookResponse();
            bookResponse.Status = true;
            bookResponse.Message = "Updated Successfully";
            bookResponse.Value = _bookRepository.PostBookDetails(book);
            return bookResponse;


        }

        
        public BookResponse Delete(int id)
        {
            BookResponse bookResponse = new BookResponse();
            bookResponse.Status = true;
            bookResponse.Message = "Updated Successfully";
            bookResponse.Value = _bookRepository.DeleteBookDetails(id);
            return bookResponse;
             
        }
    }
}

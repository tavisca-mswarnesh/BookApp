using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAppDataAccessLayer.Controller;
using CommonModels;

namespace BookAppServices.Controllers
{
    
    
    public class BookServices 
    {
        
        private readonly BookRepository _bookRepository = new BookRepository();
        public BookServices()
        {
            //_bookRepository.PostBookDetails(new Book { Id = 1, Name = "Harry Potter", Price = 300, Author = "J K Rowling", Category = "Fiction" });
            
           // _bookRepository = new BookRepository();

        }
        
        public BookResponse GetAllBooks()
        {

            BookResponse bookResponse = new BookResponse();
            bookResponse.Message = new List<string>();
            bookResponse.Status = true;
            bookResponse.Message.Add("Details of all books");
            bookResponse.Value = _bookRepository.GetAllBookDetails();
            return bookResponse;
        }

               
        public BookResponse GetBookById(int id)
        {
            BookResponse bookResponse = new BookResponse();
            bookResponse.Message = new List<string>();
            Book book = _bookRepository.GetBookDetailsById(id);
            if (id < 1)
            {
                bookResponse.Status = false;
                bookResponse.Message.Add("Invalid id");
                bookResponse.Value = null;

            }
            
            
            
            else if (book!=null)
            {

                bookResponse.Status = true;
                bookResponse.Message.Add("details found");
                bookResponse.Value = book;
            }
            else
            {
                bookResponse.Status = false;
                bookResponse.Message.Add("Not found");
                bookResponse.Value = null;
            }
            
            return bookResponse;
        }
        
        public BookResponse Post(Book book)
        {
            BookResponse bookResponse = new BookResponse();
            bookResponse.Message = new List<string>();
            if (!book.Author.All(x => char.IsLetter(x) || x == ' ' || x == '.'))
            {
                bookResponse.Status = false;
                bookResponse.Message.Add("Author name only contains characters , spaces and .");
                bookResponse.Value = null;
            }
            else if (book.Id < 1)
            {
                bookResponse.Status = false;
                bookResponse.Message.Add("Invalid Id");
                bookResponse.Value = null;
            }
            else if(book.Price<0)
            {
                bookResponse.Status = false;
                bookResponse.Message.Add("Invalid Price");
                bookResponse.Value = null;
            }
            else
            {
                bookResponse.Status = true;
                bookResponse.Message.Add("Added Successfully");
                bookResponse.Value = _bookRepository.PostBookDetails(book);
            }
            
            return bookResponse;
        }

        // PUT: api/Home/5
        public BookResponse Put(Book book)
        {
            BookResponse bookResponse = new BookResponse();
            bookResponse.Message = new List<string>();
            bookResponse.Status = true;
            bookResponse.Message.Add("Updated Successfully");
            bookResponse.Value = _bookRepository.PutBook(book);
            return bookResponse;


        }

        
        public BookResponse Delete(int id)
        {
            BookResponse bookResponse = new BookResponse();
            bookResponse.Status = true;
            bookResponse.Message.Add("Deleted Successfully");
            bookResponse.Value = _bookRepository.DeleteBookDetails(id);
            return bookResponse;
             
        }
    }
}

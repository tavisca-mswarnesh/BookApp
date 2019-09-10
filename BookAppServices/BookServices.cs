using System;
using System.Collections.Generic;
using System.IO;
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
            Logger logger = new Logger();
            Log log = new Log();
            log.Time = DateTime.Now;
            BookResponse bookResponse = new BookResponse();
            bookResponse.Message = new List<string>();
            bookResponse.Status = true;
            bookResponse.Message.Add("Details of all books");
            bookResponse.Value = _bookRepository.GetAllBookDetails();
            log.MethodCalled = "Get All Method";
            log.Status = bookResponse.Status;
            log.Error = bookResponse.Message;
            logger.write(log);
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
            valid(book,ref bookResponse);
            
            return bookResponse;
        }

        // PUT: api/Home/5
        public BookResponse Put(Book book)
        {
            BookResponse bookResponse = new BookResponse();
            bookResponse.Message = new List<string>();
            bookResponse.Status = true;
            valid(book,ref bookResponse);
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
        public void valid(Book book,ref BookResponse bookResponse)
        {
            BookvValidator validationRules = new BookvValidator();
            var flag = validationRules.Validate(book);
            if(flag.IsValid)
            {
                bookResponse.Status = true;
                bookResponse.Message.Add("Added Successfully");
                bookResponse.Value = _bookRepository.PostBookDetails(book);
            }
            else
            {
                bookResponse.Status = false;
                foreach (var error in flag.Errors)
                {
                    bookResponse.Message.Add(error.ErrorMessage);
                }
                bookResponse.Value = null;
            }
            
        }
        
    }
    public class Logger
    {
        public void write(Log log)
        {
            string path = "LoggerFile.txt";
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            if (File.Exists(path))
            {
                
                sw.WriteLine("Hello");
                    
                
                    
                Console.WriteLine("File Found") ;
            }
        }
    }
}

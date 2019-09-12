using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAppDataAccessLayer.Controller;
using CommonModels;
using ServiceStack.Redis;


namespace BookAppServices.Controllers
{

    public class BookServices :IServices
    {
        
        private readonly IRepository _bookRepository = new BookRepository();

        RedisManagerPool manager = new RedisManagerPool("localhost:6379");
        IRedisClient client;
        public BookServices()
        {
            //_bookRepository.PostBookDetails(new Book { Id = 1, Name = "Harry Potter", Price = 300, Author = "J K Rowling", Category = "Fiction" });

            // _bookRepository = new BookRepository();

            //client.Set("id","");
            client= manager.GetClient();

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
            Logger logger = new Logger();
            Log log = new Log();
            log.Time = DateTime.Now;
            BookResponse bookResponse = new BookResponse();
            bookResponse.Message = new List<string>();
            Book book;
            book = _bookRepository.GetBookDetailsById(id);
             if (client.Get<Book>(id.ToString())!=null)
             {
                 book = client.Get<Book>(id.ToString());
                bookResponse.Message.Add("details found in Cache");
            }
             else
             {
                bookResponse.Message.Add("details found in database");
                book = _bookRepository.GetBookDetailsById(id);
                 client.Set(book.Id.ToString(), book);
             }

            if (id < 1)
            {
                bookResponse.Status = false;
                bookResponse.Message.Add("Invalid id");
                bookResponse.Value = null;

            }
            
            
            
            else if (book!=null)
            {

                bookResponse.Status = true;
                //bookResponse.Message.Add("details found");
                bookResponse.Value = book;
            }
            else
            {
                bookResponse.Status = false;
                bookResponse.Message.Add("Not found");
                bookResponse.Value = null;
            }
            log.MethodCalled = "Get Book by Id Method";
            log.Status = bookResponse.Status;
            log.Error = bookResponse.Message;
            logger.write(log);
            return bookResponse;
        }
        
        public BookResponse Post(Book book)
        {
            Logger logger = new Logger();
            Log log = new Log();
            log.Time = DateTime.Now;
            BookResponse bookResponse = new BookResponse();
            bookResponse.Message = new List<string>();
            valid(book,ref bookResponse);

            log.MethodCalled = "Post Method";
            log.Status = bookResponse.Status;
            log.Error = bookResponse.Message;
            logger.write(log);
            return bookResponse;
        }

        
        public BookResponse Put(Book book)
        {
            Logger logger = new Logger();
            Log log = new Log();
            log.Time = DateTime.Now;
            BookResponse bookResponse = new BookResponse();
            bookResponse.Message = new List<string>();
            bookResponse.Status = true;
            valid(book,ref bookResponse);
            bookResponse.Value = _bookRepository.PutBook(book);

            log.MethodCalled = "Put  Method";
            log.Status = bookResponse.Status;
            log.Error = bookResponse.Message;
            logger.write(log);
            return bookResponse;


        }

        
        public BookResponse Delete(int id)
        {
            Logger logger = new Logger();
            Log log = new Log();
            log.Time = DateTime.Now;
            BookResponse bookResponse = new BookResponse();
            bookResponse.Status = true;
            bookResponse.Message = new List<string>();
            bookResponse.Message.Add("Deleted Successfully");
            bookResponse.Value = _bookRepository.DeleteBookDetails(id);
            log.MethodCalled = "Delete Method";
            log.Status = bookResponse.Status;
            log.Error = bookResponse.Message;
            logger.write(log);
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
}

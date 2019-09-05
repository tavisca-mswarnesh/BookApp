using CommonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookAppDataAccessLayer.Controller
{
    public class BookRepository
    {
        List<Book> bookList;
        public BookRepository()
        {
            bookList = new List<Book>();
        }

        public IEnumerable<Book> GetAllBookDetails()
        {

            return bookList;
        }

        
        public Book GetBookDetailsById(int Id)
        {
            Book book = null;
            for (int index = 0; index < bookList.Count; index++)
            {
                if (Id == bookList[index].Id)
                {
                    book = bookList[index];
                }
            }
            return book;
        }

        
        public bool PostBookDetails(Book book)
        {
            try
            {
                if(!bookList.Contains(book))   
                    bookList.Add(new Book { Id = book.Id, Name = book.Name, Price = book.Price, Author = book.Author, Category = book.Category });
                return true;
            }
            catch (Exception)
            {

                
                return false;
            }

        }

        // PUT: api/Home/5
        
        public bool PutBook(Book book)
        {
            var oldBook = bookList.Find(b => b.Id == book.Id);
            if (oldBook!=null)
            {
                bookList.Remove(oldBook);
                bookList.Add(book);
                return true;
            }
            else
            {
                return false;
            }
        }

        
        
        public bool DeleteBookDetails(int Id)
        {
            try
            {
                Book book = bookList.Find(b => b.Id == Id);
                bookList.Remove(book);
                return true;
            }
            catch 
            {

                return false;
            }
        }

    }
}

using CommonModels;
using System.Collections.Generic;

namespace BookAppDataAccessLayer.Controller
{
    public interface IRepository
    {
        IEnumerable<Book> GetAllBookDetails();
        Book GetBookDetailsById(int Id);
        bool PostBookDetails(Book book);
        bool PutBook(Book book);
        bool DeleteBookDetails(int Id);
    }
}

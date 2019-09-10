using CommonModels;
namespace BookAppServices.Controllers
{
    public interface IServices
    {
        BookResponse GetAllBooks();
        BookResponse GetBookById(int id);
        BookResponse Post(Book book);
        BookResponse Put(Book book);
        BookResponse Delete(int id);

    }
}

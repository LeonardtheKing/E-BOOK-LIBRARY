using MODEL.Entity;

namespace E_BOOK.API.Repository.Repository_Interface
{
    public interface IE_BookRepository
    {
        Task<bool> RemoveBook(int Id);
        Task<Book> UpdateBook(Book book);
        Task<IEnumerable<Book>> GetALLBook();
        Task<Book> GetBookById(int Id);
        IEnumerable<Book> Paginate(List<Book> contact, int perpage, int page);
        IEnumerable<Book> PopularBook();
        IEnumerable<Book> RecentBook();


    }
}

using E_BOOK.API.Repository.Repository_Interface;
using Microsoft.EntityFrameworkCore;
using MODEL;
using MODEL.Entity;

namespace E_BOOK.API.Repository
{
    public class E_BookRepository : IE_BookRepository
    {
        private readonly E_BookDbContext _BookDbContext;

        public E_BookRepository(E_BookDbContext e_BookDbContext)
        {
            _BookDbContext = e_BookDbContext;
        }


        public async Task<IEnumerable<Book>> GetALLBook()
        {
            var result = await _BookDbContext.Books.ToListAsync();
            return result;
        }
        public async Task IncrementView(int Id)
        {
            var oldresult = await _BookDbContext.Books.FirstOrDefaultAsync(x => x.Id == Id);
            oldresult.ViewBook += 1;
            _BookDbContext.Update(oldresult);
            await _BookDbContext.SaveChangesAsync();
        }
        public async Task<Book> GetBookById(int Id)
        {

            await IncrementView(Id);
            var result = await _BookDbContext.Books.FirstOrDefaultAsync(b => b.Id == Id);

            return result;

        }

        public async Task<bool> RemoveBook(int Id)
        {
            var result = await _BookDbContext.Books.FirstOrDefaultAsync(x => x.Id == Id);
            if (result != null)

                _BookDbContext.Books.Remove(result);
            var status = _BookDbContext.SaveChangesAsync();

            if (status.IsCompleted)
                return true;

            return false;


        }


        public async Task<Book> UpdateBook(Book book)
        {
            var BookToUpdate = await GetBookById(book.Id);
            if (BookToUpdate != null)
            {
                await _BookDbContext.SaveChangesAsync();
                return BookToUpdate;
            }
            return null;



        }

        public IEnumerable<Book> Paginate(List<Book> book, int perpage, int page)
        {
            page = page < 1 ? 1 : page;
            perpage = page < 1 ? 5 : perpage;
            if (book.Count > 0)
            {
                var paginated = book.Skip(page - 1).Take(perpage).ToList();
                return paginated;

            }

            return new List<Book>();
        }

        public IEnumerable<Book> PopularBook()
        {
            var Views = _BookDbContext.Books.OrderByDescending(b => b.ViewBook).ToList();

            return Views;

        }
        public IEnumerable<Book> RecentBook()
        {
            DateTime OneWeekAgo = DateTime.Now.AddDays(-7);
            var Views = _BookDbContext.Books.Where(b => b.AddedToLib >= OneWeekAgo).OrderByDescending(b => b.AddedToLib).ToList();

            return Views;

        }
    }
}

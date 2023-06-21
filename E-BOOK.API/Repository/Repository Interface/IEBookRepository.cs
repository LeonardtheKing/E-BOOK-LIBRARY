using Microsoft.AspNetCore.Mvc;
using MODEL.DTO;
using MODEL.Entity;

namespace E_BOOK.API.Repository.Repository_Interface
{
    public interface IE_BookRepository
    {
        Task<bool> CreateBook(CreateBookDTO createBookDTO);

        Task<Book> UpdateBook(int bookId, UpdateBookDTO updateBookDTO);

        // public  Task<IEnumerable<SearchBookDTO>> SearchBooks(string author, string title);


        public Task<IEnumerable<SearchBookDTO>> SearchBooks_IZU(string author, string title);

    }
}

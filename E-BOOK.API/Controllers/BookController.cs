using E_BOOK.API.Repository.Repository_Interface;
using E_BOOK.API.Service.Service_Interface;
using Microsoft.AspNetCore.Mvc;

namespace E_BOOK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IE_BookRepository _BookRepository;
        private readonly ICloudinaryService _cloudinaryService;

        public BookController(IE_BookRepository e_BookRepository, ICloudinaryService cloudinaryService)
        {
            _BookRepository = e_BookRepository;
            _cloudinaryService = cloudinaryService;
        }




        [HttpGet]
        public async Task<ActionResult> GetAllBooks(int page = 1, int perpage = 5)
        {
            try
            {
                var books = await _BookRepository.GetALLBook();
                if (books.Count() > 0)
                {
                    var paged = _BookRepository.Paginate(books.ToList(), perpage, page);

                    return Ok(paged);
                }
                return Ok(books);
            }
            catch (Exception)
            {
                return BadRequest("Error retrieving book from database");
            }
        }





        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBookById(int Id)
        {

            try
            {
                if (Id <= 0)
                {
                    return BadRequest("Invalid parameter");
                }

                var result = await _BookRepository.GetBookById(Id);

                if (result == null)
                {
                    return NotFound("No record found");
                }

                return Ok(result);

            }
            catch
            {
                return BadRequest("Error getting book from database");

            }
        }



        [HttpDelete]

        public async Task<IActionResult> DeleteBook(int Id)
        {
            try
            {

                var result = await _BookRepository.RemoveBook(Id);


                if (!result)
                {
                    return NotFound("Failed to delete Book");
                }

                return Ok($"Book Deleted {result}");

            }
            catch
            {
                return BadRequest("Error deleting book from database");


            }


        }


        [HttpPatch("photos/{Id}")]
        public async Task<IActionResult> UploadPhoto(IFormFile file, int Id)
        {
            var book = await _BookRepository.GetBookById(Id);
            if (book == null)
            {
                return NotFound("Book not available");
            }

            var result = await _cloudinaryService.UploadPhoto(file, Id);

            if (result != null)
            {
                book.BookImg = result.Url.ToString();
                await _BookRepository.UpdateBook(book);


                return Ok(result.Url.ToString());

            }
            else
            {
                return BadRequest("Upload was not successful");
            }



        }

        [HttpGet("PopularBooks")]
        public async Task<ActionResult> GetAllPopularBooks(int page = 1, int perpage = 5)
        {
            try
            {
                var PopularBooks = _BookRepository.PopularBook();
                if (PopularBooks.Count() > 0)
                {
                    var paged = _BookRepository.Paginate(PopularBooks.ToList(), perpage, page);

                    return Ok(paged);
                }
                return Ok(PopularBooks);
            }
            catch (Exception)
            {
                return BadRequest("Error retrieving Popularbooks from database");
            }
        }

        [HttpGet("RecentBooks")]

        public async Task<ActionResult> RecentBooks(int page = 1, int perpage = 5)
        {
            try
            {
                var RecentBooks = _BookRepository.RecentBook();
                if (RecentBooks.Count() > 0)
                {
                    var paged = _BookRepository.Paginate(RecentBooks.ToList(), perpage, page);

                    return Ok(paged);
                }
                return Ok(RecentBooks);
            }
            catch (Exception)
            {
                return BadRequest("Error retrieving Recentbooks from database");
            }
        }





    }
}

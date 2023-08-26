using Microsoft.AspNetCore.Mvc;
using Task3.DataModel;
using Microsoft.EntityFrameworkCore;
using Final3.ViewModels;
using static System.Reflection.Metadata.BlobBuilder;

namespace Final3.Controllers
{
    [ApiController]
    [Route("controller")]
    public class EntityController : ControllerBase
    {
        private MyContext _context;
        public EntityController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public JsonResult getAllBooks()
        {
            var books = _context.Books.ToList();
            /*var books = (from book in _context.Books
                         join author in _context.Authors on book.BookId equals author.AuthorId into details
                         from author in details.DefaultIfEmpty()
                         select new
                         {
                             book = book != null ? book.Name : "No book",
                             authorName = author != null ? author.AuthorName : "No author"
                         }).ToList();*/

            return new JsonResult(books);
        }

        [HttpGet]
        [Route("getAllAuthors")]
        public JsonResult getAllAuthors()
        {
            var authors = _context.Authors.ToList();
            return new JsonResult(authors);
        }

        [HttpGet]
        [Route("getAllBorrower")]
        public JsonResult GetAllBorrower()
        {
            var borrow = (from borrower in _context.Borrower
                          join history in _context.BorrowHistory
                          on borrower.Id equals history.BorrowerId
                          select new
                          {
                              Borrower = borrower.BorrowerName,
                              History = history.Borrower.Id
                          });
            return new JsonResult(borrow);

        }

        [HttpPost]
        [Route("BorrowBook")]
        public void BorrowBook(BorrowBookViewModel model)
        {
            var BorrowHistoryModel = new BorrowHistory()
            {
                BookId = model.bookId,
                BorrowerId = model.borrowerId,
                IsReturn = false
            };
            try
            {
                _context.BorrowHistory.Add(BorrowHistoryModel);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail!");
            }

        }

        [HttpPut]
        [Route("ReturnBorrowedBook")]
        public void ReturnBorrowedBook(ReturnBorrowBook model)
        {
            try
            {
                _context.BorrowHistory.Where(b => b.BookId == model.BookId).ToList().ForEach(b => { b.IsReturn = true; });
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fail!");
            }
        }

        [HttpPost]
        [Route("AddNewBook")]
        public IActionResult AddNewBook(BookViewModel model)
        {

            var addBook = new Books()
            {
                Name = model.Name,
                Genre = model.Genre,
                AuthorId = model.AuthorId,
                PublisherId = model.PublisherId,

            };

            _context.Books.Add(addBook);
            _context.SaveChanges();
            return Ok(addBook);

        }

        [HttpGet("GetByGenre")]
        public JsonResult GetByGenre([FromQuery] GetByGenreViewModel model)
        {
            var result = _context.Books.Where(b => b.Genre == model.GenreName).ToList();
            return new JsonResult(result);
        }

        [HttpGet("GetByBrrowerId")]
        public JsonResult GetByBrrowerId([FromQuery] GetByBorrowerIdViewModel model)
        {
            var result = (from bh in _context.BorrowHistory
                          join b in _context.Books
                          on bh.BookId equals b.BookId
                          where bh.BorrowerId == model.BorrowerId
                          select new
                          {
                              BookName = b.Name,
                              Genre = b.Genre,
                              BookId = b.BookId

                          });
            return new JsonResult(result);
        }

        [HttpGet("GetAuthorsCountOfBooks")]
        public JsonResult GetAuthorsCountOfBooks()
        {
            var authorBookCounts = _context.Books
            .GroupBy(book => book.Author)
            .Select(group => new
            {
                Author = group.Key.AuthorName,
                BookCount = group.Count()
            })
            .ToList();
            return new JsonResult(authorBookCounts);
        }

        [HttpGet("MostBorrowedBook")]
        public JsonResult MostBorrowedBook()
        {
            var topBorrower = _context.BorrowHistory
        .GroupBy(record => record.Borrower)
        .OrderByDescending(group => group.Count())
        .Select(group => new
        {
            Borrower = group.Key.BorrowerName,
            BorrowedBooksCount = group.Count()
        })
        .FirstOrDefault();

            return new JsonResult(topBorrower);
        }





    }


}

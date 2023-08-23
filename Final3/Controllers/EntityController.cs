using Microsoft.AspNetCore.Mvc;
using Task3.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Final3.Controllers
{
    [ApiController]
    [Route("controller")]
    public class EntityController : ControllerBase
    {
        private Context _context;
        public EntityController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route ("GetAllBooks")]
        
     public JsonResult getAllBooks()
        {

            //var books = _context.Books.ToList();
            var books = (from book in _context.Books
                         join author in _context.Authors on book.BookId equals author.AuthorId into details
                         from author in details.DefaultIfEmpty()
                         select new
                         {
                             book = book != null ? book.Name : "No book",
                             authorName = author != null ? author.AuthorName : "No author"
                         }).ToList();

            return new JsonResult(books);
        }
        [HttpGet]
        [Route ("getAllAuthors")]
    public JsonResult getAllAuthors()
        {
            var authors = _context.Authors.ToList();
            return new JsonResult(authors);
        }
        [HttpGet]
        [Route ("getAllBorrower")]
        public JsonResult GetAllBorrower()
        {
            var borrow = (from borrower in _context.Borrower
                          join history in _context.BorrowHistory on borrower.BorrowerId equals history.Borrower.BorrowerId
                          select new {
                            Borrower = borrower.BorrowerName,
                            History = history.Borrower.BorrowerId
                          });
            return new JsonResult(borrow);  
        }
    }

}

using System.ComponentModel.DataAnnotations;

namespace Task3.DataModel
{
    public class Borrower
    {
        [Key]
        public int BorrowerId { get; set; }
        
        public string BorrowerName { get; set; }

        public List <Books> Books { get; set; }
    }
}

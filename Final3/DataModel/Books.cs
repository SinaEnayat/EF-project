using System.ComponentModel.DataAnnotations;

namespace Task3.DataModel
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        
        public string Name { get; set; }

        public string genre { get; set; }

        public Authors Authors { get; set; }

        public Publisher Publisher { get; set; }

        //public Borrower Borrower { get; set; }
    }
}

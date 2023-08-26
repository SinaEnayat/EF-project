using System.ComponentModel.DataAnnotations;

namespace Task3.DataModel
{
    public class BorrowHistory
    {
        [Key]
        public int Id { get; set; }

        public Books Book { get; set; }

        public int BookId { get; set; }

        public Borrower Borrower { get; set; }

        public int BorrowerId { get; set; }

       // public DateTime Date { get; set; }

        public bool IsReturn { get; set; }


    }
}

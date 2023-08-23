using System.ComponentModel.DataAnnotations;

namespace Task3.DataModel
{
    public class BorrowHistory
    {
        [Key]
        public int HistoryId { get; set; }

        public Books Books { get; set; }
        
        public Borrower Borrower { get; set; }

        public DateTime DateTime { get; set; }
        
        public bool IsAvailable { get; set; }


    }
}

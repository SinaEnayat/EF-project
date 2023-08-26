using System.ComponentModel.DataAnnotations;

namespace Task3.DataModel
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public Authors Author { get; set; }

        public int AuthorId { get; set; }

        public Publisher Publisher { get; set; }

        public int PublisherId { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Task3.DataModel
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        public string PublisherName { get; set; }

        public List <Books> Books { get; set; }    

    }
}

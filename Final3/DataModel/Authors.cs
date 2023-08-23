using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Task3.DataModel
{
    public class Authors
    {
        [Key]
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public List<Books> Books { get; set; }


    }
}

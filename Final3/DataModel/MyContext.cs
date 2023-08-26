using Microsoft.EntityFrameworkCore;

namespace Task3.DataModel
{
    public class MyContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Borrower> Borrower { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BorrowHistory> BorrowHistory { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.; Database = TaskDB; Integrated Security = True; Encrypt = False;");
        }


    }
}

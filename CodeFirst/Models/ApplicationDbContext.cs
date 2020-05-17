using System.Data.Entity;

namespace CodeFirst.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        : base("name=DefaultConnection")
        {
        }
    }
}

using EstudanteCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EstudanteCRUD.Data
{
    public class EstudanteCrudDbContext : DbContext
    {
        public EstudanteCrudDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

    }
}

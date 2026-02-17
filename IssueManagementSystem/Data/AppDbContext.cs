using IssueManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueManagementSystem.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Issue> Issues { get; set; }
    }
}

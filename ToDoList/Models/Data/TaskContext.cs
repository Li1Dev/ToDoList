using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models.Data
{
    public class TaskContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; } = null!;
        public TaskContext()
        { 
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ToDoList;Trusted_Connection=True;");
        }
    }
}

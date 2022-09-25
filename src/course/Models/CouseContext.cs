
using Microsoft.EntityFrameworkCore;
public class CourseContext : DbContext
{
    public CourseContext(DbContextOptions<CourseContext> options) : base(options) { }
    public DbSet<Course>? Courses { get; set; }
    public DbSet<Registration>? Registrations { get; set; }
    public DbSet<Account>? Accounts{get;set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Registration>().HasOne(p=>p.Course).WithMany(p=>p.Registrations);
        modelBuilder.Entity<Registration>().HasOne(p=>p.Account).WithMany(p=>p.Registrations);
    }
}
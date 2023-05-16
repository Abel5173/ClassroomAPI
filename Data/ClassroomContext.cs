using ClassroomAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace ClassroomAPI.Data{
    public class ClassroomContext : DbContext {
    public ClassroomContext(DbContextOptions<ClassroomContext> options)
        : base(options) { }

    public DbSet<Classroom> classrooms { get; set; }
}
}
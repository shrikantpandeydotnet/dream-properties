using DreamProperties.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<ContactMessage> ContactMessages { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Create Message for Stored Procedure Calling
    public async Task SaveContactMessageAsync(string name, string email, string subject, string message)
    {
        var parameters = new SqlParameter[]
        {
            new SqlParameter("@name", name), // 
            new SqlParameter("@email", email),
            new SqlParameter("@subject", subject),
            new SqlParameter("@message", message),
        };

        await Database.ExecuteSqlRawAsync("EXEC InsertContactMessage @name, @email, @subject, @message", parameters);
    }
}

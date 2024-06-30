using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DbInitiallizer
    {
        public static void InitializeDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace AnnouncementAPI
{
    public class Startup
    {
        public void ConfigurationServices(IServiceCollection services)
        {
            var builder = WebApplication.CreateBuilder();
            string connString = builder.Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AnnouncementAPI.Data.AnnouncementsContext>(options =>
                        options.UseSqlServer(connString));
        }
    }

}

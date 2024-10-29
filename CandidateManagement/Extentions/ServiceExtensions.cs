using CandidateManagement.Application.IServices;
using CandidateManagement.Application.Services;
using CandidateManagement.Domain.IRepositories;
using CandidateManagement.Infrastructure.Data;
using CandidateManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CandidateManagement.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<ICandidateService, CandidateService>();
        }
    }
}


using CapiStay.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CapiStay.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CapiStay")
            ?? throw new InvalidOperationException(
                "The connection string 'CapiStay' was not found.");

        services.AddDbContext<CapiStayDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }
}

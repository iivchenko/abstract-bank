using AbstractBank.Application.Common;
using AbstractBank.Domain.AccountAggregate;
using AbstractBank.Domain.CustomerAggregate;
using AbstractBank.Domain.TransactionAggregate;
using AbstractBank.Infrastructure;
using AbstractBank.Infrastructure.AccountAggregate;
using AbstractBank.Infrastructure.CustomerAggregate;
using AbstractBank.Infrastructure.TransactionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IAccountRepository, AccountRepository>()
            .AddScoped<ITransactionRepository, TransactionRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("AbstractBank"));
        }
        else
        {
            services
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        return services;
    }
}

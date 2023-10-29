using AbstractBank.Domain.CustomerAggregate;
using Microsoft.EntityFrameworkCore;

namespace AbstractBank.Infrastructure.CustomerAggregate;

public sealed class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Customer?> FindById(Guid id)
    {
        return await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);
    }
}

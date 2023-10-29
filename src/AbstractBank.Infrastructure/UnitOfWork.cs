using AbstractBank.Application.Common;
using AbstractBank.Domain.Common;
using MediatR;

namespace AbstractBank.Infrastructure;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public UnitOfWork(ApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task SaveChanges()
    {
        var entities = 
            _context
            .ChangeTracker
              .Entries<BaseEntity>()
              .Where(e => e.Entity.Events.Any())
              .Select(e => e.Entity);

        var domainEvents = entities
            .SelectMany(e => e.Events)
            .ToList();

        entities.ToList().ForEach(e => e.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent);
        }

        await _context.SaveChangesAsync();
    }
}
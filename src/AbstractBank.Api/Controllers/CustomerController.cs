using AbstractBank.Application.Commands.CreateNewAccount;
using AbstractBank.Application.Queries.GetCustomerOverviewById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AbstractBank.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<GetCustomerOverviewByIdQueryResponse> Get(Guid id)
    {
        // Note: Instead of returing Application layer resposne it would be better
        // to have its own Presentation Mode.
        // Will implemented it if I will have more time
        return await _mediator.Send(new GetCustomerOverviewByIdQuery(id));
    }

    [HttpPost("{customerId}/accounts/new")]
    public async Task<CreateNewAccountCommandResponse> CreateNewCustomerAccount(Guid customerId, decimal credits)
    {
        // Note: Instead of returing Application layer resposne it would be better
        // to have its own Presentation Mode.
        // Will implemented it if I will have more time
        return await _mediator.Send(new CreateNewAccountCommand(customerId, credits));
    }
}

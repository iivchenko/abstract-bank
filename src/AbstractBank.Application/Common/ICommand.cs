using MediatR;

namespace AbstractBank.Application.Common;

public interface ICommand<TResponse> : IRequest<TResponse>
{
}

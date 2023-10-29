using MediatR;

namespace AbstractBank.Application.Common;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}

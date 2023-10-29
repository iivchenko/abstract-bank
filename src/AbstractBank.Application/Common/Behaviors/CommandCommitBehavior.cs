using MediatR;

namespace AbstractBank.Application.Common.Behaviors;

public sealed class CommandCommitBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : notnull
{
    private readonly IUnitOfWork _unitOfWork;

    public CommandCommitBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();

        if (request is ICommand<TResponse>)
        {
            await _unitOfWork.SaveChanges();
        }

        return response;
    }
}
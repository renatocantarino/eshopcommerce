using MediatR;

namespace Kernel.CQRS;

public interface ICommand : ICommand<Unit>
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

public interface ICommandHandler<in TCommand>
    : IRequestHandler<TCommand, Unit> where TCommand : ICommand<Unit>

{
}

public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
                                           where TResponse : notnull
{
}
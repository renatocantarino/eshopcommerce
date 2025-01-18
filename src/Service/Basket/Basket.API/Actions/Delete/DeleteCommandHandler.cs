﻿namespace Basket.API.Actions.Delete;

public record DeleteCommand(string UserName) : ICommand<DeleteCommandResult>;
public record DeleteCommandResult(bool isSucess);

public class DeleteCommandValidator : AbstractValidator<DeleteCommand>
{
    public DeleteCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("{PropertyName} is required");
    }
}

public class DeleteCommandHandler(IBasketRepository repository) : ICommandHandler<DeleteCommand, DeleteCommandResult>
{
    public async Task<DeleteCommandResult> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        return new DeleteCommandResult(await repository.Delete(request.UserName, cancellationToken));
    }
}
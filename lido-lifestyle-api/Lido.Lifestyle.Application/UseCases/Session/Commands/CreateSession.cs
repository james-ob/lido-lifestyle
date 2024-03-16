using Lido.Lifestyle.Application.Common;
using Lido.Lifestyle.Domain.Enums;
using MediatR;
using Riok.Mapperly.Abstractions;
using Entities = Lido.Lifestyle.Domain.Entities;

namespace Lido.Lifestyle.Application.UseCases.Session.Commands;

public record CreateSessionCommand : IRequest<int>
{
    public int Lengths { get; init; }
    public DateOnly Date { get; init; }
    public Stroke Stroke { get; init; }
}

[Mapper]
public static partial class SessionMapper
{
    public static partial Entities.Session CommandToSession(CreateSessionCommand command);
}

public class CreateSessionCommandHandler : IRequestHandler<CreateSessionCommand, int>
{
    private readonly ILidoLifestyleDbContext dbContext;

    public CreateSessionCommandHandler(ILidoLifestyleDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<int> Handle(CreateSessionCommand command, CancellationToken cancellationToken)
    {
        var session = SessionMapper.CommandToSession(command);
        dbContext.Sessions.Add(session);
        await dbContext.SaveChangesAsync(cancellationToken);
        return session.Id;
    }
}
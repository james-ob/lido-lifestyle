using Lido.Lifestyle.Application.UseCases.Session.Commands;
using Lido.Lifestyle.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Riok.Mapperly.Abstractions;

namespace Lido.Lifestyle.Api.Controllers.Session;


public record CreateSessionRequest
{
    public int Lengths { get; init; }
    public DateTime Date { get; init; }
    public Stroke Stroke { get; init; }
}

[Mapper]
public static partial class CreateSessionMapper
{
    public static partial CreateSessionCommand RequestToCommand(CreateSessionRequest request);
    public static DateOnly DateOnlyToDateOnly(DateTime dateTime) => DateOnly.FromDateTime(dateTime);
}

[ApiController]
[Route("/session")]
public class CreateSessionController : ControllerBase
{
    private readonly ISender sender;

    public CreateSessionController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpPost(Name = "CreateSession")]
    public async Task<int> Create([FromBody] CreateSessionRequest request)
    {
        var command = CreateSessionMapper.RequestToCommand(request);
        return await sender.Send(command);
    }
}
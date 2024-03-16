using Lido.Lifestyle.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lido.Lifestyle.Application.Common;

public interface ILidoLifestyleDbContext
{
    DbSet<Session> Sessions { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
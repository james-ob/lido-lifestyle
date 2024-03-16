using Lido.Lifestyle.Application.Common;
using Lido.Lifestyle.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lido.Lifestyle.Infrastructure.Data;

public class LidoLifestyleDbContext : DbContext, ILidoLifestyleDbContext
{
    public LidoLifestyleDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "blogging.db");
    }

    public DbSet<Session> Sessions => Set<Session>();

    public string DbPath { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

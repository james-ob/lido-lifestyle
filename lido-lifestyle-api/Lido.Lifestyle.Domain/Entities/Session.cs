using Lido.Lifestyle.Domain.Enums;

namespace Lido.Lifestyle.Domain.Entities;

public class Session
{
    public int Id { get; private set; }
    public int Lengths { get; private set; }
    public DateOnly Date { get; private set; }
    public Stroke Stroke { get; private set; }

    public Session(int lengths, DateOnly date, Stroke stroke)
    {
        Lengths = lengths;
        Date = date;
        Stroke = stroke;
    }
}
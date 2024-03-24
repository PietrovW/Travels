namespace Travels.Domain.Travel.V1.Commands;
public record UpdateTravelsComman
{
    public long Id { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public DateTimeOffset Created { get; init; } = DateTimeOffset.Now;
}

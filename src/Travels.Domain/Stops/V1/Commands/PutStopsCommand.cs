
namespace Travels.Domin.V1.Command;

public record PutStopsCommand
{
    public long Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public DateTimeOffset Created { get; init; } = DateTimeOffset.UtcNow;
}

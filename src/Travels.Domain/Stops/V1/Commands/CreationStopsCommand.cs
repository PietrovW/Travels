
namespace Travels.Domin.V1.Command;

public record CreationStopsCommand
{
    public string Name { get; init; } = default!;
    public string Description { get; init;} = default!;
    public DateTimeOffset Created
    {
        get; init;
    } = DateTimeOffset.Now;
}

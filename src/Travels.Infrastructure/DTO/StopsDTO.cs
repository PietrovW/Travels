namespace Travels.Infrastructure.DTO
{
    public class StopsDTO
    {
        public string Name { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public int Order { get; private set; }
    }
}

namespace Catalog.Dtos
{
     public record ItemDto
    {
        public Guid Id { get; init; } //init-only properties for only allowigng setting value once
        public string Name { get; init; }
        public  decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }


    }
}
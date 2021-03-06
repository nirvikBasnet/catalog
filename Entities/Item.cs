using System;
namespace Catalog.Entities
{
    //Record Types : Class + immutable objects supported + with-expression + value-based equality support
    public record Item
    {
        public Guid Id { get; init; } //init-only properties for only allowigng setting value once
        public string Name { get; init; }
        public  decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }


    }
}
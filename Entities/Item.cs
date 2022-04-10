using System;
namespace Catalog.Entities
{
    //Record Types : Class + immutable objects supported + with-expression + value-based equality support
    public record Item
    {
        public Guid Id { get; init; } //init-only properties for only allowigng setting value once
        
    }
}
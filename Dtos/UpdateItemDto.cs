using System.ComponentModel.DataAnnotations; //this is for data validation 
namespace Catalog.Dtos
{
    public record UpdateItemDto
    {
        [Required]
       public string Name { get; init; }

       [Required]
       [Range(1,1000)]
        public  decimal Price { get; init; }
    }
}
using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;
using Catalog.Dtos;

namespace Catalog.Controllers{

    

    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase{

        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository){
           this.repository = repository;
        } //this is how to implement dependency injection

        //Get -> /api/items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems(){

            //project it to new DTO

            var items = repository.GetItems().Select(item => item.AsDto());

            return items;
           
        }

        //Get /items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id){ //ActionResult<T> -> lets return more than one type of method 

            var item = repository.GetItem(id);

            if(item is null){
                return NotFound();
            }

            return Ok(item.AsDto()); //this returns null because in ItemsController() we created a new instance of InMemItemsRepository()
                             //this can be solved by using Dependency Injection
                             //Dto is what we want to return to the client
        }
        //Post /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto){

           Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
              };
              repository.CreateItem(item);

              return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
           
        }

        //put /items/
        [HttpPut("{id}")]

        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto){

            var existingItem = repository.GetItem(id);

            if(existingItem is null){
                return NotFound();
            }

            Item updatedItem = existingItem with { //taking advantage of the record type to create a copy of the existing item and modifying two properties
                Name = itemDto.Name,
                Price = itemDto.Price
            };
            
            repository.UpdateItem(updatedItem);

            return NoContent();

        }

        
    }
}
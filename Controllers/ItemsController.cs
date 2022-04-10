using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;

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
        public IEnumerable<Item> GetItems(){

            var items = repository.GetItems();

            return items;
           
        }

        //Get /items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id){ //ActionResult<T> -> lets return more than one type of method 

            var item = repository.GetItem(id);

            if(item is null){
                return NotFound();
            }

            return Ok(item); //this returns null because in ItemsController() we created a new instance of InMemItemsRepository()
                             //this can be solved by using Dependency Injection
        }

    }
}
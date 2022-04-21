using Catalog.Entities;
namespace Catalog.Repositories
{


    public class InMemItemsRepository : IItemsRepository
    {

        private readonly List<Item> items = new(){ //Target-typed new expression

        new Item {Id=Guid.NewGuid(),Name="Portion",Price=10,CreatedDate=DateTimeOffset.UtcNow},
        new Item {Id=Guid.NewGuid(),Name="Iron Sword",Price=20,CreatedDate=DateTimeOffset.UtcNow},
        new Item {Id=Guid.NewGuid(),Name="Bronze Shield",Price=30,CreatedDate=DateTimeOffset.UtcNow}

        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id); //finding the item with the same id
            items[index] = item;
        }
    }
}
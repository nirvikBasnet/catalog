using Catalog.Entities;
namespace Catalog.Repositories
{

    //this is for dependency injection
        public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
    }
}
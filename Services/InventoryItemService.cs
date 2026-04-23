using InventoryService.Domain;

namespace InventoryService.Services
{
    public class InventoryItemService
    {
        public List<InventoryItem> GetAllItems()
        {
            var items = new List<InventoryItem>
            {
                new InventoryItem { Id = 1, Description = "Widget A", ManufacturerId = 100, RetailCost = 9.99m },
                new InventoryItem { Id = 2, Description = "Widget B", ManufacturerId = 101, RetailCost = 19.99m },
                new InventoryItem { Id = 3, Description = "Widget C", ManufacturerId = 102, RetailCost = 29.99m },
            };

            return items;
        }
    }
}
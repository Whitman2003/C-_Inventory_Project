using InventoryService.Domain;
using InventoryService.Models;
using System.Linq;

namespace InventoryService.Services
{
    public class InventoryItemService
    {
        //Storage for the Transactions
        private readonly List<InventoryTransaction> _transactions = new();

        //Returns the list of items
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

        public void AddTransaction(CreateInventoryTransactionRequest request)
        {
            var transaction = new InventoryTransaction
            {
                UserId = request.UserId,
                InventoryItemID = request.InventoryItemId,
                QuantityChanged = request.QuantityChanged,
                Timestamp = DateTime.UtcNow
            };

            _transactions.Add(transaction);
        }

        public List<InventoryTransaction> GetTransactions()
        {
            return _transactions.OrderByDescending(t => t.Timestamp).ToList();
        }
    }
}
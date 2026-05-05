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
        public List<InventoryItemResponse> GetAllItems()
        {
            var items = new List<InventoryItem>
            {
                new InventoryItem { Id = 1, Description = "Widget A", ManufacturerId = 100, RetailCost = 9.99m },
                new InventoryItem { Id = 2, Description = "Widget B", ManufacturerId = 101, RetailCost = 19.99m },
                new InventoryItem { Id = 3, Description = "Widget C", ManufacturerId = 102, RetailCost = 29.99m },
            };

            var response = new List<InventoryItemResponse>();

            foreach (var item in items)
            {
                var totalQuantityChanged = _transactions
                    .Where(t => t.InventoryItemID == item.Id)
                    .Sum(t => t.QuantityChanged);

                response.Add(new InventoryItemResponse
                {
                    ResponseId = item.Id,
                    ResponseDescription = item.Description,
                    ResponseManufacturerId = item.ManufacturerId,
                    ResponseRetailCost = item.RetailCost,
                    ResponseCurrentQuantity = totalQuantityChanged
                });
            }

            return response;
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

        public InventoryItemResponse? GetItemById(int id)
        {
            var item = GetAllItems().FirstOrDefault(i => i.ResponseId == id);
            
            if (item == null)
            {
                return null; // Item not found
            }
            
            return item;
        }
    }
}
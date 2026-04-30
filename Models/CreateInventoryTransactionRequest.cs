namespace InventoryService.Models
{
    public class CreateInventoryTransactionRequest
    {
        public int UserId { get; set; }
        public int InventoryItemId { get; set; }
        public int QuantityChanged { get; set; }
    }
}
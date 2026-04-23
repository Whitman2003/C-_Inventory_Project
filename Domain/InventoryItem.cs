namespace InventoryService.Domain
{
    public class InventoryItem 
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int ManufacturerId { get; set; }
        public decimal RetailCost { get; set; }
    }
}
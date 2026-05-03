namespace InventoryService.Models
{
    public class InventoryItemResponse
    {
        public int ResponseId { get; set; }
        public string? ResponseDescription { get; set; }
        public int ResponseManufacturerId { get; set; }
        public decimal ResponseRetailCost { get; set; }
        public int ResponseCurrentQuantity { get; set; }
    }
}
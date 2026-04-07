public class InventoryTransaction
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int InventoryItemID { get; set; }
    public int QuantityChanged { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
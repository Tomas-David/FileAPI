namespace FileAPI.Model
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public required string ItemName { get; set; }
        public DateTime CreatedAt { get; set; }  = DateTime.Now;
    }
}

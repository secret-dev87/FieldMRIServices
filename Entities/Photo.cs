namespace FieldMRIServices.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string InventoryName { get; set; }
        public string Image { get; set; }
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
    }
}

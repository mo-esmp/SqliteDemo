namespace Core.Products
{
    public class ProductGroupDto
    {
        // public int Id { get; set; }

        public string Title { get; set; }

        public bool IsAvtive { get; set; }

        public byte[] Icon { get; set; }

        public int ProductGroupTypeId { get; set; }
    }
}
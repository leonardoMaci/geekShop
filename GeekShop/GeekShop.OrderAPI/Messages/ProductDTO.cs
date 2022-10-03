namespace GeekShop.OrderAPI.Messages
{
    public class ProductDTO
    {
        public long ID { get; set; }
        public string NM_Product { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public string Image_Url { get; set; }
    }
}
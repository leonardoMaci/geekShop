namespace GeekShop.CartAPI.Data.DTOs
{
    public class CartDetailDTO
    {
        public long Id { get; set; }
        public long CartHeaderId { get; set; }

        public virtual CartHeaderDTO? CartHeader { get; set; }

        public long ProductId { get; set; }

        public virtual ProductDTO Product { get; set; }

        public int Count { get; set; }
    }
}

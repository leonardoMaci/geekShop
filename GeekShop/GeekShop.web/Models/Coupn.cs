namespace GeekShop.web.Models
{
    public class Coupon
    {
        public long Id { get; set; }
        public string CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}

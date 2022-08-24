using GeekShop.api.Model.Enum;

namespace GeekShop.web.Models
{
    public class Product
    {
        public long ID { get; set; }
        public string NM_Product { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public CategoryEnum Category { get; set; }
        public string CategoryName => Enum.GetName(typeof(CategoryEnum), Category);
        public string Image_Url { get; set; }
        public int Count { get; set; }
        public string SubstringName => NM_Product.Length < 24 ? NM_Product : $"{NM_Product.Substring(0, 21)} ...";
        public string SubstringDescription => Description.Length < 355 ? NM_Product : $"{Description.Substring(0, 352)} ...";
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShop.CouponAPI.Model.Base
{
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        public long ID { get; set; }
    }
}

﻿using GeekShop.api.Model.Base;
using GeekShop.api.Model.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShop.api.Model
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        [Required]
        [Column("NM_Product")]
        [StringLength(150)]
        public string NM_Product { get; set; }

        [Required]
        [Column("Price")]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Column("Description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Column("Category")]
        public CategoryEnum Category { get; set; }

        [Column("Image_Url")]
        [StringLength(300)]
        public string Image_Url { get; set; }
    }
}

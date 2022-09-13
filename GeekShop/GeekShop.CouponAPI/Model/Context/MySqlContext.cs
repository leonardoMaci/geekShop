using Microsoft.EntityFrameworkCore;

namespace GeekShop.CouponAPI.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                ID = 1,
                CouponCode = "LEONARDO_2022_10",
                DiscountAmount = 10
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                ID = 2,
                CouponCode = "LEONARDO_2022_15",
                DiscountAmount = 15
            });
        }
    }
}

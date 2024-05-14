using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantOrderingSystemApp.EntityLayer.Entities;


namespace RestaurantOrderingSystemApp.DataAccessLayer.Concrete
{
    public class RestaturantOrderingSystemContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet <About> Abouts { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<MenuTable> MenuTables { get; set; }

        public DbSet<Message> Messages { get; set; }
        public DbSet<MoneyCase> MoneyCases { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        


    }
}

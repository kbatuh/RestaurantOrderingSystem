namespace RestaurantOrderingSystemApp.EntityLayer.Entities
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public string Description { get; set; }
        public string CustomerCode { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}

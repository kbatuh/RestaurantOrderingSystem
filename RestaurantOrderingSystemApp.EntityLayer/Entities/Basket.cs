namespace RestaurantOrderingSystemApp.EntityLayer.Entities
{
    public class Basket
    {
        public int BasketID { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public string CustomerCode { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int MenuTableID { get; set; }
        public MenuTable MenuTable { get; set; }
    }
}

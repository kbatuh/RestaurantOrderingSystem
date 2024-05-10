namespace RestaurantOrderingSystemApp.EntityLayer.Entities
{
    public class MenuTable
    {
        public int MenuTableID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<Basket> Baskets { get; set; }
        public List<Order> Orders { get; set; }
    }
}

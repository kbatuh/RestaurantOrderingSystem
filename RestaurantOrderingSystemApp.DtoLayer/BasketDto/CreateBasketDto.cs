namespace RestaurantOrderingSystemApp.DtoLayer.BasketDto
{
    public class CreateBasketDto
    {
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public string CustomerCode { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
    }
}

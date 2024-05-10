namespace RestaurantOrderingSystemApp.WebUI.Dtos.BasketDtos
{
    public class ResultBasketWithProductDto
    {
        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductName { get; set; }
        public string CustomerCode { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
    }
}

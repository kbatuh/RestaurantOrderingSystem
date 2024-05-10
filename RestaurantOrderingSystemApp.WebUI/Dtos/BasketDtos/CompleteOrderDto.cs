using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantOrderingSystemApp.WebUI.Dtos.BasketDtos
{
    public class CompleteOrderDto
    {
        [Column(TypeName = "Date")]
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal FinalPrice { get; set; }
        public bool Status { get; set; }
        public int MenuTableID { get; set; }
        public string CustomerCode { get; set; }
    }
}

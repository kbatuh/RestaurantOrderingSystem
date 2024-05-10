namespace RestaurantOrderingSystemApp.DtoLayer.FeatureDto

{
    public class GetFeatureDto
    {
        public int FeatureID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}

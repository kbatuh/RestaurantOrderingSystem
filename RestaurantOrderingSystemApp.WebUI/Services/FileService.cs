namespace RestaurantOrderingSystemApp.WebUI.Services
{
    public class FileService
    {
        public static string Upload(IFormFile formfile)
        {
            string returnPath;
            if (formfile != null)
            {
                string imageExtension = Path.GetExtension(formfile.FileName);
                string randomName = Path.GetFileNameWithoutExtension(formfile.FileName)
                  + "_"
                  + Guid.NewGuid().ToString().Substring(0, 4)
                  + imageExtension;
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", randomName);
                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    formfile.CopyTo(stream);
                };
                
                returnPath = $"images/{randomName}";
            }
            else
            {
                returnPath = "images/default.jpg";
            }
            return returnPath;
        }
    }
}

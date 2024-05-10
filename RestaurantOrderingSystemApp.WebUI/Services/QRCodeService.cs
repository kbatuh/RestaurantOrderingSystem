using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace RestaurantOrderingSystemApp.WebUI.Services
{
    public class QRCodeService
    {
        public static string GenerateQrCode(string qrcode)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator createQRCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap image = squareCode.GetGraphic(10))
                {
                    image.Save(memoryStream, ImageFormat.Png);
                    var qrCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                    return qrCodeImage;
                }
            }
        }
    }
}

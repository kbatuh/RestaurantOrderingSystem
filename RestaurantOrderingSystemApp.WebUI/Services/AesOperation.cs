using System.Security.Cryptography;
using System.Text;

namespace RestaurantOrderingSystemApp.WebUI.Services
{
    public class AesOperation
    {
        public static string Encode(string encodeMe)
        {
            byte[] encoded = Encoding.UTF8.GetBytes(encodeMe);
            return Convert.ToBase64String(encoded);
        }

        public static string Decode(string decodeMe)
        {
            try
            {
                byte[] encoded = Convert.FromBase64String(decodeMe);
                var decoded = Encoding.UTF8.GetString(encoded);
                try
                {
                    int.Parse(decoded);
                    return decoded;
                }
                catch (Exception)
                {
                    return "0";
                }
            }
            catch (Exception)
            {
                return "0";
            }
            
        }
    }
}

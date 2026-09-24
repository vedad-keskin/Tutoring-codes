using System.Drawing.Imaging;

namespace Studentska.WinApp.Helpers
{
    public class ImageHelper
    {
        public static Image ByteToImage(byte[] slikaAsByte)
        {
            //var ms = new MemoryStream(slikaAsByte);
            return Image.FromStream(new MemoryStream(slikaAsByte));            
        }
        public static byte[] ImageToByte(Image slikaAsImage)
        {
            var ms = new MemoryStream();
            slikaAsImage.Save(ms, ImageFormat.Png);
            return ms.ToArray();            
        }
    }
}

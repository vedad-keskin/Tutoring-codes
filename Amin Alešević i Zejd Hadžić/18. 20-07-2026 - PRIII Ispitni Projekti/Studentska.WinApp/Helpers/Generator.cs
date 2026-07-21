using Studentska.Servis;
using Studentska.Servis.Servisi;

using System.Text;

namespace Studentska.WinApp.Helpers
{
    public class Generator
    {
        public static string GenerisiIndeks()
        {
            return $"IB{((DateTime.Now.Year - 2000) * 10000) + new StudentServis().GetBrojStudenata() + 1}";
        }
        public static string GenerisiLozinku(int brojZnakova = 10)
        {
            string dozvoljniZnakovi = "abcdefghijkljmnoprstuvzwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()";
            Random rand = new Random();
            StringBuilder lozinka = new StringBuilder();//xQ1!2@abC3
            for (int i = 0; i < brojZnakova; i++)
                lozinka.Append(dozvoljniZnakovi[rand.Next(dozvoljniZnakovi.Length)]);
            return lozinka.ToString();
        }
    }

}

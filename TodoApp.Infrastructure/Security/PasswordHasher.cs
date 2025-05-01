using System.Security.Cryptography;
using System.Text;

namespace TodoApp.Infrastructure.Security
{
 
    public static class PasswordHasher
    {
        
        public static string Hash(string password)
        {
            using var sha = SHA256.Create();   // SHA256 hash algoritmasının yeni bir örneğini oluştur
            var bytes = Encoding.UTF8.GetBytes(password);   // Şifre metnini UTF-8 kodlaması kullanarak byte dizisine dönüştür
            var hash = sha.ComputeHash(bytes);   // Şifre byte'larının hash'ini hesapla
            return Convert.ToBase64String(hash);   // Oluşan hash'i depolama için base64 string'e dönüştür
        }

        public static bool Verify(string password, string hash)  /// Bir şifrenin daha önce oluşturulmuş hash ile eşleşip eşleşmediğini doğrular.
        {
            return Hash(password) == hash; // Verilen şifreyi hashleyip, saklanan hash ile karşılaştır
        }
    }
}

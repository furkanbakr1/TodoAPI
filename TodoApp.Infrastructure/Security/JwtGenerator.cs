using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TodoApp.Infrastructure.Security
{
    public static class JwtGenerator
    {
        public static string Generate(int userId, string username, string key)
        {


            // Token içerisine eklenecek kullanıcıya ait talep (claim) bilgileri
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),  // Kullanıcı ID'si
                new Claim(ClaimTypes.Name, username)  // Kullanıcı adı
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));  // Gizli anahtardan simetrik güvenlik anahtarı oluşturma
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);   // Token imzalamak için kullanılacak kimlik bilgileri ve algoritma seçimi

            var token = new JwtSecurityToken(
                issuer: "todoapi",  // Token'ı yayınlayan kaynak
                audience: "todoapi",  // Token'ın hedef kullanıcısı
                claims: claims,  // Kullanıcı talepleri
                expires: DateTime.Now.AddHours(12),  // Token geçerlilik süresi - 12 saat
                signingCredentials: credentials  // İmzalama bilgileri
            );

            return new JwtSecurityTokenHandler().WriteToken(token);  // Oluşturulan token'ı string formatına dönüştürme ve döndürme
        }
    }
}

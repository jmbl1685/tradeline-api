using BCrypt;
using System;

namespace TradeLine
{
    public static class ExtensionUtility
    {
        public static string GenerateUUID()
            => Guid.NewGuid().ToString().ToUpper();

        public static string PasswordEncrypt(this string Password)
            => BCryptHelper.HashPassword(Password, BCryptHelper.GenerateSalt());

        public static bool PasswordDecrypt(string Password, string HashedPassword)
           => BCryptHelper.CheckPassword(Password, HashedPassword);

    }
}

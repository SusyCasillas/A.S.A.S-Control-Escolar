using System.Text;

namespace A.S.A.S_Control_Escolar.ExternalTools
{
    public class EncryptedTools
    {
        public static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            string hs = hash.ToString();
            return hash.ToString();
        }
    }
}

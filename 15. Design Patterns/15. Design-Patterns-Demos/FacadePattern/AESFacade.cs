namespace FacadePattern
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    class AESFacade : IAESFacade
    {
        // Set your salt here, change it to meet your flavor:
        // The salt bytes must be at least 8 bytes.
        private static readonly byte[] SaltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        private const int DeriveBytesIterations = 1000;

        // TODO: remove code duplication!

        public byte[] AESEncrypt(byte[] bytesToBeEncrypted, string password)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password.ToCharArray());
                    var key = new Rfc2898DeriveBytes(passwordBytes, SaltBytes, DeriveBytesIterations);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(
                        ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                    }
                    byte[] encryptedBytes = ms.ToArray();
                    return encryptedBytes;
                }
            }
        }

        public byte[] AESDecrypt(byte[] bytesToBeDecrypted, string password)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password.ToCharArray());
                    var key = new Rfc2898DeriveBytes(passwordBytes, SaltBytes, DeriveBytesIterations);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                    }
                    byte[] decryptedBytes = ms.ToArray();
                    return decryptedBytes;
                }
            }
        }

        public string AESEncrypt(string message, string password)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message.ToCharArray());
            byte[] encryptedMessageBytes = AESEncrypt(messageBytes, password);
            string base64EncodedEncryptedMessage = Convert.ToBase64String(encryptedMessageBytes);
            return base64EncodedEncryptedMessage;
        }

        public string AESDecrypt(string base64EncodedEncryptedMessage, string password)
        {
            byte[] encryptedMessageBytes = Convert.FromBase64String(base64EncodedEncryptedMessage);
            byte[] decryptedMessageBytes = AESDecrypt(encryptedMessageBytes, password);
            string message = Encoding.UTF8.GetString(decryptedMessageBytes);
            return message;
        }
    }
}

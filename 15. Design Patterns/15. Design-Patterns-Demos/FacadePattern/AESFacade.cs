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
            using (var ms = new MemoryStream())
            {
                using (var AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var passwordBytes = Encoding.UTF8.GetBytes(password.ToCharArray());
                    var key = new Rfc2898DeriveBytes(passwordBytes, SaltBytes, DeriveBytesIterations);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(
                        ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                    }
                    var encryptedBytes = ms.ToArray();
                    return encryptedBytes;
                }
            }
        }

        public byte[] AESDecrypt(byte[] bytesToBeDecrypted, string password)
        {
            using (var ms = new MemoryStream())
            {
                using (var AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var passwordBytes = Encoding.UTF8.GetBytes(password.ToCharArray());
                    var key = new Rfc2898DeriveBytes(passwordBytes, SaltBytes, DeriveBytesIterations);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                    }
                    var decryptedBytes = ms.ToArray();
                    return decryptedBytes;
                }
            }
        }

        public string AESEncrypt(string message, string password)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message.ToCharArray());
            var encryptedMessageBytes = this.AESEncrypt(messageBytes, password);
            var base64EncodedEncryptedMessage = Convert.ToBase64String(encryptedMessageBytes);
            return base64EncodedEncryptedMessage;
        }

        public string AESDecrypt(string base64EncodedEncryptedMessage, string password)
        {
            var encryptedMessageBytes = Convert.FromBase64String(base64EncodedEncryptedMessage);
            var decryptedMessageBytes = this.AESDecrypt(encryptedMessageBytes, password);
            var message = Encoding.UTF8.GetString(decryptedMessageBytes);
            return message;
        }
    }
}

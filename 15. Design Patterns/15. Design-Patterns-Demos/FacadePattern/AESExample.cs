namespace FacadePattern
{
    using System;

    class AESExample
    {
        static void Main()
        {
            IAESFacade aes = new AESFacade();
            string msg = "I am a secret message.";
            string password = "s3cr3T!p@ss";
            string encryptedMsg = aes.AESEncrypt(msg, password);
            string decryptedMsg = aes.AESDecrypt(encryptedMsg, password);

            Console.WriteLine("Message: {0}", msg);
            Console.WriteLine("Encrypted: {0}", encryptedMsg);
            Console.WriteLine("Decrypted: {0}", decryptedMsg);
        }
    }
}

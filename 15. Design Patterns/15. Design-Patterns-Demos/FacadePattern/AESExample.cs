namespace FacadePattern
{
    using System;

    class AESExample
    {
        static void Main()
        {
            IAESFacade aes = new AESFacade();
            var msg = "I am a secret message.";
            var password = "s3cr3T!p@ss";
            var encryptedMsg = aes.AESEncrypt(msg, password);
            var decryptedMsg = aes.AESDecrypt(encryptedMsg, password);

            Console.WriteLine("Message: {0}", msg);
            Console.WriteLine("Encrypted: {0}", encryptedMsg);
            Console.WriteLine("Decrypted: {0}", decryptedMsg);
        }
    }
}

namespace FacadePattern
{
    interface IAESFacade
    {
        string AESEncrypt(string message, string password);

        byte[] AESEncrypt(byte[] bytesToBeEncrypted, string password);

        byte[] AESDecrypt(byte[] bytesToBeDecrypted, string password);

        string AESDecrypt(string encryptedMessage, string password);
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ComputeService.v1.Interfaces;

namespace ComputeService.v1.Services.Encryption
{
    public class AesService : IEncryption
    {
        private const int KeyLength = 32;
        private const int IvLength = 16;

        private const int KeySize = KeyLength * 8;
        private const int BlockSize = IvLength * 8;

        public string Encrypt(string data, string key, string iv, int iterations = 5000)
        {
            var encodedDataBytes = Encoding.UTF8.GetBytes(data);
            var encodedKeyBytes = Encoding.UTF8.GetBytes(key).Take(KeyLength).ToArray();
            var encodedIvBytes = Encoding.UTF8.GetBytes(iv).Take(IvLength).ToArray();

            var encryptedData = (byte[])Encrypt(encodedDataBytes, encodedKeyBytes, encodedIvBytes);

            return Convert.ToBase64String(encryptedData);
        }

        public IEnumerable<byte> Encrypt(IEnumerable<byte> data, IEnumerable<byte> key, IEnumerable<byte> iv, int iterations = 5000)
        {
            var givenData = (List<byte>) data;

            using var aes = AesSetUp(key, iv);
            using var memory = new MemoryStream(givenData.Count());
            using var crypto = new CryptoStream(memory, aes.CreateEncryptor(), CryptoStreamMode.Write);

            crypto.Write(givenData.ToArray(), 0, givenData.Count());
            crypto.FlushFinalBlock();

            return memory.ToArray();
        }

        public string Decrypt(string data, string key, string iv, int iterations = 5000)
        {
            var encodedDataBytes = Convert.FromBase64String(data);
            var encodedKeyBytes = Encoding.UTF8.GetBytes(key).Take(KeyLength).ToArray();
            var encodedIvBytes = Encoding.UTF8.GetBytes(iv).Take(IvLength).ToArray();

            var decryptedData = (byte[])Decrypt(encodedDataBytes, encodedKeyBytes, encodedIvBytes);

            return Encoding.UTF8.GetString(decryptedData);
        }

        public IEnumerable<byte> Decrypt(IEnumerable<byte> data, IEnumerable<byte> key, IEnumerable<byte> iv, int iterations = 5000)
        {
            var givenData = (List<byte>)data;

            using var aes = AesSetUp(key, iv);
            using var memory = new MemoryStream(givenData.Count());
            using var crypto = new CryptoStream(memory, aes.CreateDecryptor(), CryptoStreamMode.Write);

            crypto.Write(givenData.ToArray(), 0, givenData.Count());
            crypto.FlushFinalBlock();

            return memory.ToArray();
        }

        private static Aes AesSetUp(IEnumerable<byte> key, IEnumerable<byte> iv)
        {
            var aes = Aes.Create();

            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            aes.KeySize = KeySize;
            aes.BlockSize = BlockSize;

            aes.Key = key.ToArray();
            aes.IV = iv.ToArray();

            return aes;
        }
    }
}

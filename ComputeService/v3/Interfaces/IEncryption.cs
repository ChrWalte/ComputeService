using System.Collections.Generic;

namespace ComputeService.v3.Interfaces
{
    public interface IEncryption
    {
        string Encrypt(string data, string key, string iv, int iterations = 5000);

        IEnumerable<byte> Encrypt(IEnumerable<byte> data, IEnumerable<byte> key, IEnumerable<byte> iv, int iterations = 5000);

        string Decrypt(string data, string key, string iv, int iterations = 5000);

        IEnumerable<byte> Decrypt(IEnumerable<byte> data, IEnumerable<byte> key, IEnumerable<byte> iv, int iterations = 5000);
    }
}
using System.Collections.Generic;
using System.Security.Cryptography;
using ComputeService.v1.Interfaces;
using ComputeService.v1.Shared;

namespace ComputeService.v1.Services.Hash
{
    public class Sha1Service : IHash
    {
        public string Hash(string data, int iterations = 5000)
        {
            var givenData = Utilities.StringToBytes(data);
            var hashedData = Hash(givenData, iterations);
            return Utilities.HashBytesToString(hashedData);
        }

        public IEnumerable<byte> Hash(IEnumerable<byte> data, int iterations = 5000)
        {
            using var sha1 = SHA1.Create();
            var hashedData = IHash.Generate(sha1, data, iterations);
            return hashedData;
        }
    }
}

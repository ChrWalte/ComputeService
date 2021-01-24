using ComputeService.v3.Interfaces;
using ComputeService.v3.Shared;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ComputeService.v3.Services.Hash
{
    public class Md5Service : IHash
    {
        public string Hash(string data, int iterations = 5000)
        {
            var givenData = Utilities.StringToBytes(data);
            var hashedData = Hash(givenData, iterations);
            return Utilities.HashBytesToString(hashedData);
        }

        public IEnumerable<byte> Hash(IEnumerable<byte> data, int iterations = 5000)
        {
            using var md5 = MD5.Create();
            var hashedData = IHash.Generate(md5, data, iterations);
            return hashedData;
        }
    }
}
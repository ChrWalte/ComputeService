using ComputeService.v3.Interfaces;
using ComputeService.v3.Shared;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ComputeService.v3.Services.Hash
{
    public class Sha384Service : IHash
    {
        public string Hash(string data, int iterations = 5000)
        {
            var givenData = Utilities.StringToBytes(data);
            var hashedData = Hash(givenData, iterations);
            return Utilities.HashBytesToString(hashedData);
        }

        public IEnumerable<byte> Hash(IEnumerable<byte> data, int iterations = 5000)
        {
            using var sha384 = SHA384.Create();
            var hashedData = IHash.Generate(sha384, data, iterations);
            return hashedData;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace ComputeService.v1.Interfaces
{
    public interface IHash
    {
        string Hash(string data, int iterations = 5000);
        IEnumerable<byte> Hash(IEnumerable<byte> data, int iterations = 5000);
        protected static bool CheckHash(string first, string second)
            => first.Equals(second);

        protected static IEnumerable<byte> Generate(HashAlgorithm algorithm, IEnumerable<byte> data, int iterations)
        {
            for (var i = 0; i < iterations; i++)
                data = algorithm.ComputeHash(data.ToArray());

            return data;
        }
    }
}

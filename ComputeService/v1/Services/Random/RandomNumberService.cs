using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using ComputeService.v1.Interfaces;

namespace ComputeService.v1.Services.Random
{
    public class RandomNumberService : IRandom<int>
    {
        private readonly int _min;
        private readonly int _max;

        public RandomNumberService(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public int Generate()
        {
            using var rng = RandomNumberGenerator.Create();

            var randomValue = new byte[4];
            rng.GetBytes(randomValue);
            var computedValue = BitConverter.ToInt32(randomValue);

            return Math.Abs(computedValue) % (_max - _min + 1) + _min;
        }

        public IEnumerable<int> Generate(int count)
        {
            var randomNumbers = new int[count];

            for (var i = 0; i < count; i++)
                randomNumbers[i] = Generate();

            return randomNumbers;
        }
    }
}

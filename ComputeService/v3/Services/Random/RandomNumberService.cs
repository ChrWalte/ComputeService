using ComputeService.v3.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ComputeService.v3.Services.Random
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
            var randomNumbers = new List<int>();

            for (var i = 0; i < count; i++)
                randomNumbers.Add(Generate());

            return randomNumbers;
        }
    }
}
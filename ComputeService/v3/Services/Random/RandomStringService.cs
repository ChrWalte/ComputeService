using ComputeService.v3.Interfaces;
using System.Collections.Generic;

namespace ComputeService.v3.Services.Random
{
    public class RandomStringService : IRandom<string>
    {
        public const string AllChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!?.@#$%^&*()-=_+{}[]\\|\"';:,<>/~` ";
        public const string CommonChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!?.@#$%^&*()-=_+";

        private readonly int _length;
        private readonly string _chars;

        public RandomStringService(int length, string chars = CommonChars)
        {
            _length = length;
            _chars = chars;
        }

        public string Generate()
        {
            var value = "";
            var randomNumberService = new RandomNumberService(0, _chars.Length - 1);
            var randomNumbers = (List<int>)randomNumberService.Generate(_length);

            for (var i = 0; i < _length; i++)
                value += _chars[randomNumbers[i]];

            return value;
        }

        public IEnumerable<string> Generate(int count)
        {
            var values = new List<string>();

            for (var i = 0; i < count; i++)
                values.Add(Generate());

            return values;
        }
    }
}
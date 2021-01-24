using System.Collections.Generic;
using ComputeService.v1.Interfaces;

namespace ComputeService.v1.Services.Random
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
            var password = "";
            var randomNumberService = new RandomNumberService(0, _chars.Length - 1);
            var randomNumbers = (List<int>)randomNumberService.Generate(_length);

            for (var i = 0; i < _length; i++)
                password += _chars[randomNumbers[i]];

            return password;
        }

        public IEnumerable<string> Generate(int count)
        {
            var passwords = new string[count];

            for (var i = 0; i < count; i++)
                passwords[i] = Generate();

            return passwords;
        }
    }
}

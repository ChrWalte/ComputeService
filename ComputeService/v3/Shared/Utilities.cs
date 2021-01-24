using System.Collections.Generic;
using System.Text;

namespace ComputeService.v3.Shared
{
    public static class Utilities
    {
        public static string ApplySaltAndPepper(string data, string salt, string pepper)
            => $"{salt}{data}{pepper}";

        public static string ApplySalt(string data, string salt)
            => ApplySaltAndPepper(data, salt, string.Empty);

        public static string ApplyPepper(string data, string pepper)
            => ApplySaltAndPepper(data, string.Empty, pepper);

        public static IEnumerable<byte> StringToBytes(string data)
            => Encoding.UTF8.GetBytes(data);

        public static string BytesToString(IEnumerable<byte> data)
            => Encoding.UTF8.GetString((byte[])data);

        public static string HashBytesToString(IEnumerable<byte> data)
        {
            var stringBuilder = new StringBuilder();

            foreach (var idvByte in data)
                stringBuilder.Append(idvByte.ToString("x2"));

            return stringBuilder.ToString();
        }
    }
}
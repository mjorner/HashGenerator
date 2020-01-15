using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HashGenerator {
    public static class RandomKeyGenerator {
        private static readonly char[] chars = Enumerable.Range(33, ((126-33)+1)).Select(x=> (char)x).Where(x=> x != '\"' && x != '`' && x != '\'').ToArray();

        public static string GetUniqueKey(int size) {
            byte[] data = new byte[4 * size];
            using(RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider()) {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++) {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }
            return result.ToString();
        }
    }
}
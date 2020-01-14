using System.Text;

namespace HashGenerator {
    public abstract class ShaHashGeneratorBase : HashGeneratorBase {
        protected readonly int Iterations = 1;
        protected string GetFinalString(byte[] bytes) {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++) {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        protected byte[] GetInputBytes(string input, string salt) {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            bytes = AddSalt(bytes, saltBytes);
            return bytes;
        }

        protected override bool Verify(string input, string salt, string expected_hash) {
            byte[] bytes = Encoding.UTF8.GetBytes(GenerateHash(input, salt));
            return ByteByByteEquals(bytes, Encoding.UTF8.GetBytes(expected_hash));
        }

        private byte[] AddSalt(byte[] bytes, byte[] saltBytes) {
            byte[] newSaltedBytes = new byte[bytes.Length + saltBytes.Length];
            for (int i = 0; i < saltBytes.Length; i++) {
                newSaltedBytes[i] = saltBytes[i];
            }
            for (int i = 0; i < bytes.Length; i++) {
                newSaltedBytes[saltBytes.Length + i] = bytes[i];
            }
            return newSaltedBytes;
        }

        private static bool ByteByByteEquals(byte[] a, byte[] b) {
            uint diff = (uint) a.Length ^ (uint) b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++) {
                diff |= (uint) (a[i] ^ b[i]);
            }
            return diff == 0;
        }
    }
}
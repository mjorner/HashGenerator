using System.Security.Cryptography;

namespace HashGenerator {
    public class Md5HashGenerator : ShaHashGeneratorBase {
        public override string Identifier => "Md5";

        public override string GenerateHash(string input, string salt) {
            using(var md5 = MD5.Create()) {
                byte[] bytes = GetInputBytes(input, salt);
                int iteration = 0;
                while (iteration++ < Iterations) {
                    bytes = md5.ComputeHash(bytes);
                }
                return GetFinalString(bytes);
            }
        }
    }
}
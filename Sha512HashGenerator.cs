using System.Security.Cryptography;

namespace HashGenerator {
    public class Sha512HashGenerator : ShaHashGeneratorBase {
        public override string Identifier => "Sha512";
        public override string GenerateHash(string input, string salt) {
            using(var sha = SHA512.Create()) {
                byte[] bytes = GetInputBytes(input, salt);
                int iteration = 0;
                while (iteration++ < Iterations) {
                    bytes = sha.ComputeHash(bytes);
                }
                return GetFinalString(bytes);
            }
        }
    }
}
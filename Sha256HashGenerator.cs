using System.Security.Cryptography;

namespace HashGenerator {
    public class Sha256HashGenerator : ShaHashGeneratorBase {
        public override string Identifier => "Sha256";

        public override string GenerateHash(string input, string salt) {
            using(var sha = SHA256.Create()) {
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
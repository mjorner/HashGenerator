using System.Security.Cryptography;

namespace HashGenerator {
    public class Sha512HashGenerator : Sha256HashGenerator {
        public override string Identifier => "Sha512";
        public override string GenerateHash(string toBeHashed, string salt) {
            using(var sha = SHA512.Create()) {
                byte[] bytes = GetInputBytes(toBeHashed, salt);
                int iteration = 0;
                while (iteration++ < Iterations) {
                    bytes = sha.ComputeHash(bytes);
                }
                return GetFinalString(bytes);
            }
        }
    }
}
using System.Text;
using Isopoh.Cryptography.Argon2;

namespace HashGenerator {
    public class Argon2HashGenerator : HashGeneratorBase {
        public override string Identifier => "Argon2id";

        public override string GenerateHash(string toBeHashed, string salt) {
            Argon2Config config = GetConfig(toBeHashed, salt);
            string hash = Argon2.Hash(config);
            return hash;
        }

        protected override bool Verify(string up, string salt, string expected_hash) {
            Argon2Config config = GetConfig(up, salt);
            bool verified = Argon2.Verify(expected_hash, config);
            return verified;
        }

        private Argon2Config GetConfig(string up, string salt) {
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            var config = new Argon2Config();
            config.Password = Encoding.UTF8.GetBytes(up);
            config.SecureArrayCall = null;
            config.Secret = saltBytes;
            config.Salt = saltBytes;
            config.MemoryCost = 10000;
            return config;
        }
    }
}
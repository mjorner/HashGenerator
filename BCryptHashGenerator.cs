namespace HashGenerator {
    public class BCryptHashGenerator : HashGeneratorBase {
        public override string Identifier => "BCrypt";

        public override string GenerateHash(string input, string salt) {
            string hash = BCrypt.Net.BCrypt.HashPassword(AddSalt(input, salt));
            return hash;
        }

        protected override bool Verify(string input, string salt, string expected_hash) {
            bool verified = BCrypt.Net.BCrypt.Verify(AddSalt(input, salt), expected_hash);
            return verified;
        }
    }
}
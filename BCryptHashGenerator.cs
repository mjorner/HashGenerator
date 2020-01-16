namespace HashGenerator {
    /********************************************************
    * The BCrypt implementation salts the given input itself.
    * But this salts the input additionally.
    *********************************************************/
    public class BCryptHashGenerator : HashGeneratorBase {
        public override string Identifier => "BCrypt";

        public override string GenerateHash(string input, string salt) {
            string hash = BCrypt.Net.BCrypt.HashPassword(AddSalt(input, salt));
            return hash;
        }

        public override bool Verify(string input, string salt, string expectedHash) {
            bool verified = BCrypt.Net.BCrypt.Verify(AddSalt(input, salt), expectedHash);
            return verified;
        }
    }
}
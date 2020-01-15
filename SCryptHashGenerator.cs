namespace HashGenerator {
    public class SCryptHashGenerator : HashGeneratorBase {
        public override string Identifier => "SCrypt";

        public override string GenerateHash(string input, string salt) {
            var encoder = new Scrypt.ScryptEncoder();
            string hash = encoder.Encode(AddSalt(input, salt));
            return hash;
        }

        protected override bool Verify(string input, string salt, string expected_hash) {
            var encoder = new Scrypt.ScryptEncoder();
            bool verified = encoder.Compare(AddSalt(input, salt), expected_hash);
            return verified;
        }
    }
}
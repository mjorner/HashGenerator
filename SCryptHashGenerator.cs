namespace HashGenerator {
    /********************************************************
    * The SCrypt implementation salts the given input itself.
    * But this salts the input additionally.
    *********************************************************/
    public class SCryptHashGenerator : HashGeneratorBase {
        public override string Identifier => "SCrypt";

        public override string GenerateHash(string input, string salt) {
            var encoder = new Scrypt.ScryptEncoder();
            string hash = encoder.Encode(AddSalt(input, salt));
            return hash;
        }

        public override bool Verify(string input, string salt, string expectedHash) {
            var encoder = new Scrypt.ScryptEncoder();
            bool verified = encoder.Compare(AddSalt(input, salt), expectedHash);
            return verified;
        }
    }
}
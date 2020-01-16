using System;

namespace HashGenerator {
    public abstract class HashGeneratorBase {
        public abstract string GenerateHash(string input, string salt);
        public abstract string Identifier { get; }
        public abstract bool Verify(string input, string salt, string expectedHash);

        public void Generate() {
            Console.WriteLine($"------{Identifier}-generator------");
            string salt = RandomKeyGenerator.GetUniqueKey(16);
            Console.WriteLine($"Generated salt: \"{salt}\"");
            Console.WriteLine("Enter string to hash:");
            string input = Console.ReadLine().Trim();
            string hash = GenerateHash(input, salt);
            bool verified = Verify(input, salt, hash);
            if (!verified) {
                hash = "FAIL!";
            }
            Console.WriteLine($"{Identifier} hash: \"{hash}\"");
            Console.WriteLine("-------------------------");
        }

        protected static string AddSalt(string input, string salt) {
            return salt+input;
        }
    }
}
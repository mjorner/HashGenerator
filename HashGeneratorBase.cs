using System;

namespace HashGenerator {
    public abstract class HashGeneratorBase {
        public abstract string GenerateHash(string toBeHashed, string salt);
        public abstract string Identifier { get; }
        protected abstract bool Verify(string up, string salt, string expected_hash);

        public void Generate() {
            Console.WriteLine($"------{Identifier}-generator------");
            string salt = RandomKeyGenerator.GetUniqueKey(16);
            Console.WriteLine($"Generated salt: \"{salt}\"");
            Console.WriteLine("Enter string to hash:");
            string toBeHashed = Console.ReadLine().Trim();
            string hash = GenerateHash(toBeHashed, salt);
            bool verified = Verify(toBeHashed, salt, hash);
            if (!verified) {
                hash = "FAIL!";
            }
            Console.WriteLine($"{Identifier} hash: \"{hash}\"");
            Console.WriteLine("-------------------------");
        }
    }
}
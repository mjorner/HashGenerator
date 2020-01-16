using System;
using System.Diagnostics;

namespace HashGenerator {
    public class HashRunTimeTester {
        private readonly HashGeneratorBase HashGenerator;
        private readonly int Executions = 10;
        public HashRunTimeTester(HashGeneratorBase hashGenerator) {
            HashGenerator = hashGenerator;
        }

        public HashRunTimeTester(HashGeneratorBase hashGenerator, int executions) {
            HashGenerator = hashGenerator;
            Executions = executions;
        }

        public void Run() {
            RunGeneration();
            RunVerification();
        }

        private void RunVerification() {
            string input = "pa$$w0rd";
            string salt = RandomKeyGenerator.GetUniqueKey(16);
            string hash = HashGenerator.GenerateHash(input, salt);
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            for (int i = 0; i < Executions; i++) {
                bool verified = HashGenerator.Verify(input, salt, hash);
                if (!verified) {
                    Console.WriteLine("Ups! Hashing not working!");
                }
            }
            sw.Stop();
            Console.WriteLine($"{HashGenerator.Identifier.PadRight(10)} -> Hash verifications: {(""+Executions).PadRight(7)} Total verification time: {(""+sw.ElapsedMilliseconds+"ms").PadRight(10)} ms/hash: {(""+((double)sw.ElapsedMilliseconds)/((double)Executions)).PadRight(9)}");
        }

        private void RunGeneration() {
            string input = "pa$$w0rd";
            string salt = RandomKeyGenerator.GetUniqueKey(16);
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            int charCount = 0;
            for (int i = 0; i < Executions; i++) {
                string hash = HashGenerator.GenerateHash(input+i, salt+i);
                charCount += hash.Length;
            }
            sw.Stop();
            Console.WriteLine($"{HashGenerator.Identifier.PadRight(10)} -> Hash generations:   {(""+Executions).PadRight(7)} Total generation time:   {(""+sw.ElapsedMilliseconds+"ms").PadRight(10)} ms/hash: {(""+((double)sw.ElapsedMilliseconds)/((double)Executions)).PadRight(9)} Total hash char count: {charCount}");
        }
    }
}
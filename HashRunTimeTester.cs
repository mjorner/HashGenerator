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
            string toBeHashed = "password";
            string salt = RandomKeyGenerator.GetUniqueKey(16);
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            int charCount = 0;
            for (int i = 0; i < Executions; i++) {
                string hash = HashGenerator.GenerateHash(toBeHashed+i, salt+i);
                charCount += hash.Length;
            }
            sw.Stop();
            Console.WriteLine($"{HashGenerator.Identifier} -> Hash executions: {Executions}. Total hash time: {sw.ElapsedMilliseconds} ms. ms/hash {sw.ElapsedMilliseconds/Executions}. Total hash char count:{charCount}.");
        }
    }
}
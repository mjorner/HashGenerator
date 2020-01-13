namespace HashGenerator {
    class Program {
        public static void Main(string[] args) {
            new Program().Run();
        }

        public void Run() {
            new Argon2HashGenerator().Generate();
            new Sha256HashGenerator().Generate();
            new Sha512HashGenerator().Generate();
            new HashRunTimeTester(new Argon2HashGenerator(), 10).Run();
            new HashRunTimeTester(new Sha256HashGenerator(), 100000).Run();
            new HashRunTimeTester(new Sha512HashGenerator(), 100000).Run();
        }
    }
}